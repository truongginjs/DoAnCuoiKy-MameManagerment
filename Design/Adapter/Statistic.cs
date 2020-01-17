using Design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Adapter
{
    public abstract class Statistic
    {
        protected List<Transaction> Data { get; set; }

        protected Statistic(List<Transaction> Data)
        {
            this.Data = Data;
        }

        public abstract string[] GetLabels();
        public abstract List<double> GetListValue();
        public abstract Func<double, string> GetFormatter();
    }
}
