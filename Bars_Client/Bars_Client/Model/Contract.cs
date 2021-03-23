using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows.Navigation;
using Bars_Client.Model.Helper;
using Newtonsoft.Json;

namespace Bars_Client.Model
{
    class Contract
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int Number { get; set; }
        public DateTime DataOfChange { get; set; }


        private AddressHelper addressHelper = new AddressHelper("localhost", 59357);
        public Contract GetContractById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>all contracts from server</returns>
        public List<Contract> GetContracts()
        {
            string url = addressHelper.Url;
            var data = HttpHelper.StreamGetter(url);
            if (data != null)
            {
                var contracts = JsonConvert.DeserializeObject<List<Contract>>(data);
                return contracts;
            }
            //if data is empty return new list 
            return new List<Contract>();
        }

        public Contract PostContract()
        {
            throw new NotImplementedException();
        }

        public Contract DeleteContract()
        {
            throw new NotImplementedException();
        }

        public Contract ChangeContract(Contract contract)
        {
            throw new NotImplementedException();
        }
    }
}