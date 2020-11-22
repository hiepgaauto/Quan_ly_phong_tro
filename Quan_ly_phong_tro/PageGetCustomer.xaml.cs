using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Quan_ly_phong_tro
{
    /// <summary>
    /// Interaction logic for PageGetCustomer.xaml
    /// </summary>
    public partial class PageGetCustomer : Page, INotifyPropertyChanged
    {
        
        public PageGetCustomer()
        {
            InitializeComponent();
            var customers = GetAllCustomers();
            if (customers.Count > 0)
                ListViewCustomer.ItemsSource = customers;
            DataContext = this;

        }
        static string idSelect;
        private bool m_isShow;
        public bool IsShow
        {
            get { return m_isShow; }
            set { m_isShow = value; OnPropertyChanged(); }
        }

        private object m_dialogObject;

        public List<Customer> GetAllCustomers()
        {
            SQLiteConnection Connection = new SQLiteConnection(App.connecter);
            return Connection.Table<Customer>().ToList();
        }

        public object DialogObject
        {
            get { return m_dialogObject; }
            set
            {
                if (m_dialogObject == value) return;
                m_dialogObject = value; OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }
        
        private void ClickGetCustomer(object sender, RoutedEventArgs e)
        {
          
            Button button = (Button)sender;
            idSelect = button.Tag.ToString();
            DialogObject = new DialogCustomer("Exception initializing.", idSelect);

            IsShow = !IsShow;
        }
    }
}
