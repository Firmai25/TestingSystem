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

namespace TestingSystem.Pages.Teachers
{
    /// <summary>
    /// Логика взаимодействия для SelectiActionTeacher.xaml
    /// </summary>
    public partial class SelectiActionTeacher : Page
    {
        
        public SelectiActionTeacher()
        {
            InitializeComponent();
        }

        private void ReturnSelectionActions_click(object sender, RoutedEventArgs e)
        {
            SelectActions selectActions = new SelectActions();
            App.dataClass.Window.NextPage(selectActions);
        }

        private void AllCreateTest_click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateTest_Click(object sender, RoutedEventArgs e)
        {
            CreateTestPage createTestPage = new CreateTestPage();
            App.dataClass.Window.NextPage(createTestPage);
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            App.dataClass.Window.MainFrame.RemoveBackEntry();
            App.dataClass.Window.NextPage(new SelectActions());
        }

        private void OpenAllCreateTest_Click(object sender, RoutedEventArgs e)
        {
            TestTeacherPage testTeacherPage = new TestTeacherPage(App.dataClass.Teacher);
            App.dataClass.Window.NextPage(testTeacherPage);
        }
    }
}
