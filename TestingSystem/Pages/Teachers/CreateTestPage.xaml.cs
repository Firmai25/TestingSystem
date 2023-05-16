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
    /// Логика взаимодействия для CreateTestPage.xaml
    /// </summary>
    public partial class CreateTestPage : Page
    {
        Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
        public Parameters_Test parameters = new Parameters_Test()
        {
            AbilityReturn = true,
            Sequence = true,
        };

        public CreateTestPage()
        {
            InitializeComponent();
        }        

        private void OpenParametrs_click(object sender, RoutedEventArgs e)
        {
            Windows.ParametrsTestWindow window = new Windows.ParametrsTestWindow(parameters);
            window.Owner = App.dataClass.Window;
            window.ShowDialog();
        }

        private void CreateTest_Click(object sender, RoutedEventArgs e)
        {
            if(TbTestName.Text.Trim() != "")
            {
                Test test = new Test()
                {
                    Description = TbDescription.Text,
                    id_Teacher = 1,
                    Name = TbTestName.Text
                };
                db.Tests.Add(test);
                db.SaveChanges();
                parameters.Id_Test = test.Id;
                db.Parameters_Test.Add(parameters);
                db.SaveChanges();
                CreateQuestionPage page = new CreateQuestionPage(test, false);
                if (!page.Cancel)
                {
                    App.dataClass.Window.NextPage(page);
                }
            }
            else
            {
                MessageBox.Show("Имя должно быть заполнено");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            App.dataClass.Window.BackPage();
        }
    }
}
