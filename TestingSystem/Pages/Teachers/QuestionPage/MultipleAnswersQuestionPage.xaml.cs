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

namespace TestingSystem.Pages.Teachers.QuestionPage
{
    /// <summary>
    /// Логика взаимодействия для MultipleAnswersQuestionPage.xaml
    /// </summary>
    public partial class MultipleAnswersQuestionPage : Page
    {
        public MultipleAnswersQuestionPage()
        {
            InitializeComponent();
            for (int i = 0; i < 4; i++)
            {
                Generating_a_question_field();
            }
        }


        public MultipleAnswersQuestionPage(Question question)
        {
            InitializeComponent();
            TbQuestion.Text = question.Text_question;
            Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
            listAnswers = db.Answers.Where(b => b.IdQuestion == question.Id).ToList();
            for (int i = 0; i < listAnswers.Count(); i++)
            {
                Creating_a_ready_made_question_field();
            }
        }

        public void Creating_a_ready_made_question_field()
        {
            Grid grid = MainQuestionGrid;
            grid.RowDefinitions.Add(new RowDefinition());
            GenerationReadyCheckBox(grid);
            GenerationReadyTextBox(grid);
            GenerationButton(grid);
            countAnswer++;
        }

        public void GenerationReadyCheckBox(Grid grid)
        {
            Viewbox viewbox = new Viewbox();
            viewbox.Name = "vbQuestion" + countAnswer.ToString();
            viewbox.Height = 30;
            grid.Children.Add(viewbox);
            Grid.SetColumn(viewbox, 0);
            Grid.SetRow(viewbox, countAnswer);
            listViewbox.Add(viewbox);
            CheckBox checkBox = new CheckBox()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Name = "rbQuestion" + countAnswer.ToString(),

            };
            if (listAnswers[countAnswer].Correct == 1)
            {
                checkBox.IsChecked = true;
            }
            viewbox.Child = checkBox;
        }

        public void GenerationReadyTextBox(Grid grid)
        {
            TextBox textbox = new TextBox()
            {
                Name = "tbQuestion" + countAnswer.ToString(),
                FontSize = 20,
                Margin = new Thickness(0, 10, 0, 10),
                TextWrapping = TextWrapping.Wrap,
                Text = listAnswers[countAnswer].Text_Answer,
                AcceptsReturn = true
            };
            grid.Children.Add(textbox);
            Grid.SetColumn(textbox, 1);
            Grid.SetRow(textbox, countAnswer);
            listTextBox.Add(textbox);
        }

        int countAnswer = 0;
        public void Generating_a_question_field()
        {
            Grid grid = MainQuestionGrid;
            grid.RowDefinitions.Add(new RowDefinition());
            GenerationRadioButton(grid);
            GenerationTextBox(grid);
            GenerationButton(grid);
            countAnswer++;
        }

        public List<Button> listButton = new List<Button>();
        public List<Viewbox> listViewbox = new List<Viewbox>();
        public List<TextBox> listTextBox = new List<TextBox>();
        public List<Answer> listAnswers = new List<Answer>();

        public void GenerationRadioButton(Grid grid)
        {
            Viewbox viewbox = new Viewbox();
            viewbox.Name = "vbQuestion" + countAnswer.ToString();
            viewbox.Height = 30;
            grid.Children.Add(viewbox);
            Grid.SetColumn(viewbox, 0);
            Grid.SetRow(viewbox, countAnswer);
            listViewbox.Add(viewbox);
            CheckBox checkBox = new CheckBox()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Name = "rbQuestion" + countAnswer.ToString(),

            };
            viewbox.Child = checkBox;
        }

        public void GenerationTextBox(Grid grid)
        {
            TextBox textbox = new TextBox()
            {
                Name = "tbQuestion" + countAnswer.ToString(),
                FontSize = 20,
                Margin = new Thickness(0, 10, 0, 10),
                TextWrapping = TextWrapping.Wrap,
                AcceptsReturn = true
            };
            grid.Children.Add(textbox);
            Grid.SetColumn(textbox, 1);
            Grid.SetRow(textbox, countAnswer);
            listTextBox.Add(textbox);
        }

        public void GenerationButton(Grid grid)
        {
            Button button = new Button()
            {
                Content = "Удалить",
                Height = 40,
                Margin = new Thickness(10, 0, 10, 0),
                Name = "BtnDelete" + countAnswer.ToString()
            };
            button.Click += Delete_click;
            grid.Children.Add(button);
            Grid.SetColumn(button, 2);
            Grid.SetRow(button, countAnswer);
            listButton.Add(button);

        }


        private void Delete_click(object sender, RoutedEventArgs e)
        {
            if (countAnswer != 2)
            {
                Button button = (Button)sender;
                char charIndex = button.Name[button.Name.Length - 1];
                int index = (int)Char.GetNumericValue(charIndex);
                deleteTextBox(index);
                deleteButton(index);
                deleteViewbox(index);
                Displacement_of_objects(index);
                countAnswer--;

            }
            else
            {
                MessageBox.Show("Меньше двух не может быть");
            }

        }

        public void deleteTextBox(int number)
        {
            string name = "tbQuestion" + number.ToString();
            TextBox textBox = listTextBox.Where(b => b.Name == name).FirstOrDefault();
            listTextBox.Remove(textBox);
            MainQuestionGrid.Children.Remove(textBox);
        }

        public void deleteButton(int number)
        {
            string name = "BtnDelete" + number.ToString();
            Button button = listButton.Where(b => b.Name == name).FirstOrDefault();
            listButton.Remove(button);
            MainQuestionGrid.Children.Remove(button);
        }

        public void deleteViewbox(int number)
        {
            string name = "vbQuestion" + number.ToString();
            Viewbox viewbox = listViewbox.Where(b => b.Name == name).FirstOrDefault();
            listViewbox.Remove(viewbox);
            MainQuestionGrid.Children.Remove(viewbox);
        }

        public void Displacement_of_objects(int number)
        {
            if (countAnswer <= 6)
            {
                MainQuestionGrid.RowDefinitions.RemoveAt(number);
            }
            else
            {
                BtnAddAnswer.Visibility = Visibility.Visible;
            }
            for (int i = number + 1; i < countAnswer; i++)
            {
                DesplacementOfButton(i);
                DesplacementOfTextBox(i);
                DesplacementOfViewbox(i);
            }

        }

        public void DesplacementOfButton(int number)
        {
            string name = "BtnDelete" + number.ToString();
            Button button = listButton.Where(b => b.Name == name).FirstOrDefault();
            int a = Grid.GetRow(button);
            button.Name = "BtnDelete" + (number - 1).ToString();
            Grid.SetRow(button, Grid.GetRow(button) - 1);
            Grid.SetColumn(button, Grid.GetColumn(button));
        }

        public void DesplacementOfTextBox(int number)
        {
            string name = "tbQuestion" + number.ToString();
            TextBox textBox = listTextBox.Where(b => b.Name == name).FirstOrDefault();
            textBox.Name = "tbQuestion" + (number - 1).ToString();
            Grid.SetRow(textBox, Grid.GetRow(textBox) - 1);
            Grid.SetColumn(textBox, Grid.GetColumn(textBox));
        }

        public void DesplacementOfViewbox(int number)
        {
            string name = "vbQuestion" + number.ToString();
            Viewbox viewbox = listViewbox.Where(b => b.Name == name).FirstOrDefault();
            viewbox.Name = "vbQuestion" + (number - 1).ToString();
            Grid.SetRow(viewbox, Grid.GetRow(viewbox) - 1);
            Grid.SetColumn(viewbox, Grid.GetColumn(viewbox));
        }

        private void AddAnswer_click(object sender, RoutedEventArgs e)
        {
            if (countAnswer < 6)
            {
                Generating_a_question_field();
            }
            else
            {
                MainQuestionGrid.RowDefinitions.RemoveAt(6);
                BtnAddAnswer.Visibility = Visibility.Collapsed;
                Generating_a_question_field();
            }

        }
    }
}
