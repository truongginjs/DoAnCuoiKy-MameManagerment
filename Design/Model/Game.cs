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
        public string detail { get; set; }
        [Required]
        public int amount { get; set; }
        [Required]
        public string publisher { get; set; }
        public Category category { get; set; }
        [Required]
        public long purchaseCost { get; set; }
        [Required]
        public long SaleCost { get; set; }
    }
}
