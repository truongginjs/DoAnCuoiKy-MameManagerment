using Design.Model;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Adapter
{
    public class LineStatistic: Statistic
    {
        public LineStatistic(List<Transaction> Data): base(Data)
        {
        }
        public override Func<double, string> GetFormatter()
        {
            return value => value.ToString();
        }

        public override List<string> GetLabels()
        {
            throw new NotImplementedException();
        }

        public override ChartValues<double> GetListValue()
        {
            
            return null;
        }
    }
}
