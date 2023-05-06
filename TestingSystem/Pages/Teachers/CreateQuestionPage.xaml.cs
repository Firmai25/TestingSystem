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
using TestingSystem.Pages.Teachers.QuestionPage;
using static System.Net.Mime.MediaTypeNames;

namespace TestingSystem.Pages.Teachers
{
    /// <summary>
    /// Логика взаимодействия для CreateQuestionPage.xaml
    /// </summary>
    public partial class CreateQuestionPage : Page
    {
        Test test;
        public CreateQuestionPage(Test currentTest, bool edit)
        {
            InitializeComponent();
            test = currentTest;
            if (!edit)
            {
                Create();
            }
            else
            {
                Edit();
            }
            
        }
        public void Create()
        {
            listPages.Add(new OneAnswerQuestonPage());
            frameQuestion.Navigate(listPages[currentPage]);
            TbCurrentPage.Text = (currentPage + 1).ToString();
            TbCountPage.Text = listPages.Count.ToString();
        }

        public void Edit()
        {
            List<Question> listQuestion = new List<Question>();
            listQuestion.AddRange(test.Questions);
            for (int i = 0; i < listQuestion.Count; i++)
            {
                listPages.Add(new OneAnswerQuestonPage(listQuestion[i]));
            }
            frameQuestion.Navigate(listPages[0]);
            TbCurrentPage.Text = (currentPage + 1).ToString();
            TbCountPage.Text = listPages.Count.ToString();
        }

        List<Page> listPages = new List<Page>();
        int currentPage = 0;
        private void BackPage_click(object sender, RoutedEventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                frameQuestion.Navigate(listPages[currentPage]);
                TbCurrentPage.Text = (currentPage + 1).ToString();
                TbCountPage.Text = listPages.Count.ToString();
            }
        }

        private void NextPage_click(object sender, RoutedEventArgs e)
        {
            currentPage++;
            if (currentPage < listPages.Count)
            {
                frameQuestion.Navigate(listPages[currentPage]);
                TbCurrentPage.Text = (currentPage + 1).ToString();
                TbCountPage.Text = listPages.Count.ToString();
            }
            else
            {
                listPages.Add(new OneAnswerQuestonPage());
                frameQuestion.Navigate(listPages[currentPage]);
                TbCurrentPage.Text = (currentPage + 1).ToString();
                TbCountPage.Text = listPages.Count.ToString();
            }
        }

        private void SaveTest_click(object sender, RoutedEventArgs e)
        {          
            for (int i = 0; i < listPages.Count; i++)
            {
                var page = listPages[i];
                if (page.Title == "OneAnswerQuestonPage")
                {
                    OneAnswerQuestonPage pageOne = page as OneAnswerQuestonPage;
                    SaveOnePageAnswer(pageOne);
                }
            }
            MessageBox.Show("Сохранение прошло успешно");
        }

        public Question SaveQuestion(OneAnswerQuestonPage page)
        {
            Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
            TextBox textBox = page.TbQuestion;
            Question question = new Question()
            {
                id_type = 1,
                Id_Test = test.Id,
                Text_question = textBox.Text,
            };
            db.Questions.Add(question);
            db.SaveChanges();
            return question;
        }

        public void SaveOnePageAnswer(OneAnswerQuestonPage page)
        {
            Question question = SaveQuestion(page);
            List<Viewbox> listViewbox = page.listViewbox;
            for (int i = 0; i < listViewbox.Count; i++)
            {
                RadioButton radioButton = listViewbox[i].Child as RadioButton;
                Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
                TextBox textBox = page.listTextBox[i];
                Answer answer = new Answer()
                {
                    Correct = 0,
                    Text_Answer = textBox.Text,
                    IdQuestion = question.Id,
                };
                if (radioButton.IsChecked == true) 
                {                 
                    answer.Correct = 1;
                }
                db.Answers.Add(answer);
                db.SaveChanges();
            }
        }

        private void DeleteCurrentPage_click(object sender, RoutedEventArgs e)
        {
            if (currentPage == 0)
            {
                if(listPages.Count > 1)
                {
                    listPages.RemoveAt(currentPage);
                    frameQuestion.Navigate(listPages[currentPage]);
                    TbCurrentPage.Text = (currentPage + 1).ToString();
                    TbCountPage.Text = listPages.Count.ToString();
                }
            }
            else
            {
                listPages.RemoveAt(currentPage);
                currentPage--;
                frameQuestion.Navigate(listPages[currentPage]);
                TbCurrentPage.Text = (currentPage + 1).ToString();
                TbCountPage.Text = listPages.Count.ToString();
            }
            
        }

        private void Exit_click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти не сохранившиеся?", "Окно закрытия",
                             MessageBoxButton.YesNo,
                             MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                App.dataClass.Window.MainFrame.RemoveBackEntry();
                App.dataClass.Window.NextPage(new SelectiActionTeacher());
            }
        }
    }
}
