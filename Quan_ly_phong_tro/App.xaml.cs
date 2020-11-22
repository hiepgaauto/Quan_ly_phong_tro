using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace Quan_ly_phong_tro
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string s = System.IO.Directory.GetCurrentDirectory().ToString();

        public static string connecter = "C:\\Users\\Hoang Hiep\\Desktop\\Github\\Quan_ly_phong_tro\\Quan_ly_phong_tro\\Database\\phong_tro.db";
    }
}
