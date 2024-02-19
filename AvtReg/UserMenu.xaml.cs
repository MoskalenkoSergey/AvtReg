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
    /// Логика взаимодействия для UserMenu.xaml
    /// </summary>
    public partial class UserMenu : Page
    {
        public static int id = 0;
        public User listuser;
        public UserMenu(int ID)
        {
            InitializeComponent();
            List<Gender> gen = DataBase.database.Gender.ToList();
            id = ID;
            listuser = DataBase.database.User.FirstOrDefault(x => x.Id_user == id);
            TBNAME.Text = listuser.Name;
            TBSURNAME.Text = listuser.Surname;
            TBPATRONYMIC.Text = listuser.Patronymic;
            TBDATEOFBIR.Text = listuser.Date_of_birth.ToString();
            foreach (Gender gender in gen)
            {
                CBPOL.Items.Add(gender.Gender1);
            }
            foreach (Gender gender in gen)
            {
                if (listuser.Id_gender == gender.Id_gender)
                {
                    CBPOL.SelectedIndex = gender.Id_gender-1;
                }
            }
        }
        private void glav_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Avtor());
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            listuser.Name = TBNAME.Text;
            listuser.Surname = TBSURNAME.Text;
            listuser.Patronymic = TBPATRONYMIC.Text;
            listuser.Date_of_birth = Convert.ToDateTime(TBDATEOFBIR.Text);
            listuser.Id_gender = CBPOL.SelectedIndex+1;
            DataBase.database.SaveChanges();
            MessageBox.Show("Изменения сохранены успешно!");
        }

        private void logpass_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChangeLogPassUser(id));
        }
    }
}
