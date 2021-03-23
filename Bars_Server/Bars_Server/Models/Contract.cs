using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bars_Server.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int Number { get; set; }
        public DateTime DataOfChange { get; set; }
    }
}
