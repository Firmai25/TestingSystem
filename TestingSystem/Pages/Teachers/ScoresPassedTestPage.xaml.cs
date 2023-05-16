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

namespace TestingSystem.Pages.Teachers
{
    /// <summary>
    /// Логика взаимодействия для ScoresPassedTestPage.xaml
    /// </summary>
    public partial class ScoresPassedTestPage : Page
    {
        public ScoresPassedTestPage(Test test)
        {
            InitializeComponent();
            Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
            lvScore.ItemsSource = db.Ratings.Where(b => b.Id_Test == test.Id).ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            App.dataClass.Window.BackPage();
        }
    }
}
