namespace Shove._Net.Ftp
{
    using System;

    public class TransStatusChangedEnventArgs
    {
        private TransferStatus transStatus;
        private TransmissionProcess tranProcess;

        public TransferStatus LastStatus
        {
            get
            {
                return this.transStatus;
            }
            set
            {
                this.transStatus = value;
            }
        }

        public TransmissionProcess TransProcess
        {
            get
            {
                return this.tranProcess;
            }
            set
            {
                this.tranProcess = value;
            }
        }

        public TransferStatus TransStatus
        {
            get
            {
                return this.tranProcess.TransStatus;
            }
            set
            {
                this.tranProcess.TransStatus = value;
            }
        }
    }
}

