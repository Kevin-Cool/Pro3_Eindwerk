using DomainLibrary.Domain;
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

namespace Wpf
{
    /// <summary>
    /// Interaction logic for Loop.xaml
    /// </summary>
    public partial class Loop : Window
    {
        public Loop()
        {
            InitializeComponent();
        }

        private void time_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            trainingType.ItemsSource = Enum.GetValues(typeof(TrainingType)).Cast<TrainingType>();
        }

        private void maakNieuweTraining_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
