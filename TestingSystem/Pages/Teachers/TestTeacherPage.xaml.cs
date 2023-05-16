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
    /// Логика взаимодействия для TestTeacherPage.xaml
    /// </summary>
    public partial class TestTeacherPage : Page
    {
        Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
        Teacher teacher;
        public TestTeacherPage(Teacher currentTeacher)
        {
            InitializeComponent();
            teacher = currentTeacher;
            lvTests.ItemsSource = db.Tests.Where(b => currentTeacher.Id == b.id_Teacher).ToList();
        }

        private void lvTests_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvTests.SelectedIndex != -1)
            {
                Test test = lvTests.SelectedItem as Test;
                App.dataClass.Window.NextPage(new InfoTestPage(test));
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            App.dataClass.Window.BackPage();
        }

        private void Edit_click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Test test = button.DataContext as Test;
            App.dataClass.Window.NextPage(new InfoTestPage(test));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите удалиль этот тест?", "Окно закрытия",
                             MessageBoxButton.YesNo,
                             MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Button button = sender as Button;
                Test test = button.DataContext as Test;
                db.Tests.Remove(test);
                db.SaveChanges();
                lvTests.ItemsSource = db.Tests.Where(b => teacher.Id == b.id_Teacher).ToList();
            }
        }

        private void ViewPoints_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Test test = btn.DataContext as Test;
            App.dataClass.Window.NextPage(new ScoresPassedTestPage(test));
        }
    }
}   
