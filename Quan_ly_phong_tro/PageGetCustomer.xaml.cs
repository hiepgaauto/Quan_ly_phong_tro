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
using Quan_ly_phong_tro.Model;
using SQLite;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
namespace Quan_ly_phong_tro
{
    /// <summary>
    /// Interaction logic for PageGetCustomer.xaml
    /// </summary>
    public partial class PageGetCustomer : Page
    {
        public ObservableCollection<Customer> MyCollection { get; set; }

        public PageGetCustomer()
        {
            InitializeComponent();
            var customers = GetAllCustomers();
            if (customers.Count > 0)
                ListViewCustomer.ItemsSource = customers;
        }

        public List<Customer> GetAllCustomers()
        {
            SQLiteConnection Connection = new SQLiteConnection(App.connecter);
            return Connection.Table<Customer>().ToList();
        }

    }
}
