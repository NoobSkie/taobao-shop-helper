namespace Shove.WordSplit
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    public class Dictionary
    {
        public int m_FlagNum;
        public bool m_isOpen;
        public int m_WordMaxLen;
        public WordsList[] m_WordsList;
        private string ChineseDictionaryFileName;

        public Dictionary()
        {
            this.m_FlagNum = 0x51a5;
            this.m_WordMaxLen = 0;
            this.ChineseDictionaryFileName = @".\ChineseDictionary.dat";
            this.m_isOpen = this.OpenDictionary();
        }

        public Dictionary(string chineseDictionaryFileName)
        {
            this.m_FlagNum = 0x51a5;
            this.m_WordMaxLen = 0;
            this.ChineseDictionaryFileName = chineseDictionaryFileName;
            this.m_isOpen = this.OpenDictionary();
        }

        public bool AddWord(string Word)
        {
            if (!this.m_isOpen)
            {
                return false;
            }
            Word = Word.Trim();
            if (Word.Length < 2)
            {
                return false;
            }
            int index = Word[0] - '一';
            if ((index < 0) || (index > 0x51a4))
            {
                return false;
            }
            if (this.m_WordsList[index].m_List == null)
            {
                this.m_WordsList[index].m_List = new ArrayList();
            }
            this.m_WordsList[index].m_List.Add(Word.Substring(1, Word.Length - 1));
            this.WordSort(index);
            return true;
        }

        public void CalcWordMaxLen()
        {
            this.m_WordMaxLen = 0;
            for (int i = 0; i < 0x51a5; i++)
            {
                if (this.m_WordsList[i].m_List != null)
                {
                    for (int j = 0; j < this.m_WordsList[i].m_List.Count; j++)
                    {
                        if ((this.m_WordsList[i].m_List[j].ToString().Length + 1) > this.m_WordMaxLen)
                        {
                            this.m_WordMaxLen = this.m_WordsList[i].m_List[j].ToString().Length + 1;
                        }
                    }
                }
            }
        }

        public bool DeleteWord(string Word)
        {
            if (this.m_isOpen)
            {
                Word = Word.Trim();
                if (Word.Length < 2)
                {
                    return false;
                }
                int index = Word[0] - '一';
                if ((index < 0) || (index > 0x51a4))
                {
                    return false;
                }
                if (this.m_WordsList[index].m_List != null)
                {
                    Word = Word.Substring(1, Word.Length - 1);
                    for (int i = 0; i < this.m_WordsList[index].m_List.Count; i++)
                    {
                        if (this.m_WordsList[index].m_List[i].ToString() == Word)
                        {
                            this.m_WordsList[index].m_List.RemoveAt(i);
                            this.CalcWordMaxLen();
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public ArrayList FindWordsList(string ch)
        {
            int index = ch[0] - '一';
            if ((index >= 0) && (index <= 0x51a4))
            {
                return this.m_WordsList[index].m_List;
            }
            return null;
        }

        public string GetWordAtDictionary(string sWord)
        {
            string ch = sWord[0].ToString();
            ArrayList list = this.FindWordsList(ch);
            if (list != null)
            {
                sWord = sWord.Substring(1, sWord.Length - 1);
                for (int i = 0; i < list.Count; i++)
                {
                    string str2 = list[i].ToString();
                    int length = str2.Length;
                    if ((length <= sWord.Length) && (sWord.Substring(0, length) == str2))
                    {
                        return (ch + str2);
                    }
                }
            }
            return "";
        }

        public ArrayList GetWordsListAll(bool WithFlag, bool ReSort)
        {
            if (!this.m_isOpen)
            {
                return null;
            }
            ArrayList list = new ArrayList();
            for (int i = 0; i < 0x51a5; i++)
            {
                if (this.m_WordsList[i].m_List != null)
                {
                    for (int j = 0; j < this.m_WordsList[i].m_List.Count; j++)
                    {
                        if (WithFlag)
                        {
                            list.Add(((char) (i + 0x4e00)).ToString() + this.m_WordsList[i].m_List[j].ToString());
                        }
                        else
                        {
                            list.Add(this.m_WordsList[i].m_List[j]);
                        }
                    }
                }
            }
            if (ReSort)
            {
                OrderValue comparer = new OrderValue();
                list.Sort(comparer);
            }
            return list;
        }

        public int GetWordType(char ch)
        {
            string str = ch.ToString();
            int num = ch;
            if ((((num >= 0x61) && (num <= 0x7a)) || ((num >= 0x41) && (num <= 90))) || ((((num >= 0xff21) && (num <= 0xff3a)) || ((num >= 0xff41) && (num <= 0xff5a))) || ("0123456789０１２３４５６７８９".IndexOf(str) >= 0)))
            {
                return 0;
            }
            if ("!@#$%^&*()_-+=|\\~`[]{}<>./［］｛｝！\x00b7＃￥％…—＊（）".IndexOf(str) >= 0)
            {
                return 1;
            }
            if ((num < 0x4e00) || (num > 0x9fa4))
            {
                return -1;
            }
            if ("第一二两三四五六七八九十壹贰叁肆伍陆柒捌玖拾零百千万亿兆佰仟卅几整".IndexOf(str) >= 0)
            {
                return 10;
            }
            if ("元角分毛点时半刻秒岁个把盒包箱条件张页本块根套面幅付副吨斤克两钱磅米厘听毫丈尺寸里卷打瓶罐桶只支袋部次台辆年月日天号周折头份成位名种楼路层项级封度微升片粒双匹票盅碟碗盏方滴册箩坨杯口滩笼扇筐簸串吊挂捆团担家壶轮令栋发株沓窝群枚具棵枝管道颗款朵缕堂盘节贴剂服座幢堵间处所架艘趟爿手桩宗笔通场记喷则首篇门尊股席倍餐回顿句泓挺惯身叠锅束地绺出集段曲波员池声刀帘代边组届类批步等章环列期胎维品更局户季帮遍簇丛端堆队对番格伙栏篮例流抹排枪区圈拳提招桌着大".IndexOf(str) >= 0)
            {
                return 11;
            }
            if ("和及与跟同或最已而等用把上来".IndexOf(str) >= 0)
            {
                return 12;
            }
            return 13;
        }

        public bool LoadFromTxtFile(string TxtFileName)
        {
            StreamReader reader;
            try
            {
                reader = new StreamReader(TxtFileName);
            }
            catch
            {
                return false;
            }
            for (int i = 0; i < 0x51a5; i++)
            {
                if (this.m_WordsList[i].m_List != null)
                {
                    this.m_WordsList[i].m_List.Clear();
                }
            }
            string str = "";
            int index = 0;
            for (str = reader.ReadLine(); str != null; str = reader.ReadLine())
            {
                str = str.Trim();
                if (str.Length >= 2)
                {
                    index = str[0] - '一';
                    if ((index >= 0) && (index <= 0x51a4))
                    {
                        if (this.m_WordsList[index].m_List == null)
                        {
                            this.m_WordsList[index].m_List = new ArrayList();
                        }
                        this.m_WordsList[index].m_List.Add(str.Substring(1, str.Length - 1));
                    }
                }
            }
            reader.Close();
            this.WordSort();
            return true;
        }

        public bool OpenDictionary()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Stream serializationStream = null;
            try
            {
                serializationStream = new FileStream(this.ChineseDictionaryFileName, FileMode.Open, FileAccess.Read);
                this.m_WordsList = (WordsList[]) formatter.Deserialize(serializationStream);
            }
            catch
            {
                if (serializationStream != null)
                {
                    serializationStream.Close();
                }
                return false;
            }
            serializationStream.Close();
            if (this.m_WordsList.Length != 0x51a5)
            {
                return false;
            }
            this.CalcWordMaxLen();
            return true;
        }

        public bool Save()
        {
            return this.Save(this.ChineseDictionaryFileName);
        }

        public bool Save(string chineseDictionaryFileName)
        {
            if (!this.m_isOpen)
            {
                return false;
            }
            IFormatter formatter = new BinaryFormatter();
            Stream serializationStream = null;
            try
            {
                serializationStream = new FileStream(chineseDictionaryFileName, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(serializationStream, this.m_WordsList);
                serializationStream.Close();
                return true;
            }
            catch
            {
                if (serializationStream != null)
                {
                    serializationStream.Close();
                }
                return false;
            }
        }

        public bool SaveToTxtFile(string TxtFileName)
        {
            ArrayList wordsListAll = this.GetWordsListAll(true, true);
            if (wordsListAll == null)
            {
                return false;
            }
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(TxtFileName);
            }
            catch
            {
                return false;
            }
            for (int i = 0; i < wordsListAll.Count; i++)
            {
                writer.WriteLine(wordsListAll[i].ToString());
            }
            writer.Close();
            return true;
        }

        public bool WordExist(string sWord)
        {
            if (this.m_isOpen)
            {
                sWord = sWord.Trim();
                if (sWord.Length < 2)
                {
                    return false;
                }
                string ch = sWord[0].ToString();
                ArrayList list = this.FindWordsList(ch);
                if (list == null)
                {
                    return false;
                }
                sWord = sWord.Substring(1, sWord.Length - 1);
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].ToString() == sWord)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool WordSort()
        {
            if (!this.m_isOpen)
            {
                return false;
            }
            OrderLength comparer = new OrderLength();
            for (int i = 0; i < 0x51a4; i++)
            {
                if (this.m_WordsList[i].m_List != null)
                {
                    this.m_WordsList[i].m_List.Sort(comparer);
                }
            }
            return true;
        }

        public bool WordSort(int Unicode)
        {
            if (!this.m_isOpen)
            {
                return false;
            }
            if ((Unicode < 0) || (Unicode > 0x51a4))
            {
                return false;
            }
            if (this.m_WordsList[Unicode].m_List == null)
            {
                return false;
            }
            OrderLength comparer = new OrderLength();
            this.m_WordsList[Unicode].m_List.Sort(comparer);
            return true;
        }

        private class OrderValue : IComparer
        {
            public int Compare(object x, object y)
            {
                return new CaseInsensitiveComparer().Compare(x, y);
            }
        }

        private class OrderLength : IComparer
        {
            public int Compare(object x, object y)
            {
                return new CaseInsensitiveComparer().Compare(((string) y).Length, ((string) x).Length);
            }
        }
    }
}

