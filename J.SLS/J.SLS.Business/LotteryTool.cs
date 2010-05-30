using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace J.SLS.Business
{
    public class LotteryTool
    {
        public LotteryBase[] GetLotterys()
        {
            int num = 1;
            while (this[num] != null)
            {
                num++;
            }
            LotteryBase[] baseArray = new LotteryBase[num - 1];
            for (int i = 0; i < baseArray.Length; i++)
            {
                baseArray[i] = this[i + 1];
            }
            return baseArray;
        }

        public int GetMaxLotteryID()
        {
            return this[this.GetLotterys().Length].id;
        }

        public string GetPlayTypeName(int PlayType)
        {
            foreach (LotteryBase base2 in this.GetLotterys())
            {
                foreach (PlayType type in base2.GetPlayTypeList())
                {
                    if (type.ID == PlayType)
                    {
                        return type.Name;
                    }
                }
            }
            return "";
        }

        public bool ValidID(int LotteryID)
        {
            return ((LotteryID >= 1) && (LotteryID <= this.GetMaxLotteryID()));
        }

        public LotteryBase this[string Name_or_Code_or_ID]
        {
            get
            {
                foreach (LotteryBase base2 in this.GetLotterys())
                {
                    if (((base2.name == Name_or_Code_or_ID) || (base2.code == Name_or_Code_or_ID)) || (base2.id.ToString() == Name_or_Code_or_ID))
                    {
                        return base2;
                    }
                }
                return null;
            }
        }

        public LotteryBase this[int Index]
        {
            get
            {
                switch (Index)
                {
                    case 1:
                        return new SFC();

                    case 2:
                        return new JQC();

                    case 3:
                        return new QXC();

                    case 4:
                        return new SZPL();

                    case 5:
                        return new SSQ();

                    case 6:
                        return new FC3D();

                    case 7:
                        return new LJ36X7();

                    case 8:
                        return new LJP62();

                    case 9:
                        return new TC22X5();

                    case 10:
                        return new FZ36X7();

                    case 11:
                        return new CTFC32X7();

                    case 12:
                        return new CTFC22X5();

                    case 13:
                        return new QLC();

                    case 14:
                        return new TC29X7();

                    case 15:
                        return new LCBQC();

                    case 0x10:
                        return new NYFC36X7();

                    case 0x11:
                        return new NYFC26X5();

                    case 0x12:
                        return new SJFC21X5();

                    case 0x13:
                        return new LCDC();

                    case 20:
                        return new SZFC35X7();

                    case 0x15:
                        return new ZJ15X5();

                    case 0x16:
                        return new ZJFC4J1();

                    case 0x17:
                        return new HNFC22X5();

                    case 0x18:
                        return new DFDLT();

                    case 0x19:
                        return new AHFC25X5();

                    case 0x1a:
                        return new AHFC15X5();

                    case 0x1b:
                        return new QLFC23X5();

                    case 0x1c:
                        return new CQSSC();

                    case 0x1d:
                        return new SHSSL();

                    case 30:
                        return new FJFC20X5();

                    case 0x1f:
                        return new AHFC5WS();

                    case 0x20:
                        return new SZKL8();

                    case 0x21:
                        return new BJKL8();

                    case 0x22:
                        return new SHKENO();

                    case 0x23:
                        return new FJTC31X7();

                    case 0x24:
                        return new FJTC36X7();

                    case 0x25:
                        return new FJTC22X5();

                    case 0x26:
                        return new LNFC35X7();

                    case 0x27:
                        return new TCCJDLT();

                    case 40:
                        return new ZJTC20X5();

                    case 0x29:
                        return new ZJTC6J1();

                    case 0x2a:
                        return new LJFC22X5();

                    case 0x2b:
                        return new LJTC6J1();

                    case 0x2c:
                        return new TTL22X5();

                    case 0x2d:
                        return new ZCDC();

                    case 0x2e:
                        return new TJFC15X5();

                    case 0x2f:
                        return new LNFC25X4();

                    case 0x30:
                        return new HBKLPK();

                    case 0x31:
                        return new SDKLPK();

                    case 50:
                        return new HeBKLPK();

                    case 0x33:
                        return new AHKLPK();

                    case 0x34:
                        return new HLJKLPK();

                    case 0x35:
                        return new LLKLPK();

                    case 0x36:
                        return new SXKLPK();

                    case 0x37:
                        return new ZJKLPK();

                    case 0x38:
                        return new SCKLPK();

                    case 0x39:
                        return new ShXKLPK();

                    case 0x3a:
                        return new DF6J1();

                    case 0x3b:
                        return new HD15X5();

                    case 60:
                        return new TTCX4();

                    case 0x3d:
                        return new JXSSC();

                    case 0x3e:
                        return new SYYDJ();

                    case 0x3f:
                        return new SZPL3();

                    case 0x40:
                        return new SZPL5();

                    case 0x41:
                        return new TC31X7();

                    case 0x42:
                        return new XJSSC();

                    case 0x43:
                        return new JXFC3D();

                    case 0x44:
                        return new HNKY481();

                    case 0x45:
                        return new ZYFC22X5();

                    case 70:
                        return new JX11X5();
                }
                return null;
            }
        }
    }
}
