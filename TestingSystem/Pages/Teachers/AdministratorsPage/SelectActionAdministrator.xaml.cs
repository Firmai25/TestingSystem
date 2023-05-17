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

namespace TestingSystem.Pages.Teachers.AdministratorsPage
{
    /// <summary>
    /// Логика взаимодействия для SelectActionAdministrator.xaml
    /// </summary>
    public partial class SelectActionAdministrator : Page
    {
        public SelectActionAdministrator()
        {
            InitializeComponent();
        }

        private void CreateUsers_Click(object sender, RoutedEventArgs e)
        {
            Windows.CreateUserWindows createUser = new Windows.CreateUserWindows();
            createUser.Owner = App.dataClass.Window;
            createUser.ShowDialog();
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            App.dataClass.Window.BackPage();
        }

        private void AllUsers_Click(object sender, RoutedEventArgs e)
        {
            App.dataClass.Window.NextPage(new AllUsersPage());
        }
    }
}
