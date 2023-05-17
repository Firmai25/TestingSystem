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
    /// Логика взаимодействия для InfoTestPage.xaml
    /// </summary>
    public partial class InfoTestPage : Page
    {
        Test test;
        Parameters_Test parameters;
        Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
        public InfoTestPage(Test currentTest)
        {
            InitializeComponent();
            test = db.Tests.Where(b=> b.Id == currentTest.Id).FirstOrDefault();
            TbTestName.Text = test.Name;
            TbDescription.Text = test.Description;
            parameters = db.Parameters_Test.Where(b => b.Id_Test == test.Id).FirstOrDefault();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            App.dataClass.Window.BackPage();
        }

        private void EdutQuestion_Click(object sender, RoutedEventArgs e)
        {
            var quest = db.Questions.Where(b=> b.Id_Test == test.Id).ToList();
            if (quest.Count > 0)
            {
                App.dataClass.Window.NextPage(new CreateQuestionPage(test, true));
            }
            else
            {
                CreateQuestionPage page = new CreateQuestionPage(test, false);
                if (!page.Cancel)
                {
                    App.dataClass.Window.NextPage(page);
                }
            }
            
        }

        private void SaveEditTest_Click(object sender, RoutedEventArgs e)
        {
            if (TbTestName.Text != "")
            {
                Parameters_Test parameters_Test = db.Parameters_Test.Where(b => b.Id_Test == test.Id).FirstOrDefault();
                parameters_Test.TimeLimit = parameters.TimeLimit;
                parameters_Test.Sequence = parameters.Sequence;
                parameters.AbilityReturn = parameters.AbilityReturn;
                test.DateEdit = DateTime.Now;
                test.Name = TbTestName.Text;
                test.Description = TbDescription.Text;
                db.SaveChanges();
                MessageBox.Show("Сохранение прошло успешно");
            }
            else
            {
                MessageBox.Show("Поле имя теста не может быть пустым");
            }
        }

        private void EditParametrs_Click(object sender, RoutedEventArgs e)
        {
            Windows.ParametrsTestWindow window = new Windows.ParametrsTestWindow(parameters);
            window.Owner = App.dataClass.Window;
            window.ShowDialog();
        }
    }
}
