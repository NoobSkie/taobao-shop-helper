namespace Shove._Net.Ftp
{
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class TransmissionProcess
    {
        private string fileName;
        private string localPath;
        private long totalBytes;
        private DateTime startTime;
        private string transMethod;
        private string serverPath;
        private long finishedBytes;
        private TransferStatus transStatus;
        private DateTime endTime;

        public event TransStatusDelegate StatusChanged;

        public event TransProcessDelegate TransProcessing;

        public void AppendBytes(int bytes)
        {
            this.FinishedBytes += bytes;
        }

        public void FinishBytes()
        {
            this.FinishedBytes = this.TotalBytes;
            this.TransStatus = TransferStatus.TranFinished;
        }

        public float CurrentPercent
        {
            get
            {
                if (this.TotalBytes > 0L)
                {
                    double num = ((double) this.FinishedBytes) / ((double) this.TotalBytes);
                    return (float) (Math.Floor((double) (num * 1000.0)) / 1000.0);
                }
                return 0f;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return this.endTime;
            }
            set
            {
                this.endTime = value;
            }
        }

        public string FileName
        {
            get
            {
                return this.fileName;
            }
            set
            {
                this.fileName = value;
            }
        }

        public long FinishedBytes
        {
            get
            {
                return this.finishedBytes;
            }
            set
            {
                this.finishedBytes = value;
                if (this.TransProcessing != null)
                {
                    this.TransProcessing(this);
                }
            }
        }

        public string LocalPath
        {
            get
            {
                return this.localPath;
            }
            set
            {
                this.localPath = value;
            }
        }

        public long PassingTicks
        {
            get
            {
                return Math.Abs(this.EndTime.Subtract(this.StartTime).Ticks);
            }
        }

        public string PassingTime
        {
            get
            {
                string str = string.Empty;
                TimeSpan span = new TimeSpan(this.PassingTicks);
                if (span.TotalDays >= 1.0)
                {
                    str = str + string.Format("{0}天", span.Days);
                }
                if ((str != string.Empty) || (span.TotalHours >= 1.0))
                {
                    str = str + string.Format("{0}小时", span.Hours);
                }
                if ((str != string.Empty) || (span.TotalMinutes >= 1.0))
                {
                    str = str + string.Format("{0}分", span.Minutes);
                }
                if (!(str != string.Empty) && (span.TotalSeconds < 1.0))
                {
                    return str;
                }
                return (str + string.Format("{0}秒", span.Seconds));
            }
        }

        public string ServerPath
        {
            get
            {
                return this.serverPath;
            }
            set
            {
                this.serverPath = value;
            }
        }

        public DateTime StartTime
        {
            get
            {
                return this.startTime;
            }
            set
            {
                this.startTime = value;
            }
        }

        public long TotalBytes
        {
            get
            {
                return this.totalBytes;
            }
            set
            {
                this.totalBytes = value;
            }
        }

        public string TransMethod
        {
            get
            {
                return this.transMethod;
            }
            set
            {
                this.transMethod = value;
            }
        }

        public TransferStatus TransStatus
        {
            get
            {
                return this.transStatus;
            }
            set
            {
                if ((this.StatusChanged != null) && (this.transStatus != value))
                {
                    TransStatusChangedEnventArgs statusChangedArgs = new TransStatusChangedEnventArgs();
                    statusChangedArgs.LastStatus = this.transStatus;
                    this.transStatus = value;
                    statusChangedArgs.TransProcess = this;
                    this.StatusChanged(statusChangedArgs);
                }
                else
                {
                    this.transStatus = value;
                }
            }
        }
    }
}

