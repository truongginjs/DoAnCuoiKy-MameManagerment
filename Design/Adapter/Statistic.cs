using Design.Model;
using LiveCharts;
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

        public abstract List<string> GetLabels();
        public abstract ChartValues<double> GetListValue();
        public abstract Func<double, string> GetFormatter();
    }
}
