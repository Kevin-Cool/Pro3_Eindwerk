using DataLayer;
using DomainLibrary;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DomainController DC;
        public MainWindow()
        {
            InitializeComponent();
            DC = new DomainController( new UnitOfWork(new TrainingContext("Production")));
            TrainingManager m = new TrainingManager(new UnitOfWork(new TrainingContext("Production")));

        }
        private void NieuweFiets_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new Fiets(DC);
            newForm.Show();
        }
        private void NieuwLoop_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new Loop(DC);
            newForm.Show();
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_Loaded(object sender, RoutedEventArgs e)
        {
            int _maand = 4;
            int _jaar = 2020;
            foreach (var s in DC.GetCyclingTraining(_jaar, _maand).TimeLine)
            {
                listboxMaand.Items.Add($"{s.Item1.ToString()},{s.Item2}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int _maand = int.Parse(maand.Text);
            int _jaar = int.Parse(jaar.Text);
            foreach (var s in DC.GetCyclingTraining(_jaar, _maand).TimeLine)
            {
                listboxMaand.Items.Add($"{s.Item2}");
            }
        }
    }
}
