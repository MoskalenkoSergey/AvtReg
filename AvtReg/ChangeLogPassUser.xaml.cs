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
using System.Xml.Linq;

namespace AvtReg
{
    /// <summary>
    /// Логика взаимодействия для ChangeLogPassUser.xaml
    /// </summary>
    public partial class ChangeLogPassUser : Page
    {
        public User listuser;
        public static int ID;
        public ChangeLogPassUser(int id)
        {
            InitializeComponent();
            listuser = DataBase.database.User.FirstOrDefault(x => x.Id_user == id);
            TBLogCh.Text = listuser.Login;
            ID = id;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            listuser.Login = TBLogCh.Text;
            listuser.Password = TBPassCh.Password.GetHashCode().ToString();
            DataBase.database.SaveChanges();
            MessageBox.Show("Изменения сохранены успешно!");
            NavigationService.Navigate(new UserMenu(ID));
        }
    }
}
