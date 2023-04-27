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
        int currentQuestion = 0;
        List<Question> listQuestion;
        public PassTestPage(Test currentTest)
        {
            InitializeComponent();
            test = currentTest;
            Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
            listQuestion = db.Questions.Where(b => b.Id_Test == test.Id).ToList();
            for (int i = 0; i < listQuestion.Count; i++)
            {
                listPage.Add(new OneAnswerQuestonPage(listQuestion[i]));
            }
            frameQuestion.Navigate(listPage[0]);
        }

        List<Page> listPage = new List<Page>();

        private void BackPage_click(object sender, RoutedEventArgs e)
        {
            currentQuestion--;
            BtnNext.IsEnabled = true;
            frameQuestion.Navigate(listPage[currentQuestion]);
            if (currentQuestion == 0)
            {
                btnBack.IsEnabled = false;
            }
        }
   

        private void NextPage_click(object sender, RoutedEventArgs e)
        {
            currentQuestion++;
            btnBack.IsEnabled = true;
            frameQuestion.Navigate(listPage[currentQuestion]);
            if (currentQuestion == listQuestion.Count() - 1)
            {
                BtnNext.IsEnabled = false;
            }
        }

        private void Exit_click(object sender, RoutedEventArgs e)
        {

        }

        private void EndTest_click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите завершить тест?", "Окно закрытия",
                             MessageBoxButton.YesNo,
                             MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                countPoint = 0;
                for (int i = 0; i < listPage.Count; i++)
                {
                    var page = listPage[i];
                    if (page.Title == "OneAnswerQuestonPage")
                    {
                        OneAnswerQuestonPage oneAnswer = page as OneAnswerQuestonPage;
                        CheckPage(oneAnswer);
                    }
                }
                MessageBox.Show($"Количество баллов {countPoint}");
            }
        }
        int countPoint = 0;
        public void CheckPage(OneAnswerQuestonPage page)
        {
            List<Viewbox> listViewbox = page.listViewbox;
            
            for (int i = 0; i < listViewbox.Count; i++)
            {
                RadioButton radioButton = listViewbox[i].Child as RadioButton;
                if (radioButton.IsChecked == true)
                {
                    TextBlock textBlock = page.listTextBlock[i];
                    Answer answer = page.listAnswers[i];
                    if (answer.Correct == 1)
                    {
                        countPoint++;
                    }
                }
            }
            
        }
    }
}
