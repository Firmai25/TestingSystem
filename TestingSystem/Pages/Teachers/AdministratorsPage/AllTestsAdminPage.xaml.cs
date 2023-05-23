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
    /// Логика взаимодействия для AllTestsAdminPage.xaml
    /// </summary>
    public partial class AllTestsAdminPage : Page
    {
        Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
        public AllTestsAdminPage()
        {
            InitializeComponent();
            GenerationListTest();
            cmbFilt.ItemsSource = db.Teachers.Where(b => b.Id_Type != 1).ToList();
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            App.dataClass.Window.BackPage();
        }


        public void GenerationListTest()
        {
            List<Test> testList = db.Tests.Where(b => b.VisibleTest == true).ToList();
            testList = FiltTest(testList);
            testList = SearchTest(testList);
            lvAllTests.ItemsSource = testList;

        }

        public List<Test> FiltTest(List<Test> listTest)
        {
            Teacher teacher = cmbFilt.SelectedItem as Teacher;
            if (teacher != null)
            {
                listTest = listTest.Where(b => b.id_Teacher == teacher.Id).ToList();
            }

            return listTest;
        }

        public List<Test> SearchTest(List<Test> listTest)
        {
            if (tbSearch.Text != "")
            {
                listTest = listTest.Where(b => b.Name.StartsWith(tbSearch.Text)).ToList();
            }
            return listTest;

        }

        private void SearchByName_TextChanged(object sender, TextChangedEventArgs e)
        {
            GenerationListTest();
        }

        private void cmbFilt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GenerationListTest();
        }

        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvAllTests.SelectedIndex != -1)
            {
                Test test = lvAllTests.SelectedItem as Test;
                db.Tests.Remove(test);
                db.SaveChanges();
                GenerationListTest();
                MessageBox.Show("Удаление прошло успешно");
            }
        }

        private void ResetFilt_Click(object sender, RoutedEventArgs e)
        {
            cmbFilt.SelectedIndex = -1;
            GenerationListTest();
        }
    }
}
