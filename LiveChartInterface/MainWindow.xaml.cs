using LiveChartInterface.ViewModel;
using System.Windows;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.Windows.Media;
using System;

namespace LiveChartInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RawDataPointsVM rawDataPointsVM;
      
        public MainWindow()
        {
            InitializeComponent();
            rawDataPointsVM = new RawDataPointsVM();
            this.DataContext = rawDataPointsVM;
        }

      

        
    }


}

