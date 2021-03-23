using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Bars_Client.Model.Helper
{
    public class AddressHelper
    {
        private string ip { get; set; }
        private int port { get; set; }

        public AddressHelper(string ip,int port)
        {
            this.ip = ip;
            this.port = port;
        }
        public string Url
        {
            get => "http://" + ip + ":" +  port + "/" + "api" + "/" + "Contracts";
        }
    }
}
