using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
                if (listQuestion[i].id_type == 1)
                {
                    listPages.Add(new OneAnswerQuestonPage(listQuestion[i]));
                }
                if (listQuestion[i].id_type == 2)
                {
                    listPages.Add(new MultipleAnswersQuestionPage(listQuestion[i]));
                }
            }
            if (listQuestion.Count == 1)
            {
                BtnNext.IsEnabled = false;
            }
            frameQuestion.Navigate(listPages[0]);
            TbCountPage.Text = listQuestion.Count().ToString();
            CheckParametrs(currentTest);
        }

        DispatcherTimer timer = new DispatcherTimer();
        bool timerActual = false;
        List<Page> listPages = new List<Page>();
        bool backActual = true;
        
        public void CheckParametrs(Test test)
        {
            Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
            Parameters_Test parameters = db.Parameters_Test.Where(b => b.Id_Test == test.Id).FirstOrDefault();
            if (parameters.Sequence == false)
            {
                int count = listPages.Count;
                List<Page> newlistPage = new List<Page>();
                for (int i = 0; i < count; i++)
                {
                    Random rnd = new Random();
                    int current = rnd.Next(listPages.Count);
                    newlistPage.Add(listPages[current]);
                    listPages.RemoveAt(current);
                }
                listPages = newlistPage;
                frameQuestion.Navigate(listPages[0]);
            }
            if (parameters.AbilityReturn == false)
            {
                btnBack.IsEnabled = false;
                backActual = false;
            }
            if (parameters.TimeLimit != null)
            {
                gridTime.Visibility = Visibility.Visible;
                timeMin = (int)parameters.TimeLimit;
                timer.Tick += new EventHandler(dispatcherTimer_Tick);
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Start();
                tbTime.Text = $"{parameters.TimeLimit} минут 0 секунд";
                timerActual = true;
            }
        }

        int timeMin = 0;
        int timeSeconds = 0;

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (timeMin >= 0)
            {
                if (timeSeconds != 0)
                {
                    timeSeconds--;
                    tbTime.Text = $"{timeMin} минут {timeSeconds} секунд";
                }
                else
                {
                    timeMin--;
                    timeSeconds = 59;
                    tbTime.Text = $"{timeMin} минут {timeSeconds} секунд";
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
            countTransitions++;
            currentQuestion--;
            BtnNext.IsEnabled = true;
            frameQuestion.Navigate(listPages[currentQuestion]);
            if (currentQuestion == 0)
            {
                btnBack.IsEnabled = false;
            }
            TbCurrentPage.Text = (currentQuestion + 1).ToString();
        }
   

        private void NextPage_click(object sender, RoutedEventArgs e)
        {
            countTransitions++;
            currentQuestion++;
            if (backActual)
            {
                btnBack.IsEnabled = true;
            }           
            frameQuestion.Navigate(listPages[currentQuestion]);
            if (currentQuestion == listQuestion.Count() - 1)
            {
                BtnNext.IsEnabled = false;
            }
            TbCurrentPage.Text = (currentQuestion + 1).ToString();
        }
        int countTransitions = 0;
        private void Exit_click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти", "Окно Вопроса",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (timerActual)
                {
                    timer.Stop();
                }
                for (int i = 0; i < countTransitions; i++)
                {
                    App.dataClass.Window.MainFrame.RemoveBackEntry();
                }                
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
                if (timerActual)
                {
                    timer.Stop();
                }
                endTest();
            }
        }
        double countPoint = 0;

        public void endTest()
        {
            countPoint = 0;
            for (int i = 0; i < listPages.Count; i++)
            {
                var page = listPages[i];
                if (page.Title == "OneAnswerQuestonPage")
                {
                    OneAnswerQuestonPage oneAnswer = page as OneAnswerQuestonPage;
                    CheckOnePage(oneAnswer);
                }
                if (page.Title == "MultipleAnswersQuestionPage")
                {
                    MultipleAnswersQuestionPage multipleAnswers = page as MultipleAnswersQuestionPage;
                    CheckMultiplePage(multipleAnswers);
                }
            }
            MessageBox.Show($"Количество баллов {countPoint}");
            Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
            Rating rating = db.Ratings.Where(b=> b.Id == App.dataClass.Rating.Id).FirstOrDefault();
            rating.Scores = countPoint;
            db.SaveChanges();
            for (int i = 0; i < countTransitions; i++)
            {
                App.dataClass.Window.MainFrame.RemoveBackEntry();
            }
            App.dataClass.Window.BackPage();
        }
        public void CheckOnePage(OneAnswerQuestonPage page)
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
        public void CheckMultiplePage(MultipleAnswersQuestionPage page)
        {
            List<Viewbox> listViewbox = page.listViewbox;
            double countMax = 0;
            double countCurrect = 0;
            for (int i = 0; i < listViewbox.Count; i++)
            {
                Answer answer = page.listAnswers[i];
                CheckBox checkBox = listViewbox[i].Child as CheckBox;
                if (answer.Correct == 1)
                {
                    countMax++;
                }
                if (checkBox.IsChecked == true)
                {
                    
                    if (answer.Correct == 1)
                    {
                        countCurrect++;
                    }
                }
            }
            countPoint = countPoint + (countCurrect / countMax);
            
        }
    }
}
