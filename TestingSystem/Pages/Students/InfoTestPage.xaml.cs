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
using static System.Net.Mime.MediaTypeNames;

namespace TestingSystem.Pages.Students
{
    /// <summary>
    /// Логика взаимодействия для InfoTestPage.xaml
    /// </summary>
    public partial class InfoTestPage : Page
    {

        Test test;
        public InfoTestPage(Test currentTest)
        {
            InitializeComponent();
            test = currentTest;
            DataContext = currentTest;
            Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
            Parameters_Test parameters = db.Parameters_Test.Where(b => b.Id_Test == currentTest.Id).FirstOrDefault();
            filling_in_parameters(parameters);
            
        }

        public void filling_in_parameters(Parameters_Test parameters)
        {
            if (parameters.Sequence == false)
            {
                rSequence.Text = "Случайно";
            }
            if (parameters.AbilityReturn == false)
            {
                rAbilityReturn.Text = "Не возможно";
            }
            if (parameters.TimeLimit != null)
            {
                rTimeLimit.Text = parameters.TimeLimit.ToString() + " минут";
            }
            if (parameters.NumberTortures != null)
            {
                rNumberTortures.Text = parameters.NumberTortures.ToString() + " попытки";
            }
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            App.windowClass.Window.BackPage();
        }

        private void StartTest_Click(object sender, RoutedEventArgs e)
        {
            App.windowClass.Window.NextPage(new PassTestPage(test));
        }
    }
}
