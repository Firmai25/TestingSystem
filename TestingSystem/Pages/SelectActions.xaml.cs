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

namespace TestingSystem.Pages
{
    /// <summary>
    /// Логика взаимодействия для SelectActions.xaml
    /// </summary>
    public partial class SelectActions : Page
    {
        public SelectActions()
        {
            InitializeComponent();
        }

        private void OpenAllTests_Click(object sender, RoutedEventArgs e)
        {
            App.windowClass.Window.NextPage(new Pages.Students.AllTestsPage());
        }
    }
}
