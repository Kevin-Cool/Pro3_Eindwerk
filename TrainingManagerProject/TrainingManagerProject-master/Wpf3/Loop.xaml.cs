using DomainLibrary;
using DomainLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wpf3
{
    /// <summary>
    /// Interaction logic for Loop.xaml
    /// </summary>
    public partial class Loop : Window
    {
        public DomainController DC;
        public Loop(DomainController mDC)
        {
            InitializeComponent();
            DC = mDC;
        }
        private void time_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            trainingType.ItemsSource = Enum.GetValues(typeof(TrainingType));
        }

        private void maakNieuweTraining_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
