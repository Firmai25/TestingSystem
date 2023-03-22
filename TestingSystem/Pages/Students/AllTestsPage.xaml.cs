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

namespace TestingSystem.Pages.Students
{
    /// <summary>
    /// Логика взаимодействия для AllTestsPage.xaml
    /// </summary>
    public partial class AllTestsPage : Page
    {
        
        public AllTestsPage()
        {
            InitializeComponent();
            
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            App.windowClass.Window.BackPage();
        }
    }
}
