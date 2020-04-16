using LiveChartInterface.Model;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace LiveChartInterface.ViewModel
{
    public class RawDataPointsVM
    {
        private readonly string XMLPATH = @"C:\Users\manohar\Desktop\Haier\NEW\LiveChartInterface\LiveChartInterface\GraphConfig.xml";
        public SeriesCollection SeriesCollection { get; set; }
        public Func<double, string> XFormatter { get; set; }
        public Func<double, string> YFormatter { get; set; }



        public RawDataPointsVM()
        {

            LoadChart();
        }




        private void LoadChart()
        {
            SeriesCollection = GetData();

        }

        private SeriesCollection GetData()
        {

            SeriesCollection seriesViews = new SeriesCollection();
            var rawdata = Xml.Deserialize<RawDataPoints>(XMLPATH, "RawDataPoints");

            //var graphs = Xml.Deserialize<Graphs>(XMLPATH, "Graphs");


            var gradientBrush = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(0, 1)
            };
            gradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(33, 148, 241), 0));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Transparent, 1));
            foreach (var dataPoint in rawdata)
            {

                var lineSeries = new LineSeries
                {
                    Values = new ChartValues<Double>(dataPoint.SampleData),
                     Fill = gradientBrush,
                    StrokeThickness = 1,
                    PointGeometrySize = 0,
                    ToolTip = dataPoint.Key
                };
                seriesViews.Add(lineSeries);
            }
            return seriesViews;
        }

        private Color GetColor(string colorName)
        {
            if (colorName == "Yellow")
                return Colors.Yellow;
            else if (colorName == "Red")
            {
                return Colors.Red;
            }

            return Colors.Transparent;
        }


    }
}
