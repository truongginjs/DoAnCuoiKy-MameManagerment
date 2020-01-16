using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Model
{
    public class GameInTran: BaseModel
    {
        public virtual Game Game { get; set; }
        public int Amount { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
