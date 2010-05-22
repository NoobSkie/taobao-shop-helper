using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Shove.HTML.SgmlReader
{
    internal class HtmlStream : TextReader
    {
        Stream stm;
        byte[] rawBuffer;
        int rawPos;
        int rawUsed;
        Encoding encoding;
        Decoder decoder;
        char[] buffer;
        int used;
        int pos;
        private const int BUFSIZE = 16384;
        private const int EOF = -1;

        public HtmlStream(Stream stm, Encoding defaultEncoding)
        {
            if (defaultEncoding == null) defaultEncoding = Encoding.UTF8; 
            if (!stm.CanSeek)
            {
              
                stm = CopyToMemoryStream(stm);
            }
            this.stm = stm;
            rawBuffer = new Byte[BUFSIZE];
            rawUsed = stm.Read(rawBuffer, 0, 4); 
            this.buffer = new char[BUFSIZE];


            this.decoder = AutoDetectEncoding(rawBuffer, ref rawPos, rawUsed);
            int bom = rawPos;
            if (this.decoder == null)
            {
                this.decoder = defaultEncoding.GetDecoder();
                rawUsed += stm.Read(rawBuffer, 4, BUFSIZE - 4);
                DecodeBlock();
 
                Decoder sd = SniffEncoding();
                if (sd != null)
                {
                    this.decoder = sd;
                }
            }


            this.stm.Seek(0, SeekOrigin.Begin);
            this.pos = this.used = 0;

            if (bom > 0)
            {
                stm.Read(this.rawBuffer, 0, bom);
            }
            this.rawPos = this.rawUsed = 0;

        }

        public Encoding Encoding
        {
            get
            {
                return this.encoding;
            }
        }

        Stream CopyToMemoryStream(Stream s)
        {
            int size = 100000; 
            byte[] buffer = new byte[size];
            int len;
            MemoryStream r = new MemoryStream();
            while ((len = s.Read(buffer, 0, size)) > 0)
            {
                r.Write(buffer, 0, len);
            }
            r.Seek(0, SeekOrigin.Begin);
            s.Close();
            return r;
        }

        internal void DecodeBlock()
        {
            if (pos > 0)
            {
                if (pos < used)
                {
                    System.Array.Copy(buffer, pos, buffer, 0, used - pos);
                }
                used -= pos;
                pos = 0;
            }
            int len = decoder.GetCharCount(rawBuffer, rawPos, rawUsed - rawPos);
            int available = buffer.Length - used;
            if (available < len)
            {
                char[] newbuf = new char[buffer.Length + len];
                System.Array.Copy(buffer, pos, newbuf, 0, used - pos);
                buffer = newbuf;
            }
            used = pos + decoder.GetChars(rawBuffer, rawPos, rawUsed - rawPos, buffer, pos);
            rawPos = rawUsed;
        }
        internal static Decoder AutoDetectEncoding(byte[] buffer, ref int index, int length)
        {
            if (4 <= (length - index))
            {
                uint w = (uint)buffer[index + 0] << 24 | (uint)buffer[index + 1] << 16 | (uint)buffer[index + 2] << 8 | (uint)buffer[index + 3];
  
                switch (w)
                {
                    case 0xfefffeff:
                        index += 4;
                        return new Ucs4DecoderBigEngian();

                    case 0xfffefffe:
                        index += 4;
                        return new Ucs4DecoderLittleEndian();

                    case 0x3c000000:
                        goto case 0xfefffeff;

                    case 0x0000003c:
                        goto case 0xfffefffe;
                }
                w >>= 8;
                if (w == 0xefbbbf)
                {
                    index += 3;
                    return Encoding.UTF8.GetDecoder();
                }
                w >>= 8;
                switch (w)
                {
                    case 0xfeff:
                        index += 2;
                        return UnicodeEncoding.BigEndianUnicode.GetDecoder();

                    case 0xfffe:
                        index += 2;
                        return new UnicodeEncoding(false, false).GetDecoder();

                    case 0x3c00:
                        goto case 0xfeff;

                    case 0x003c:
                        goto case 0xfffe;
                }
            }
            return null;
        }
        private int ReadChar()
        {
            if (pos < used) return buffer[pos++];
            return EOF;
        }
        private int PeekChar()
        {
            int ch = ReadChar();
            if (ch != EOF)
            {
                pos--;
            }
            return ch;
        }
        private bool SniffPattern(string pattern)
        {
            int ch = PeekChar();
            if (ch != pattern[0]) return false;
            for (int i = 0, n = pattern.Length; ch != EOF && i < n; i++)
            {
                ch = ReadChar();
                char m = pattern[i];
                if (ch != m)
                {
                    return false;
                }
            }
            return true;
        }
        private void SniffWhitespace()
        {
            char ch = (char)PeekChar();
            while (ch == ' ' || ch == '\t' || ch == '\r' || ch == '\n')
            {
                int i = pos;
                ch = (char)ReadChar();
                if (ch != ' ' && ch != '\t' && ch != '\r' && ch != '\n')
                    pos = i;
            }
        }

        private string SniffLiteral()
        {
            int quoteChar = PeekChar();
            if (quoteChar == '\'' || quoteChar == '"')
            {
                ReadChar();
                int i = this.pos;
                int ch = ReadChar();
                while (ch != EOF && ch != quoteChar)
                {
                    ch = ReadChar();
                }
                return (pos > i) ? new string(buffer, i, pos - i - 1) : "";
            }
            return null;
        }
        private string SniffAttribute(string name)
        {
            SniffWhitespace();
            string id = SniffName();
            if (name == id)
            {
                SniffWhitespace();
                if (SniffPattern("="))
                {
                    SniffWhitespace();
                    return SniffLiteral();
                }
            }
            return null;
        }
        private string SniffAttribute(out string name)
        {
            SniffWhitespace();
            name = SniffName();
            if (name != null)
            {
                SniffWhitespace();
                if (SniffPattern("="))
                {
                    SniffWhitespace();
                    return SniffLiteral();
                }
            }
            return null;
        }
        private void SniffTerminator(string term)
        {
            int ch = ReadChar();
            int i = 0;
            int n = term.Length;
            while (i < n && ch != EOF)
            {
                if (term[i] == ch)
                {
                    i++;
                    if (i == n) break;
                }
                else
                {
                    i = 0;
                }
                ch = ReadChar();
            }
        }
        internal Decoder SniffEncoding()
        {
            Decoder decoder = null;
            if (SniffPattern("<?xml"))
            {
                string version = SniffAttribute("version");
                if (version != null)
                {
                    string encoding = SniffAttribute("encoding");
                    if (encoding != null)
                    {
                        try
                        {
                            Encoding enc = Encoding.GetEncoding(encoding);
                            if (enc != null)
                            {
                                this.encoding = enc;
                                return enc.GetDecoder();
                            }
                        }
                        catch (Exception)
                        {
  
                        }
                    }
                    SniffTerminator(">");
                }
            }
            if (decoder == null)
            {
                return SniffMeta();
            }
            return null;
        }

        internal Decoder SniffMeta()
        {
            int i = ReadChar();
            while (i != EOF)
            {
                char ch = (char)i;
                if (ch == '<')
                {
                    string name = SniffName();
                    if (name != null && StringUtilities.EqualsIgnoreCase(name, "meta"))
                    {
                        string httpequiv = null;
                        string content = null;
                        while (true)
                        {
                            string value = SniffAttribute(out name);
                            if (name == null)
                            {
                                break;
                            }
                            if (StringUtilities.EqualsIgnoreCase(name, "http-equiv"))
                            {
                                httpequiv = value;
                            }
                            else if (StringUtilities.EqualsIgnoreCase(name, "content"))
                            {
                                content = value;
                            }
                        }
                        if (httpequiv != null && StringUtilities.EqualsIgnoreCase(httpequiv, "content-type") && content != null)
                        {
                            int j = content.IndexOf("charset");
                            if (j >= 0)
                            {
 
                                j = content.IndexOf("=", j);
                                if (j >= 0)
                                {
                                    j++;
                                    int k = content.IndexOf(";", j);
                                    if (k < 0) k = content.Length;
                                    string charset = content.Substring(j, k - j).Trim();
                                    try
                                    {
                                        Encoding e = Encoding.GetEncoding(charset);
                                        this.encoding = e;
                                        return e.GetDecoder();
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                    }
                }
                i = ReadChar();

            }
            return null;
        }

        internal string SniffName()
        {
            int c = PeekChar();
            if (c == EOF)
                return null;
            char ch = (char)c;
            int start = pos;
            while (pos < used - 1 && (Char.IsLetterOrDigit(ch) || ch == '-' || ch == '_' || ch == ':'))
            {
                ch = buffer[++pos];
            }
            if (start == pos) return null;
            return new string(buffer, start, pos - start);
        }

        internal void SkipWhitespace()
        {
            char ch = (char)PeekChar();
            while (pos < used - 1 && (ch == ' ' || ch == '\r' || ch == '\n'))
            {
                ch = buffer[++pos];
            }
        }
        internal void SkipTo(char what)
        {
            char ch = (char)PeekChar();
            while (pos < used - 1 && (ch != what))
            {
                ch = buffer[++pos];
            }
        }
        internal string ParseAttribute()
        {
            SkipTo('=');
            if (pos < used)
            {
                pos++;
                SkipWhitespace();
                if (pos < used)
                {
                    char quote = buffer[pos];
                    pos++;
                    int start = pos;
                    SkipTo(quote);
                    if (pos < used)
                    {
                        string result = new string(buffer, start, pos - start);
                        pos++;
                        return result;
                    }
                }
            }
            return null;
        }
        public override int Peek()
        {
            int result = Read();
            if (result != EOF)
            {
                pos--;
            }
            return result;
        }
        public override int Read()
        {
            if (pos == used)
            {
                rawUsed = stm.Read(rawBuffer, 0, rawBuffer.Length);
                rawPos = 0;
                if (rawUsed == 0) return EOF;
                DecodeBlock();
            }
            if (pos < used) return buffer[pos++];
            return -1;
        }
        public override int Read(char[] buffer, int start, int length)
        {
            if (pos == used)
            {
                rawUsed = stm.Read(rawBuffer, 0, rawBuffer.Length);
                rawPos = 0;
                if (rawUsed == 0) return -1;
                DecodeBlock();
            }
            if (pos < used)
            {
                length = Math.Min(used - pos, length);
                Array.Copy(this.buffer, pos, buffer, start, length);
                pos += length;
                return length;
            }
            return 0;
        }

        public override int ReadBlock(char[] buffer, int index, int count)
        {
            return Read(buffer, index, count);
        }

        public int ReadLine(char[] buffer, int start, int length)
        {
            int i = 0;
            int ch = ReadChar();
            while (ch != EOF)
            {
                buffer[i + start] = (char)ch;
                i++;
                if (i + start == length)
                    break;

                if (ch == '\r')
                {
                    if (PeekChar() == '\n')
                    {
                        ch = ReadChar();
                        buffer[i + start] = (char)ch;
                        i++;
                    }
                    break;
                }
                else if (ch == '\n')
                {
                    break;
                }
                ch = ReadChar();
            }
            return i;
        }

        public override string ReadToEnd()
        {
            char[] buffer = new char[100000]; 
            int len = 0;
            StringBuilder sb = new StringBuilder();
            while ((len = Read(buffer, 0, buffer.Length)) > 0)
            {
                sb.Append(buffer, 0, len);
            }
            return sb.ToString();
        }
        public override void Close()
        {
            stm.Close();
        }
    }
}
