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

namespace TestingSystem.Pages.Teachers
{
    /// <summary>
    /// Логика взаимодействия для CreateQuestionPage.xaml
    /// </summary>
    public partial class CreateQuestionPage : Page
    {
        int IdQuestion;
        public CreateQuestionPage(int idQuestion)
        {
            InitializeComponent();
            IdQuestion = idQuestion;
            listPages.Add(new OneAnswerQuestonPage());
            frameQuestion.Navigate(listPages[currentPage]);
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
        }

        public Question SaveQuestion(OneAnswerQuestonPage page)
        {
            Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
            TextBox textBox = page.TbQuestion;
            Question question = new Question()
            {
                id_type = 1,
                Id_Test = IdQuestion,
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
    }
}
