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
    /// Логика взаимодействия для AddAgents.xaml
    /// </summary>
    public partial class AddAgents : Page
    {
        public AddAgents()
        {
            InitializeComponent();
            List<Role_agent> list = DataBase.database.Role_agent.ToList();
            foreach (Role_agent role in list)
            {
                CBRole.Items.Add(role.Title_role_agent);
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Agent agent = new Agent();
            agent.Name_agent = TBName.Text;
            agent.Id_role_agent = CBRole.SelectedIndex + 1;
            agent.Discreption_agent = TBOpis.Text;
            DataBase.database.Agent.Add(agent);
            DataBase.database.SaveChanges();
            MessageBox.Show("Агент успешно добавлен");
            NavigationService.Navigate(new Agents());
        }
    }
}
