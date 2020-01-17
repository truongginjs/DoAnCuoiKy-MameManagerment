using Design.Context;
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
        protected Request request;

        protected Statistic(List<Transaction> Data)
        {
            this.Data = Data;
            this.request = new PaymentRequest();
        }

        protected Statistic(Request request)
        {
            Data = Common.Instance.transactions.ToList<Transaction>();
            this.request = request;
        }

        public abstract string[] GetLabels();
        public abstract SeriesCollection GetListValue();
    }
}
