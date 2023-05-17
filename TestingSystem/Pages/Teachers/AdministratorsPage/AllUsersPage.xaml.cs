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

namespace TestingSystem.Pages.Teachers.AdministratorsPage
{
    /// <summary>
    /// Логика взаимодействия для AllUsersPage.xaml
    /// </summary>
    public partial class AllUsersPage : Page
    {
        
        public AllUsersPage()
        {
            InitializeComponent();
            Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
            int idTeacher = App.dataClass.Teacher.Id;
            lvUser.ItemsSource = db.Teachers.Where(b => b.Id != idTeacher).ToList();
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Teacher teather = button.DataContext as Teacher;
            Windows.CreateUserWindows createUser = new Windows.CreateUserWindows(teather);
            createUser.Owner = App.dataClass.Window;
            createUser.ShowDialog();
            int idTeacher = App.dataClass.Teacher.Id;
            Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
            lvUser.ItemsSource = db.Teachers.Where(b => b.Id != idTeacher).ToList();
        }

        private void DeleteUsers_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите удалить данного пользователя", "Окно удаления",
                             MessageBoxButton.YesNo,
                             MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
                Button button = sender as Button;
                Teacher teather = button.DataContext as Teacher;
                teather = db.Teachers.Where(b => b.Id == teather.Id).FirstOrDefault();
                db.Teachers.Remove(teather);
                db.SaveChanges();
                int idTeacher = App.dataClass.Teacher.Id;
                lvUser.ItemsSource = db.Teachers.Where(b => b.Id != idTeacher).ToList();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            App.dataClass.Window.BackPage();
        }
    }
}
