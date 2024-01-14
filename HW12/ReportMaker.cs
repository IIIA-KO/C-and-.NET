using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Reports
{
	public class ReportMaker
	{
		Func<string, string> MakeCaption;
		Func<string> BeginList, EndList;
		Func<string, string, string> MakeItem;
		Func<IEnumerable<double>, object> MakeStatistics;
		public string Caption { get; set; }
		
		public ReportMaker(Func<string, string> makeCap, Func<string> begList, Func<string> endList, Func<string, string, string> makeItem, string caption, Func<IEnumerable<double>, object> makeStat)
        {
			MakeCaption = makeCap;
			BeginList = begList;
			EndList = endList;
			MakeItem = makeItem;
			MakeStatistics = makeStat;
			Caption = caption;
        }

		public string MakeReport(IEnumerable<Measurement> mesurs)
        {
			IEnumerable<Measurement> data = mesurs.ToList();
			StringBuilder res = new StringBuilder();
			res.Append(MakeCaption(Caption));
			res.Append(BeginList());
            res.Append(MakeItem("Temperature", MakeStatistics(data.Select(z => z.Temperature)).ToString()));
            res.Append(MakeItem("Humidity", MakeStatistics(data.Select(z => z.Humidity)).ToString()));
			res.Append(EndList());
			return res.ToString();
        }
	}

	public static class ReportMakerHelper
	{
		private static object MakeMeanAndStdStatistics(IEnumerable<double> data)
		{
            List<double>? this_data = data.ToList();
            var mean = data.Average();
            var std = Math.Sqrt(this_data.Select(z => Math.Pow(z - mean, 2)).Sum() / (this_data.Count - 1));
            return new MeanAndStd
            {
                Mean = mean,
                Std = std
            };

        }
        private static object MakeMedianStaticstics(IEnumerable<double> data)
        {
            var list = data.OrderBy(z => z).ToList();
            if (list.Count % 2 == 0)
                return (list[list.Count / 2] + list[list.Count / 2 - 1]) / 2;
            return list[list.Count / 2];
        }


        public static string MeanAndStdHtmlReport(IEnumerable<Measurement> measurements)
        {
            return new ReportMaker(
                (caption) => $"<h1>{caption}</h1>",
                () => "<ul>",
                () => "</ul>",
                (valueType, entry) => $"<li><b>{valueType}</b>: {entry}",
                "Mean and Std",
                MakeMeanAndStdStatistics).MakeReport(measurements);
        }
        public static string MedianMarkdownReport(IEnumerable<Measurement> data)
        {
            return new ReportMaker(
               (caption) => $"## {caption}\n\n",
               () => "",
               () => "",
               (valueType, entry) => $" * **{valueType}**: {entry}\n\n",
               "Median",
               MakeMedianStaticstics).MakeReport(data);
        }
        public static string MeanAndStdMarkdownReport(IEnumerable<Measurement> measurements)
        {
            return new ReportMaker(
                (caption) => $"## {caption}\n\n",
                () => "",
                () => "",
                (valueType, entry) => $" * **{valueType}**: {entry}\n\n",
                "Mean and Std",
                MakeMeanAndStdStatistics).MakeReport(measurements);
        }
        public static string MedianHtmlReport(IEnumerable<Measurement> measurements)
		{
            return new ReportMaker(
                (caption) => $"<h1>{caption}</h1>",
                () => "<ul>",
                () => "</ul>",
                (valueType, entry) => $"<li><b>{valueType}</b>: {entry}",
                "Median",
                MakeMedianStaticstics).MakeReport(measurements);
        }
	}
}