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
    /// Логика взаимодействия для SelectQuestionWindow.xaml
    /// </summary>
    public partial class SelectQuestionWindow : Window
    {
        public SelectQuestionWindow()
        {
            InitializeComponent();
            Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
            cmbTypeQuestion.ItemsSource = db.Type_question.ToList();
        }
        public string type;
        private void Select_Click(object sender, RoutedEventArgs e)
        {
            if (cmbTypeQuestion.Text != "")
            {
                type = cmbTypeQuestion.Text;
                Close();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать тип вопроса");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
