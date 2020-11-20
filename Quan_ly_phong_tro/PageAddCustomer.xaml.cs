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

namespace Quan_ly_phong_tro
{
    /// <summary>
    /// Interaction logic for PageAddCustomer.xaml
    /// </summary>
    public partial class PageAddCustomer : Page
    {
        public PageAddCustomer()
        {
            InitializeComponent();
            var room = GetAllRooms();
            if (room.Count > 0)
                ListNameRoom.ItemsSource = room;
           
        }

        public List<Room> GetAllRooms()
        {
            SQLiteConnection Connection = new SQLiteConnection(App.connecter);
            return Connection.Table<Room>().ToList();
        }

        private void checkedSexCustomer(object sender, RoutedEventArgs e)
        {
            // ... Get RadioButton reference.
            var button = sender as RadioButton;

            // ... Display button content as title.
            this.Title = button.Content.ToString();
        }

        private void insertCustomer(object sender, RoutedEventArgs e)
        {
            Room roomID = ListNameRoom.SelectedItem as Room;
           
            var checkValue= checkGender.Children.OfType<RadioButton>()
                 .FirstOrDefault(r => r.IsChecked.HasValue && r.IsChecked.Value);
            string s = checkValue.IsChecked==true ? "male" : "female";
            Customer customer = new Customer()
            {
                name = nameCustomer.Text,
                address = address.Text,
                birthYear = int.Parse(birth.Text),
                jobCustomer = job.Text,
                numberPhone1 = numphone1.Text,
                numberPhone2 = numphone2.Text,
                dateRent = dayRent.DisplayDate,
                room = roomID.idRoom,
                gender = s.ToString(),
                cmnd = cmnd.Text,
            };
            SQLiteConnection con = new SQLiteConnection(App.connecter);
            con.Insert(customer);
            //con.Close;
        }
    }
}
