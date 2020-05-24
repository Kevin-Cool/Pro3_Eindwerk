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
    /// Interaction logic for Fiets.xaml
    /// </summary>
    public partial class Fiets : Window
    {
        public DomainController DC;
        public Fiets(DomainController mDC)
        {
            InitializeComponent();
            DC = mDC;
        }
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            trainingType.ItemsSource = Enum.GetValues(typeof(TrainingType));
        }

        private void maakNieuweTraining_Click(object sender, RoutedEventArgs e)
        {
            //Nieuwe fiets aanmaken
            //AddCyclingTraining(DateTime when, float? distance, TimeSpan time, float? averageSpeed, int? averageWatt, TrainingType trainingType, string comments, BikeType bikeType)
            DateTime _when = (DateTime)WhenCalender.SelectedDate;
            float _distance = float.Parse(distance.Text);
            TimeSpan _time = TimeSpan.Parse(time.Text);
            float _averageSpeed = float.Parse(averageSpeed.Text);
            int _averageWatt = int.Parse(averageWatt.Text);
            TrainingType _trainingType = (TrainingType)trainingType.SelectedItem;
            string _comments = comments.Text;
            BikeType _bikeType = (BikeType)bikeType.SelectedItem;
            DC.AddCyclingTraining(_when, _distance, _time, _averageSpeed, _averageWatt, _trainingType, _comments, _bikeType);
            this.Close();
        }

        private void trainingType_Loaded(object sender, RoutedEventArgs e)
        {
            bikeType.ItemsSource = Enum.GetValues(typeof(BikeType));
        }
    }
}
