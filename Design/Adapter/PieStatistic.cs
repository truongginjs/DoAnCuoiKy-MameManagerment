using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Adapter
{
    public class PieStatistic: Statistic
    {
        public override Func<double, string> GetFormatter()
        {
            throw new NotImplementedException();
        }

        public override string[] GetLabels()
        {
            throw new NotImplementedException();
        }

        public override List<double> GetListValue()
        {
            throw new NotImplementedException();
        }
    }
}
