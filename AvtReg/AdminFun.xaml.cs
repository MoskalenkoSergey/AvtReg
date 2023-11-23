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
    /// Логика взаимодействия для AdminFun.xaml
    /// </summary>
    public partial class AdminFun : Page
    {
        Users users = new Users();
        public AdminFun()
        {
            InitializeComponent();
            All.ItemsSource = users.usr.ToList();
            gender.ItemsSource = DataBase.database.Gender.ToList();
            gender.SelectedValue = "Id-gender";
            gender.DisplayMemberPath = "Gender";
            gender.SelectedIndex = -1;
        }

        private void sortbig_Click(object sender, RoutedEventArgs e)
        {
            All.ItemsSource = users.usr.ToList().OrderBy(x => x.Surname).ToList();
        }

        private void sortsmall_Click(object sender, RoutedEventArgs e)
        {
            All.ItemsSource = users.usr.ToList().OrderBy(x => x.Surname).Reverse().ToList();
        }

        private void gender_Selected(object sender, RoutedEventArgs e)
        {
            if (gender.SelectedIndex == -1)
            {
                All.ItemsSource = users.usr.ToList();
            }
            else
            {
                All.ItemsSource = users.usr.ToList().Where(x => x.Id_gender == (gender.SelectedIndex + 1)).ToList();
            }
        }

        private void poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(poisk.Text))
            {
                All.ItemsSource = users.usr.ToList().Where(x => (x.Surname.ToLower().Contains(poisk.Text.ToLower())) || (x.Name.ToLower().Contains(poisk.Text.ToLower()))).ToList();
            }

        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            All.ItemsSource = users.usr.ToList();
        }

        private void glav_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Avtor());
        }
    }
}
