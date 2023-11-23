using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        public Reg()
        {
            InitializeComponent();
            gender.ItemsSource = DataBase.database.Gender.ToList();
            gender.SelectedValue = "Id_gender";
            gender.DisplayMemberPath = "Gender1";

            role.ItemsSource = DataBase.database.Role.ToList();
            role.SelectedValue = "Id_role";
            role.DisplayMemberPath = "Role1";
            role.SelectedIndex = 1;
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            User user = DataBase.database.User.FirstOrDefault(x => x.Login == login.Text);
            string Surname = surname.Text.Trim();
            string Name = name.Text.Trim();
            string Patronymic = patronymic.Text.Trim();
            string Login = login.Text.Trim();
            string Password = password.Password.Trim();
            string Gender = gender.Text.Trim();
            var DateOfBirthday = Convert.ToDateTime(dob.SelectedDate);
            string Role = role.Text.Trim();

            Regex pass1 = new Regex("[A-Z]");
            Regex pass2 = new Regex("[a-z]");
            Regex pass3 = new Regex("[0-9]");
            Regex pass4 = new Regex(@"[!@#$%^&*()_+{}\[\]:;<>,.?~\\-]");
            Regex pass5 = new Regex(".");

            if (pass1.IsMatch(password.Password) == false)
            {
                password.ToolTip = "Ошибка ввода";
                password.Background = Brushes.Aqua;
                MessageBox.Show("Пароль должен содержать не менее 1 заглавной латиской буквы");
            }
            else if (pass2.Matches(password.Password).Count < 3)
            {
                password.ToolTip = "Ошибка ввода";
                password.Background = Brushes.Aqua;
                MessageBox.Show("Пароль должен содержать не менее 3 прописных латинских букв");
            }
            else if (pass3.Matches(password.Password).Count < 2)
            {
                password.ToolTip = "Ошибка ввода";
                password.Background = Brushes.Aqua;
                MessageBox.Show("Пароль должен содержать не менее 2 цифр");
            }
            else if (pass4.IsMatch(password.Password) == false)
            {
                password.ToolTip = "Ошибка ввода";
                password.Background = Brushes.Aqua;
                MessageBox.Show("Пароль должен содержать не менее 1 спецсимвол");
            }
            else if (pass5.Matches(password.Password).Count < 8)
            {
                password.ToolTip = "Ошибка ввода";
                password.Background = Brushes.Aqua;
                MessageBox.Show("Пароль должен содержать не менее 8 символов");
            }
            else if (user != null)
            {
                MessageBox.Show("Пользователь с таким логином уже существует.");
                login.ToolTip = "Ошибка ввода";
                login.Background = Brushes.Aqua;
            }
            else if (true)
            {
                try
                {
                    password.ToolTip = "";
                    password.Background = Brushes.Transparent;
                    login.ToolTip = "";
                    login.Background = Brushes.Transparent;
                    User newUser = new User()
                    {
                        Surname = surname.Text,
                        Name = name.Text,
                        Patronymic = patronymic.Text,
                        Login = login.Text,
                        Password = password.Password.GetHashCode().ToString(),
                        Id_gender = gender.SelectedIndex + 1,
                        Date_of_birth = Convert.ToDateTime(dob.Text),
                        Id_role = role.SelectedIndex + 1,
                    };
                    DataBase.database.User.Add(newUser);
                    DataBase.database.SaveChanges();
                    MessageBox.Show("Вы зарегистрировались!");
                    NavigationService.Navigate(new UserMenu());
                }
                catch
                {
                    MessageBox.Show("Проверьте заполнение всех полей!");
                }
            }
        }
        private void glav_Click(object sender, RoutedEventArgs e)
        {
              NavigationService.Navigate(new Avtor());
        }
    }
}
