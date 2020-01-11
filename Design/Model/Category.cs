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
        [Key]
        public long CategoryId { get; set; }
        string detail { get; set; }
        public ICollection<Game> games { get; set; }
    }
}
