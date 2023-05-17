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
using System.Windows.Shapes;
using TestingSystem.Entities;

namespace TestingSystem.Windows
{
    /// <summary>
    /// Логика взаимодействия для CreateUserWindows.xaml
    /// </summary>
    public partial class CreateUserWindows : Window
    {
        Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();

        public CreateUserWindows()
        {
            InitializeComponent();
            cmbType.ItemsSource = db.Type_Teacher.ToList();
            DataContext = new Teacher();
        }

        bool create = true;

        public CreateUserWindows(Teacher teacher)
        {
            InitializeComponent();
            create = false;
            teacher = db.Teachers.Where(b => b.Id == teacher.Id).FirstOrDefault();
            cmbType.ItemsSource = db.Type_Teacher.ToList();
            DataContext = teacher;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (checking_the_field())
            {
                if (create)
                {
                    Teacher teacher = DataContext as Teacher;
                    db.Teachers.Add(teacher);
                    db.SaveChanges();
                    MessageBox.Show("Пользователь успешно создан");
                    Close();
                }
                else
                {
                    db.SaveChanges();
                    MessageBox.Show("Пользователь успешно изменён");
                    Close();
                }

            }
        }

        private bool checking_the_field()
        {
            string messageError = "";
            Teacher teacher = DataContext as Teacher;
            if (teacher.Surname == null || teacher.Surname == "")
            {
                messageError += "Поле фамилия не заполнено\n";
            }
            if (teacher.Name == null || teacher.Name == "")
            {
                messageError += "Поле имя не заполнено\n";
            }
            if (teacher.Patronymic == null || teacher.Patronymic == "")
            {
                messageError += "Поле отчество не заполнено\n";
            }
            if (teacher.Login == null || teacher.Login == "")
            {
                messageError += "Поле логин не заполнено\n";
            }
            if (create)
            {
                Teacher loginTeaher = db.Teachers.Where(b => b.Login == teacher.Login).FirstOrDefault();
                if (loginTeaher != null)
                {
                    messageError += "Такой логин уже занят\n";
                }
            }

            if (teacher.Password == null || teacher.Password == "")
            {
                messageError += "Поле пароль не заполнено\n";
            }
            if (teacher.Type_Teacher == null)
            {
                messageError += "Поле тип выбрано\n";
            }
            if (messageError == "")
            {
                return true;
            }
            else
            {
                MessageBox.Show(messageError);
                return false;
            }
        }
    }
}
