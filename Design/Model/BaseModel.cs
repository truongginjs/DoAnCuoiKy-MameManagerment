using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Design.Model
{
    public abstract class BaseModel
    {
        
      ////[Required]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string name { get; set; }
        public bool deleted { get; set; } = false;
    }
}
