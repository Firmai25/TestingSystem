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
    /// Логика взаимодействия для InfoUserWindow.xaml
    /// </summary>
    public partial class InfoUserWindow : Window
    {
        Test test;
        Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
        public InfoUserWindow(Test currentTest)
        {
            InitializeComponent();
            test = currentTest;
            DataContext = new Rating();
        }

        public bool start = false;

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (checking_the_field())
            {
                Rating rating = DataContext as Rating;
                rating.Id_Test = test.Id;
                rating.Scores = 0;
                db.Ratings.Add(rating);
                db.SaveChanges();
                start = true;
                App.dataClass.Rating = rating;
                Close();
            }
        }

        private bool checking_the_field()
        {
            string messageError = "";
            Rating rating = DataContext as Rating;
            if (rating.Surname == null || rating.Surname == "")
            {
                messageError += "Поле фамилия не заполнено\n";
            }
            if (rating.Name == null || rating.Name == "")
            {
                messageError += "Поле имя не заполнено\n";
            }
            if (rating.Patronymic == null || rating.Patronymic == "")
            {
                messageError += "Поле отчество не заполнено\n";
            }
            double error = 0;
            if (!Double.TryParse(tbNumber.Text, out error))
            {
                messageError += "Поле номер класса имеет не правильный формат\n";
            }
            else
            {
                if (error < 1 || error > 11)
                {
                    messageError += "Класса с таким номером нет\n";
                }
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
