using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Design.Model
{
    public class Game : BaseModel
    {
        public string Detail { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public long PurchaseCost { get; set; }
        [Required]
        public long SaleCost { get; set; }
        public virtual Category Category { get; set; }
    }
}
