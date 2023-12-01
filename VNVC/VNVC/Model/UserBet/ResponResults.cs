using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNVC.Model.UserBet
{
    public class ResponResults
    {
        public DateTime DateBet { get; set; }
        public string HourSlot { get; set; }
        public string NumberBet { get; set; }
        public int MoneyBet { get; set; }
        public string Results { get; set; }      
    }
}
