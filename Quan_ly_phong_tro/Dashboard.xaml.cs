using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;
using SQLite;
namespace Quan_ly_phong_tro
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();
            DataChart();
        }

        public void DataChart()
        {

            SQLiteConnection connection = new SQLiteConnection(App.connecter);
            List<Amount> cus = connection.Query<Amount>("select * from amount");
           // List<Amount> money = connection.Query<Amount>("select * from Money_Type");


            Dictionary<int, List<Amount>> MapAmount = new Dictionary<int, List<Amount>>();
            List<int> listKeyDate = new List<int>();
            foreach (var item in cus)
            {
                string dateString = item.date_create.Year.ToString() + item.date_create.Month.ToString("00");
                int list = int.Parse(dateString);
                listKeyDate.Add(list);
            }
            List<int> listKey = listKeyDate.Distinct().ToList();
            listKey.Sort();
            listKey.Reverse();
          
            foreach (var itemKey in listKey)
            {
                List<Amount> listAddAmount = new List<Amount>(); 
                foreach (var item in cus)
                {
                    string dateString = item.date_create.Year.ToString() + item.date_create.Month.ToString("00");
                    int dateCus = int.Parse(dateString);
                    if (itemKey == dateCus)
                    {
                        listAddAmount.Add(item);
                    }              
                }
                MapAmount.Add(itemKey, listAddAmount);
            }

            List<int> listDien = new List<int>();
            List<int> listNuoc = new List<int>();
            List<int> listPhong = new List<int>();

            foreach (var item in MapAmount)
            {
                int sumDien = 0;
                int sumNuoc = 0;
                int sumPhong = 0;
               
                foreach (var itemAmount in item.Value)
                {
                    sumDien = sumDien + itemAmount.dien;
                    sumNuoc = sumNuoc + itemAmount.nuoc;
                    sumPhong = sumPhong + itemAmount.phong;
                }
                listDien.Add(sumDien*3000);
                listNuoc.Add(sumNuoc*15000);
                listPhong.Add(sumPhong*1000000);

            }

            SeriesCollection = new SeriesCollection
            {

            new LineSeries
                {
                    Title = "Tiền nhà",

                    Values = new ChartValues<int>(listDien),
                },
            new LineSeries
            {
                Title = "Tiền Nuoc",
                Values = new ChartValues<int> (listNuoc),
            },
                new LineSeries
                {
                    Title = "Tiền Phong",
                    Values = new ChartValues<int> (listPhong),
                }

            };


        Labels = new[] { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5" };
            YFormatter = value => value.ToString("C");
            DataContext = this;
        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
    }

       
    }
    
    