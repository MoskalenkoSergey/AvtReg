using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtReg
{
    public partial class User
    {
        public string gender;
        public string Genders
        {
            get { return gender; }
            set { gender = value; }

        }

        public string role;
        public string Roles
        {
            get { return role; }
            set { role = value; }

        }
    }
    public class Users
    {
        public List<User> usr;
        public Users()
        {
            usr = newuser();
        }

        public List<User> newuser()
        {
            List<User> users = new List<User>();
            User buff;
            List<User> bdusers = DataBase.database.User.ToList();

            foreach (User user in bdusers)
            {
                buff = new User();
                buff.Id_user = user.Id_user;
                buff.Surname = user.Surname;
                buff.Name = user.Name;
                buff.Patronymic = user.Patronymic;
                buff.Login = user.Login;
                buff.Password = user.Password;
                buff.Id_gender = user.Id_gender;
                buff.Date_of_birth = user.Date_of_birth;
                buff.Id_role = user.Id_role;
                buff.Id_gender = user.Id_gender;
                Gender gender = DataBase.database.Gender.FirstOrDefault(x => x.Id_gender == buff.Id_gender);
                buff.gender = gender.Gender1;
                Role role = DataBase.database.Role.FirstOrDefault(x => x.Id_role == buff.Id_role);
                buff.role = role.Role1;
                users.Add(buff);
            }
            return users;
        }
    }
}