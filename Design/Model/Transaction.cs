using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Model
{
    public class Transaction: BaseModel
    {
        
        public long Deposit { get; set; } = 0;
        public PlacePayment PlacePayment { get; set; } = PlacePayment.TrucTiep;
        public ModePayment ModePayment { get; set; } = ModePayment.TienMat;
        public DateTime DateOfTrans { get; set; } = DateTime.Now;
        public long paymentAmount { get; set; }
        public virtual ICollection<GameInTran> Games { get; set; }
        
    }
}
