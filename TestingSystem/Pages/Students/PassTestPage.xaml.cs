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
using System.Windows.Threading;
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
            TbCountPage.Text = listQuestion.Count().ToString();
            CheckParametrs(currentTest);
        }
        DispatcherTimer timer = new DispatcherTimer();
        List<Page> listPage = new List<Page>();

        public void CheckParametrs(Test test)
        {
            Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
            Parameters_Test parameters = db.Parameters_Test.Where(b => b.Id_Test == test.Id).FirstOrDefault();
            if (parameters.Sequence == false)
            {
                List<Page> newlistPage = new List<Page>();
                for (int i = 0; i < listPage.Count; i++)
                {
                    Random rnd = new Random();
                    int current = rnd.Next(listPage.Count);
                    newlistPage.Add(listPage[current]);
                    listPage.RemoveAt(current);
                }
                listPage = newlistPage;
            }
            if (parameters.AbilityReturn == false)
            {
                btnBack.IsEnabled = false;
            }
            if (parameters.TimeLimit != null)
            {
                gridTime.Visibility = Visibility.Visible;
                timeMin = (int)parameters.TimeLimit;
                timer.Tick += new EventHandler(dispatcherTimer_Tick);
                timer.Interval = new TimeSpan(0, 5, 0);
                timer.Start();
            }
        }

        int timeMin = 0;
        int timeSeconds = 0;

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (timeMin != 0)
            {
                if (timeSeconds != 0)
                {
                    timeSeconds--;
                }
                else
                {
                    timeMin--;
                    timeSeconds = 59;
                }
            }
            else
            {
                endTest();
                timer.Stop();
            }
        }

        private void BackPage_click(object sender, RoutedEventArgs e)
        {
            currentQuestion--;
            BtnNext.IsEnabled = true;
            frameQuestion.Navigate(listPage[currentQuestion]);
            if (currentQuestion == 0)
            {
                btnBack.IsEnabled = false;
            }
            TbCurrentPage.Text = (currentQuestion + 1).ToString();
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
            TbCurrentPage.Text = (currentQuestion + 1).ToString();
        }

        private void Exit_click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти", "Окно Вопроса",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                App.dataClass.Window.BackPage();
            }
        }

        private void EndTest_click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите завершить тест?", "Окно закрытия",
                             MessageBoxButton.YesNo,
                             MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                endTest();
            }
        }
        int countPoint = 0;

        public void endTest()
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
        public void CheckPage(OneAnswerQuestonPage page)
        {
            List<Viewbox> listViewbox = page.listViewbox;
            
            for (int i = 0; i < listViewbox.Count; i++)
            {
                RadioButton radioButton = listViewbox[i].Child as RadioButton;
                if (radioButton.IsChecked == true)
                {
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
