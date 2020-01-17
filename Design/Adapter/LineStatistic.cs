using Design.Model;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Adapter
{
    public class LineStatistic: Statistic
    {
        private Dictionary<DateTime,long> datas;
        public LineStatistic(List<Transaction> Data): base(Data)
        {
        }
        public LineStatistic(Request request) : base(request)
        {
            if(request is AmountRequest)
            {
                datas = Data.OrderBy(t => t.DateOfTrans).GroupBy(t => t.DateOfTrans.Date).Select(t2 => new { date = t2.Key, amount = t2.Sum(s => s.Games.Select(g => g.Amount).Sum()) }).ToDictionary(a => a.date, a => Convert.ToInt64(a.amount));
            }
            else
            {
                datas = Data.OrderBy(t => t.DateOfTrans).GroupBy(t => t.DateOfTrans.Date).Select(g => new { date = g.Key,  payment = g.Sum(s => s.paymentAmount) }).ToDictionary(a=>a.date,a=>a.payment);
            }
        }
        public override string[] GetLabels()
        {
            List<string> result = new List<string>();
            foreach(var data in datas)
            {
                result.Add(data.Key.ToShortDateString());
            }
            return result.ToArray();
        }

        public override SeriesCollection GetListValue()
        {
            return new SeriesCollection
            {

                new LineSeries
                {
                    Title = "doanh thu",
                    Values = GetDataPayment(),
                    DataLabels = true,
                },

            };
        }

        private IChartValues GetDataPayment()
        {
            ChartValues<long> result = new ChartValues<long>();
            foreach(var data in datas)
            {
                result.Add(data.Value);
            }
            return result;
        }
    }
}
