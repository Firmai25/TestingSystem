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
using TestingSystem.Pages.Students.QuestionPage;

namespace TestingSystem.Pages.Students
{
    /// <summary>
    /// Логика взаимодействия для PassTestPage.xaml
    /// </summary>
    public partial class PassTestPage : Page
    {
        Test test;
        public PassTestPage(Test currentTest)
        {
            InitializeComponent();
            test = currentTest;
            Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
            List<Question> listQuestion = db.Questions.Where(b => b.Id_Test == test.Id).ToList();
            for (int i = 0; i < listQuestion.Count; i++)
            {
                listPage.Add(new OneAnswerQuestonPage(listQuestion[i]));
            }
            frameQuestion.Navigate(listPage[0]);
        }

        List<Page> listPage = new List<Page>();

        private void BackPage_click(object sender, RoutedEventArgs e)
        {

        }

        private void NextPage_click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_click(object sender, RoutedEventArgs e)
        {

        }

        private void EndTest_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
