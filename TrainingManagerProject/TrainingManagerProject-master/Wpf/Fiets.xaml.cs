using DomainLibrary.Domain;
using DataLayer;
using System;
using System.Linq;
using System.Windows;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for Fiets.xaml
    /// </summary>
    public partial class Fiets : Window
    {
        public Fiets()
        {
            InitializeComponent();
            //RunningSession(DateTime when, int distance, TimeSpan time, float? averageSpeed, TrainingType trainingType, string comments)
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            trainingType.ItemsSource = Enum.GetValues(typeof(TrainingType)).Cast<TrainingType>();
        }

        private void maakNieuweTraining_Click(object sender, RoutedEventArgs e)
        {
            //Nieuwe fiets aanmaken
            TrainingManager m = new TrainingManager(new UnitOfWork(new TrainingContext("Production")));
            m.AddCyclingTraining(new DateTime(2020, 4, 21, 16, 00, 00), 40, new TimeSpan(1, 20, 00), 30, null, TrainingType.Endurance, null, BikeType.RacingBike);

            this.Close();
        }

        private void trainingType_Loaded(object sender, RoutedEventArgs e)
        {
            bikeType.ItemsSource = Enum.GetValues(typeof(BikeType)).Cast<BikeType>();
        }
    }
}
