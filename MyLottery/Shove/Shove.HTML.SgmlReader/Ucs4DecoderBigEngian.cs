using System;
using System.Collections.Generic;
using System.Text;

namespace Shove.HTML.SgmlReader
{
    internal class Ucs4DecoderBigEngian : Ucs4Decoder
    {
        internal override int GetFullChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
        {
            UInt32 code;
            int i, j;
            byteCount += byteIndex;
            for (i = byteIndex, j = charIndex; i + 3 < byteCount; )
            {
                code = (UInt32)(((bytes[i + 3]) << 24) | (bytes[i + 2] << 16) | (bytes[i + 1] << 8) | (bytes[i]));
                if (code > 0x10FFFF)
                {
                    throw new Exception("Invalid character 0x" + code.ToString("x") + " in encoding");
                }
                else if (code > 0xFFFF)
                {
                    chars[j] = UnicodeToUTF16(code);
                    j++;
                }
                else
                {
                    if (code >= 0xD800 && code <= 0xDFFF)
                    {
                        throw new Exception("Invalid character 0x" + code.ToString("x") + " in encoding");
                    }
                    else
                    {
                        chars[j] = (char)code;
                    }
                }
                j++;
                i += 4;
            }
            return j - charIndex;
        }
    }
}
