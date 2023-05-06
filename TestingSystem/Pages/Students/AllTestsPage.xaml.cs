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
using TestingSystem.Entities;

namespace TestingSystem.Pages.Students
{
    /// <summary>
    /// Логика взаимодействия для AllTestsPage.xaml
    /// </summary>
    public partial class AllTestsPage : Page
    {
        Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
        public AllTestsPage()
        {
            InitializeComponent();
            lvAllTests.ItemsSource = db.Tests.ToList();
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            App.dataClass.Window.BackPage();
        }

        private void lvAllTests_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvAllTests.SelectedIndex != -1)
            {
                Test test = lvAllTests.SelectedItem as Test;
                App.dataClass.Window.NextPage(new InfoTestPage(test));
            }
        }
    }
}
