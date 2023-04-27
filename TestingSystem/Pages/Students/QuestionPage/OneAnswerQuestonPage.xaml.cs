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

namespace TestingSystem.Pages.Students.QuestionPage
{
    /// <summary>
    /// Логика взаимодействия для OneAnswerQuestonPage.xaml
    /// </summary>
    public partial class OneAnswerQuestonPage : Page
    {
        Question question;
        int currentAnswer;

        public OneAnswerQuestonPage(Question currentQuestion)
        {
            InitializeComponent();
            question = currentQuestion;
            TbQuestion.Text = question.Text_question;
            Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
            listAnswers = db.Answers.Where(b => b.IdQuestion == question.Id).ToList();
            for (int i = 0; i < listAnswers.Count(); i++)
            {
                Generating_a_question_field();
            }
        }

        public List<Answer> listAnswers = new List<Answer>();
        public List<Viewbox> listViewbox = new List<Viewbox>();
        public List<TextBlock> listTextBlock = new List<TextBlock>();

        public void Generating_a_question_field()
        {
            Grid grid = MainQuestionGrid;
            grid.RowDefinitions.Add(new RowDefinition());
            GenerationRadioButton(grid);
            GenerationTextBlock(grid);
            currentAnswer++;
        }

        public void GenerationRadioButton(Grid grid)
        {
            Viewbox viewbox = new Viewbox();
            viewbox.Name = "vbQuestion" + currentAnswer.ToString();
            viewbox.Height = 30;
            grid.Children.Add(viewbox);
            Grid.SetColumn(viewbox, 0);
            Grid.SetRow(viewbox, currentAnswer);
            listViewbox.Add(viewbox);
            RadioButton radioButton = new RadioButton()
            {
                GroupName = "GrQuest",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Name = "rbQuestion" + currentAnswer.ToString(),

            };
            viewbox.Child = radioButton;
        }

        public void GenerationTextBlock(Grid grid)
        {
            TextBlock textblock = new TextBlock()
            {
                Name = "tbQuestion" + currentAnswer.ToString(),
                FontSize = 20,
                Margin = new Thickness(0, 10, 0, 10),
                TextWrapping = TextWrapping.Wrap,
                Text = listAnswers[currentAnswer].Text_Answer,
                VerticalAlignment= VerticalAlignment.Center,
            };
            grid.Children.Add(textblock);
            Grid.SetColumn(textblock, 1);
            Grid.SetRow(textblock, currentAnswer);
            listTextBlock.Add(textblock);
        }
    }
}
