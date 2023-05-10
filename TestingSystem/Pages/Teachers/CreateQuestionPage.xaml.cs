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

        public bool Cancel = false;
        public void Create()
        {
            Windows.SelectQuestionWindow window = new Windows.SelectQuestionWindow();
            window.Owner = App.dataClass.Window;
            window.ShowDialog();
            if (window.type != null)
            {
                switch(window.type)
                {
                    case "Вопрос с одним ответом":
                        listPages.Add(new OneAnswerQuestonPage());
                        frameQuestion.Navigate(listPages[currentPage]);
                        TbCurrentPage.Text = (currentPage + 1).ToString();
                        TbCountPage.Text = listPages.Count.ToString();
                        break;
                    case "Вопрос с несколькими ответами":
                        listPages.Add(new MultipleAnswersQuestionPage());
                        frameQuestion.Navigate(listPages[currentPage]);
                        TbCurrentPage.Text = (currentPage + 1).ToString();
                        TbCountPage.Text = listPages.Count.ToString();
                        break;
                }
                
            }
            else
            {
                Cancel = true;
            }
            
        }

        public void Edit()
        {
            List<Question> listQuestion = new List<Question>();
            listQuestion.AddRange(test.Questions);
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
                Windows.SelectQuestionWindow window = new Windows.SelectQuestionWindow();
                window.Owner = App.dataClass.Window;
                window.ShowDialog();
                if (window.type != null)
                {
                    switch (window.type)
                    {
                        case "Вопрос с одним ответом":
                            listPages.Add(new OneAnswerQuestonPage());
                            frameQuestion.Navigate(listPages[currentPage]);
                            TbCurrentPage.Text = (currentPage + 1).ToString();
                            TbCountPage.Text = listPages.Count.ToString();
                            break;
                        case "Вопрос с несколькими ответами":
                            listPages.Add(new MultipleAnswersQuestionPage());
                            frameQuestion.Navigate(listPages[currentPage]);
                            TbCurrentPage.Text = (currentPage + 1).ToString();
                            TbCountPage.Text = listPages.Count.ToString();
                            break;
                    }
                }
                    
            }
        }

        private void SaveTest_click(object sender, RoutedEventArgs e)
        {
            deleteQuestion();
            for (int i = 0; i < listPages.Count; i++)
            {
                var page = listPages[i];
                if (page.Title == "OneAnswerQuestonPage")
                {
                    OneAnswerQuestonPage pageOne = page as OneAnswerQuestonPage;
                    SaveOnePageAnswer(pageOne);
                }
                if (page.Title == "MultipleAnswersQuestionPage")
                {
                    MultipleAnswersQuestionPage pageMulti = page as MultipleAnswersQuestionPage;
                    SaveMultiPageAnswer(pageMulti);
                }
            }
            MessageBox.Show("Сохранение прошло успешно");
        }
        
        public void deleteQuestion()
        {
            Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
            var list = db.Questions.Where(b => b.Id_Test == test.Id).ToList();
            db.Questions.RemoveRange(list);
            db.SaveChanges();
        }


        public Question SaveOneQuestion(OneAnswerQuestonPage page)
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

        public Question SaveMultiQuestion(MultipleAnswersQuestionPage page)
        {
            Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
            TextBox textBox = page.TbQuestion;
            Question question = new Question()
            {
                id_type = 2,
                Id_Test = test.Id,
                Text_question = textBox.Text,
            };
            db.Questions.Add(question);
            db.SaveChanges();
            return question;
        }

        public void SaveOnePageAnswer(OneAnswerQuestonPage page)
        {
            Question question = SaveOneQuestion(page);
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

        public void SaveMultiPageAnswer(MultipleAnswersQuestionPage page)
        {
            Question question = SaveMultiQuestion(page);
            List<Viewbox> listViewbox = page.listViewbox;
            for (int i = 0; i < listViewbox.Count; i++)
            {
                CheckBox checkBox = listViewbox[i].Child as CheckBox;
                Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
                TextBox textBox = page.listTextBox[i];
                Answer answer = new Answer()
                {
                    Correct = 0,
                    Text_Answer = textBox.Text,
                    IdQuestion = question.Id,
                };
                if (checkBox.IsChecked == true)
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
