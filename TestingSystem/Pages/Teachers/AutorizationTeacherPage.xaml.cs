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

namespace TestingSystem.Pages.Teachers
{
    /// <summary>
    /// Логика взаимодействия для AutorizationTeacherPage.xaml
    /// </summary>
    public partial class AutorizationTeacherPage : Page
    {
        public AutorizationTeacherPage()
        {
            InitializeComponent();
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            App.windowClass.Window.BackPage();
        }
    }
}
