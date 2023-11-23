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

namespace AvtReg
{
    /// <summary>
    /// Логика взаимодействия для Avtor.xaml
    /// </summary>
    public partial class Avtor : Page
    {
        public Avtor()
        {
            InitializeComponent();
        }

        private void vhod_Click(object sender, RoutedEventArgs e)
        {
            string hashedPassword = password.Password.GetHashCode().ToString();
            User user = DataBase.database.User.FirstOrDefault(x => x.Login == login.Text && x.Password == hashedPassword);
            if (user != null)
            {
                if (user.Id_role == 1)
                {
                    NavigationService.Navigate(new AdminMenu());
                }
                if (user.Id_role == 2)
                {
                    NavigationService.Navigate(new UserMenu());
                }
            }
            else
            {
                MessageBox.Show("Такого аккаунта не существует! Попробуйте снова или зарегистрируйтесь.");
            }
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Reg());
        }
    }
}
