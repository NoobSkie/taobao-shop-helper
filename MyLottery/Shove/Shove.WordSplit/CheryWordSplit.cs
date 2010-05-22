namespace Shove.WordSplit
{
    using System;
    using System.Collections;

    public class CheryWordSplit
    {
        public Dictionary m_Dict;

        public CheryWordSplit()
        {
            this.m_Dict = new Dictionary();
        }

        public CheryWordSplit(string chineseDictionaryFileName)
        {
            if (chineseDictionaryFileName.Trim() == "")
            {
                this.m_Dict = new Dictionary();
            }
            else
            {
                this.m_Dict = new Dictionary(chineseDictionaryFileName);
            }
        }

        public string[] GetSlpitWords(string sSource)
        {
            if (!this.m_Dict.m_isOpen)
            {
                return null;
            }
            sSource = sSource.Trim();
            if (sSource == "")
            {
                return null;
            }
            if (sSource.Length == 1)
            {
                int wordType = this.m_Dict.GetWordType(sSource[0]);
                if ((wordType != 0) && (wordType <= 10))
                {
                    return null;
                }
                return new string[] { sSource };
            }
            ArrayList list = new ArrayList();
            int startIndex = 0;
            while (startIndex < sSource.Length)
            {
                string str = sSource.Substring(startIndex, 1);
                string str2 = sSource.Substring(startIndex, 1);
                int num4 = this.m_Dict.GetWordType(str2[0]);
                if (num4 < 0)
                {
                    startIndex++;
                    continue;
                }
                if ((num4 == 0) || (num4 == 1))
                {
                    int num5 = 0;
                    if (num4 == 0)
                    {
                        num5++;
                    }
                    while (++startIndex < sSource.Length)
                    {
                        str2 = sSource.Substring(startIndex, 1);
                        num4 = this.m_Dict.GetWordType(str2[0]);
                        if ((num4 != 0) && (num4 != 1))
                        {
                            break;
                        }
                        str = str + str2;
                        if (num4 == 0)
                        {
                            num5++;
                        }
                    }
                    if (num5 > 0)
                    {
                        list.Add(str);
                    }
                    continue;
                }
                if (num4 >= 10)
                {
                    int length = sSource.Length - startIndex;
                    if (length > this.m_Dict.m_WordMaxLen)
                    {
                        length = this.m_Dict.m_WordMaxLen;
                    }
                    string wordAtDictionary = this.m_Dict.GetWordAtDictionary(sSource.Substring(startIndex, length));
                    if (wordAtDictionary != "")
                    {
                        list.Add(wordAtDictionary);
                        startIndex += wordAtDictionary.Length;
                        continue;
                    }
                    if ((num4 == 10) || (num4 == 11))
                    {
                        while (++startIndex < sSource.Length)
                        {
                            str2 = sSource.Substring(startIndex, 1);
                            num4 = this.m_Dict.GetWordType(str2[0]);
                            if ((num4 != 10) && (num4 != 11))
                            {
                                break;
                            }
                            str = str + str2;
                        }
                        list.Add(str);
                        continue;
                    }
                    bool flag = false;
                    if (list.Count > 0)
                    {
                        string sWord = list[list.Count - 1].ToString();
                        if ((sWord.Length > 1) && (this.m_Dict.GetWordType(sWord[sWord.Length - 1]) >= 10))
                        {
                            sWord.Substring(sWord.Length - 1, 1);
                            sWord = sWord.Substring(0, sWord.Length - 1);
                            if (sWord.Length == 1)
                            {
                                switch (this.m_Dict.GetWordType(sWord[0]))
                                {
                                    case 10:
                                    case 11:
                                    case 12:
                                        flag = true;
                                        break;
                                }
                            }
                            else if (this.m_Dict.WordExist(sWord))
                            {
                                flag = true;
                            }
                            else
                            {
                                switch (this.m_Dict.GetWordType(sWord[sWord.Length - 1]))
                                {
                                    case 10:
                                    case 11:
                                        flag = true;
                                        break;
                                }
                            }
                        }
                    }
                    if (flag)
                    {
                        string str5 = "";
                        length = (sSource.Length - startIndex) + 1;
                        if (length > this.m_Dict.m_WordMaxLen)
                        {
                            length = this.m_Dict.m_WordMaxLen;
                        }
                        str5 = this.m_Dict.GetWordAtDictionary(sSource.Substring(startIndex - 1, length));
                        if (str5 != "")
                        {
                            string str6 = list[list.Count - 1].ToString();
                            list[list.Count - 1] = str6.Substring(0, str6.Length - 1);
                            list.Add(str5);
                            startIndex += str5.Length - 1;
                            continue;
                        }
                    }
                    list.Add(str2);
                    startIndex++;
                }
            }
            if (list.Count == 0)
            {
                return null;
            }
            string[] strArray = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                strArray[i] = list[i].ToString();
            }
            return strArray;
        }

        public string[] ReBuildWords(string[] sWordsList)
        {
            if (sWordsList == null)
            {
                return null;
            }
            ArrayList list = new ArrayList();
            for (int i = 0; i < sWordsList.Length; i++)
            {
                bool flag = false;
                for (int k = 0; k < list.Count; k++)
                {
                    if (list[k].ToString() == sWordsList[i])
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    list.Add(sWordsList[i]);
                }
            }
            if (list.Count == 0)
            {
                return null;
            }
            string[] strArray = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray[j] = list[j].ToString();
            }
            return strArray;
        }
    }
}

