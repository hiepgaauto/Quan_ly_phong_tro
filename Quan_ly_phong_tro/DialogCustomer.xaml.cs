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
using SQLite;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
namespace Quan_ly_phong_tro
{
    /// <summary>
    /// Interaction logic for DialogCustomer.xaml
    /// </summary>
    public partial class DialogCustomer : UserControl
    {
        public DialogCustomer(string message, string title)
        {
            InitializeComponent();
            InitializeGUI(message, title, ButtonType.OK);
            getCustomer(title);
        }
        public enum ButtonType { OK, CancelOK, NoYes };

        private void InitializeGUI(string message, string title, ButtonType buttonType)
        {

            switch (buttonType)
            {
                case ButtonType.OK:
                    ButtonTrue.Content = "OK";
                    ButtonFalse.Content = null;
                    ButtonFalse.Visibility = Visibility.Hidden;
                    break;
                case ButtonType.CancelOK:
                    ButtonTrue.Content = "OK";
                    ButtonFalse.Content = "CANCEL";
                    break;
                case ButtonType.NoYes:
                    ButtonTrue.Content = "YES";
                    ButtonFalse.Content = "NO";
                    break;
            }
        }

        public void getCustomer(string cmnd)
        {

            SQLiteConnection Connection = new SQLiteConnection(App.connecter);

            List<Customer> cus = Connection.Query<Customer>("select * from customer where cmnd = " + cmnd);
            getcustomer.ItemsSource = cus;
            DataContext = this;
        }
 

    }
}
