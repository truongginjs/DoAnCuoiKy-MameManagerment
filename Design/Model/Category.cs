using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Model
{
    public class Category: BaseModel
    {
        public string Detail { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
