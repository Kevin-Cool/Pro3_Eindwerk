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
            //Nieuwe loop aanmaken 
            DateTime _when = (DateTime)WhenCalender.SelectedDate;
            int _distance = int.Parse(distance.Text);
            TimeSpan _time = TimeSpan.Parse(time.Text);
            float _averageSpeed = float.Parse(averageSpeed.Text);
            TrainingType _trainingType = (TrainingType)trainingType.SelectedItem;
            string _comments = comments.Text;
            DC.AddRunningTraining(_when, _distance, _time, _averageSpeed, _trainingType, _comments);
            this.Close();
        }
    }
}
