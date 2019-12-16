using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Model
{
    public class Transaction: BaseModel
    {
        public Dictionary<Game,int> game { get; set; }
        public int amount { get; set; }
        public int deposit { get; set; }
        public PlacePayment placePayment  { get; set; }
        public ModePayment modePayment  { get; set; }
        public DateTime dateOfTrans { get; set; }
    }
}
