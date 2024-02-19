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
using static AvtReg.Agent;

namespace AvtReg
{
    /// <summary>
    /// Логика взаимодействия для Agents.xaml
    /// </summary>
    public partial class Agents : Page
    {
        Person agent = new Person();
        public Agents()
        {
            InitializeComponent();
            AgentValorant.ItemsSource = agent.agent.ToList();
            Filter.Items.Add("Все записи");
            List<Role_agent> roleagent = DataBase.database.Role_agent.ToList();
            foreach(Role_agent roles in roleagent)
            {
                Filter.Items.Add(roles.Title_role_agent);
            }
            Filter.SelectedIndex = 0;
        }

        void Filtration()
        {
            List<Agent> lagent = new List<Agent>();
            int Id = Filter.SelectedIndex;
            string type = Filter.SelectedValue.ToString();
            if (Id != 0)
            {
                lagent = DataBase.database.Agent.Where(x => x.Id_role_agent == Id).ToList();
            }
            else
            {
                lagent = DataBase.database.Agent.ToList();
            }
            if (!string.IsNullOrWhiteSpace(Poisk.Text))
            {
                lagent = DataBase.database.Agent.Where(x => x.Name_agent.ToLower().Contains(Poisk.Text.ToLower())).ToList();
            }
            AgentValorant.ItemsSource = lagent;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminMenu());
        }

        private void addagent_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddAgents());
        }

        private void Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filtration();
        }

        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filtration();
        }
    }
}
