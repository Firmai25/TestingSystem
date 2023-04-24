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
            TbLogin.Text = "Firmai";
            TbPassword.Text = "123";
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            App.windowClass.Window.BackPage();
        }

        private void Autorization_Click(object sender, RoutedEventArgs e)
        {
            Teacher teacher = db.Teachers.Where(b => b.Login == TbLogin.Text && b.Password == TbPassword.Text).FirstOrDefault();
            if (teacher != null)
            {
                SelectiActionTeacher selectiAction = new SelectiActionTeacher();
                App.windowClass.Window.NextPage(selectiAction);
            }
            else
            {
                MessageBox.Show("Такой пользователь не найден");
            }
        }
    }
}
