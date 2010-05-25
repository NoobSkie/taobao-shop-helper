using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPGatewayModels
{
    public class AlipayProviderType
    {
        string _number;

        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }
        string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }


        public AlipayProviderType(string number, string desc)
        {
            this.Number = number;
            this.Description = desc;
        }
    }
}
