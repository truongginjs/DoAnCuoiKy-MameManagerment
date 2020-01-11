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
        [Key]
        public long id { get; set; }
        [Required]
        public Dictionary<Game,int> games { get; set; }
        public long deposit { get; set; } = 0;
        public PlacePayment placePayment { get; set; } = PlacePayment.TrucTiep;
        public ModePayment modePayment { get; set; } = ModePayment.TienMat;
        public DateTime dateOfTrans { get; set; } = DateTime.Now;
    }
}
