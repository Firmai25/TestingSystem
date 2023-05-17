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
    /// Логика взаимодействия для AutorizationTeacherPage.xaml
    /// </summary>
    public partial class AutorizationTeacherPage : Page
    {
        Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
        public AutorizationTeacherPage()
        {
            InitializeComponent();
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            App.dataClass.Window.BackPage();
        }

        private void Autorization_Click(object sender, RoutedEventArgs e)
        {
            Teacher teacher = db.Teachers.Where(b => b.Login == TbLogin.Text.Trim() && b.Password == TbPassword.Password.Trim()).FirstOrDefault();
            if (teacher != null)
            {
                switch (teacher.Id_Type)
                {
                    case 1:
                        AdministratorsPage.SelectActionAdministrator selectiActionAdmin = 
                                        new AdministratorsPage.SelectActionAdministrator();
                        App.dataClass.Teacher = teacher;
                        App.dataClass.Window.NextPage(selectiActionAdmin);
                        break;
                    case 2:
                        SelectiActionTeacher selectiAction = new SelectiActionTeacher();
                        App.dataClass.Teacher = teacher;
                        App.dataClass.Window.NextPage(selectiAction);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Пользователь с такими данными не найден");
            }
        }

        private void TbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (TbPassword.Password != "")
            {
                lbPassword.Visibility = Visibility.Hidden;
            }
            else
            {
                lbPassword.Visibility = Visibility.Visible;
            }
        }
    }
}
