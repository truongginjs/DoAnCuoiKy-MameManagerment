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
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Deleted { get; set; } = false;
        //public abstract object this[string attribute] { get; set; }
    }
}

