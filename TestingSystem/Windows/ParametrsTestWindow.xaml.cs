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
    /// Логика взаимодействия для ParametrsTestWindow.xaml
    /// </summary>
    public partial class ParametrsTestWindow : Window
    {
        public Parameters_Test parameters;

        public ParametrsTestWindow(Parameters_Test parameters_Test)
        {
            InitializeComponent();
            parameters = parameters_Test;
        }

        private void Save_click(object sender, RoutedEventArgs e)
        {
            parameters.Sequence = SequenceQuestion();
            parameters.AbilityReturn = AbilityReturnQuestion();
            parameters.TimeLimit = TimeLimitTest();
            parameters.NumberTortures = NumberTorturesTest();
            MessageBox.Show("Изменения успешно сохранены");
            Close();
        }

        public bool SequenceQuestion()
        {
            if (RbSequenceFalse.IsChecked == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool AbilityReturnQuestion()
        {
            if (RbAbilityReturnFalse.IsChecked == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int? TimeLimitTest()
        {
            if (RbTime.IsChecked == true)
            {
                if (TbTime.Text != "" && int.TryParse(TbTime.Text, out int result))
                {
                    return result;
                }
                else
                {
                    MessageBox.Show("Ограничение по времени должно быть целочисленным");
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public int? NumberTorturesTest()
        {
            if (RbCount.IsChecked == true)
            {
                if (TbCount.Text != "" && int.TryParse(TbCount.Text, out int result))
                {
                    return result;
                }
                else
                {
                    MessageBox.Show("Ограничение по времени должно быть целочисленным");
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
