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
        public TestTeacherPage(Teacher teacher)
        {
            InitializeComponent();
            Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
            lvTests.ItemsSource = db.Tests.Where(b => teacher.Id == b.id_Teacher).ToList();
        }

        private void lvTests_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvTests.SelectedIndex != -1)
            {
                Test test = lvTests.SelectedItem as Test;
                App.dataClass.Window.NextPage(new InfoTestPage(test));
            }
        }
    }
}
