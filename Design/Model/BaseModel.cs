using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Design.Model
{
    public abstract class BaseModel
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
        public bool Deleted { get; set; }
    }
}
