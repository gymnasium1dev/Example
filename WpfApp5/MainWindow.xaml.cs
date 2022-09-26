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

        private void Add_new_user_Click(object sender, RoutedEventArgs e)
        {
            Users user = new Users();
            user.user_name = User_Name.Text;
            user.password = "123";
            user.type_id = 1;
            user.rules_id = 1;
            user.User_Rules = db.User_Rules.ToList()[0];
            db.Users.Add(user);
            db.SaveChanges();
            MessageBox.Show("Успешно!");
        }

        private void Print_Users_Click(object sender, RoutedEventArgs e)
        {
            List<Users> users = db.Users.ToList();
            foreach (var element in users)
            {
                Console.WriteLine($"ID: {element.id} NAme: {element.user_name} {element.User_Rules.title}");
            }
        }

        private void Get_User_Rule_Click(object sender, RoutedEventArgs e)
        {
            Users user = db.Users.First();
            User_Rules rool = db.User_Rules.Where((element)=> element.id == user.rules_id).First();
            User_Rule.Content = $"{user.user_name} {rool.title}";
        }

        private void Get2_Click(object sender, RoutedEventArgs e)
        {
            Users user = db.Users.First();
            List<User_types> types = db.User_types.ToList();
            for (int i = 0; i<types.Count; i++ )
            {
                if(user.type_id == types[i].id)
                {
                    forse.Content = $"{user.user_name} {types[i].title}";
                }

            }
        }

        private void pirint_Click(object sender, RoutedEventArgs e)
        {
            Users user = db.Users.First();
            List<User_types> types = db.User_types.ToList();
            for (int i = 0; i < types.Count; i++)
            {
                if (user.type_id == types[i].id)
                { 
                    Console.WriteLine($"{user.user_name}");                    
                }

            }
        }

        private void Get_Rool_Click(object sender, RoutedEventArgs e)
        {
            Users user = db.Users.First();
            List<User_types> types = db.User_types.ToList();

        }
    }
}
