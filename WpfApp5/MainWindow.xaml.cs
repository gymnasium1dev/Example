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

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ExampleEntities db;
        public MainWindow()
        {
            InitializeComponent();
            db = new ExampleEntities();
        }

        private void Yet_Click(object sender, RoutedEventArgs e)
        {
            List<User_types> type_list = db.User_types.ToList();
            Console.WriteLine(type_list.Count);
        }

        private void printusers_Click(object sender, RoutedEventArgs e)
        {
            var alltypes = db.User_types;
            foreach (var element in alltypes)
            {
                Console.WriteLine($"ID: {element.id} TYPE: {element.title}"); 
            }
            
        }

        private void add_type_Click(object sender, RoutedEventArgs e)
        {
            string title = type_tytle.Text;
            User_types user_Type = new User_types();
            user_Type.title = title;
            db.User_types.Add(user_Type);
            db.SaveChanges();
 
        }

        private void Rules_Click(object sender, RoutedEventArgs e)
        {
            string rules = "first";
            User_Rules user_Rules = new User_Rules();
            user_Rules.title = rules;
            db.User_Rules.Add(user_Rules);
            db.SaveChanges();
        }

        private void Rules_View_Click(object sender, RoutedEventArgs e)
        {
            var alltypes = db.User_Rules;
            foreach (var element in alltypes)
            {
                Console.WriteLine($"ID: {element.id} TYPE: {element.title}");
            }
        }
    }
}
