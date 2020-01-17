using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design.Model;

namespace Design.Adapter
{
    public class PieStatistic: Statistic
    {
        public PieStatistic(List<Transaction> Data) : base(Data)
        {
        }

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
