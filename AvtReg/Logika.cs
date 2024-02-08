using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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
    public partial class Agent
    {
        public string roleagent;
        public string RoleAgent
        {
            get { return roleagent; }
            set { roleagent = value; }
        }

        public string skillsagent;
        public string SkillsAgent
        {
            get { return skillsagent.Remove(skillsagent.Length - 2); }
            set { skillsagent = value; }
        }

        public int priceskills;
        public string PriceSkills
        {
            get { return Convert.ToString(priceskills); }
            set { priceskills = Convert.ToInt32(value); }
        }

        public bool Color { get => Convert.ToInt32(PriceSkills) >= 500; }
        public SolidColorBrush BGColor
        {
            get
            {
                if (Color)
                {
                    return Brushes.Blue;
                }
                else
                {
                    return Brushes.White;
                }

            }
        }

        public class Person
        {
            public List<Agent> agent;
            public Person()
            {
                agent = newagent();
            }

            public List<Agent> newagent()
            {
                List<Agent> agents = new List<Agent>();
                Agent buff;
                List<Agent> bduagents = DataBase.database.Agent.ToList();
                List<Agent_Skills> bdagentskills = DataBase.database.Agent_Skills.ToList();
                List<Skills> bdskills = DataBase.database.Skills.ToList();
                List<Price_skills> bdpriceskills = DataBase.database.Price_skills.ToList();

                foreach (Agent agent in bduagents)
                {
                    buff = new Agent();
                    buff.Id_agent = agent.Id_agent;
                    buff.Name_agent = agent.Name_agent;
                    buff.Id_role_agent = agent.Id_role_agent;
                    Role_agent role = DataBase.database.Role_agent.FirstOrDefault(x => x.Id_role_agent == buff.Id_role_agent);
                    buff.Discreption_agent = agent.Discreption_agent;

                    string allagents = "";
                    int allskills = 0;
                    foreach (Agent_Skills agent_Skills in bdagentskills)
                    {
                        if (agent.Id_agent == agent_Skills.Id_agent)
                        {
                            foreach (Skills skillsagent in bdskills)
                            {
                                if (agent_Skills.Id_skills == skillsagent.Id_skills)
                                {
                                    foreach (Price_skills priceskills in bdpriceskills)
                                    {
                                        if (skillsagent.Id_price_skills == priceskills.Id_price_skills)
                                        {
                                            allskills += priceskills.Price_skills1;
                                        }
                                    }
                                    allagents += skillsagent.Title_skills + ", ";
                                    agent.skillsagent = allagents;
                                    agent.priceskills = allskills;
                                    break;
                                }
                            }
                        }

                    }
                    buff.priceskills = agent.priceskills;
                    buff.skillsagent = agent.skillsagent;
                    buff.roleagent = role.Title_role_agent;
                    agents.Add(buff);
                }
                return agents;
            }
        }
    }
}