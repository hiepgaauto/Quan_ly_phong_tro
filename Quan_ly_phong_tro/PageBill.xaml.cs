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
using Quan_ly_phong_tro.Model;
namespace Quan_ly_phong_tro
{
    /// <summary>
    /// Interaction logic for PageBill.xaml
    /// </summary>
    public partial class PageBill : Page
    {
        public PageBill()
        {
            InitializeComponent();
            var bill = GetListBill();
            if (bill.Count > 0)
                ListBill.ItemsSource = bill;
            DataContext = this;
        }

        public List<Bill> GetListBill()
        {
            List<Bill> listBill = new List<Bill>();
            SQLiteConnection connection = new SQLiteConnection(App.connecter);
            var type = connection.Query<Money_Type>("select * from Money_type");
            var amount= connection.Query<Amount>("select * from Amount");

            var nha = type.Where(a => a.type.Equals("tien nha")).First().price;
            var dien = type.Where(a => a.type.Equals("tien dien")).First().price;
            var nuoc = type.Where(a => a.type.Equals("tien nuoc")).First().price;

            foreach (var item in amount)
            {
                Bill bill = new Bill();
                bill.phong = item.name_room;
                bill.SoPhong = item.phong;
                bill.soDien = item.dien;
                bill.soNuoc = item.nuoc;
                bill.soNuoc = item.nuoc;
                bill.tienDien = item.dien * dien;
                bill.tienNuoc = item.nuoc * nuoc;
                bill.tienPhong = item.phong * nha;
                bill.sum = item.dien * dien + item.nuoc * nuoc + item.phong * nha;
                listBill.Add(bill);
            }

            return listBill;
        }
    }
}
