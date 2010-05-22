namespace URLRewriter
{
    using System;

    [Serializable]
    public class RewriterRule
    {
        private string lookFor;
        private string sendTo;

        public string LookFor
        {
            get
            {
                return this.lookFor;
            }
            set
            {
                this.lookFor = value;
            }
        }

        public string SendTo
        {
            get
            {
                return this.sendTo;
            }
            set
            {
                this.sendTo = value;
            }
        }
    }
}

