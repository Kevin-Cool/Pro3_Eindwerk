using DataLayer;
using DomainLibrary;
using DomainLibrary.Domain;
using System;
using System.CodeDom;
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
        public List<int> IDs = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
            DC = new DomainController( new UnitOfWork(new TrainingContext("Production")));

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
            VullListBoxOP();
        }
        private void Maandbassis_Click(object sender, RoutedEventArgs e)
        {
            VullListBoxOP();
        }
        private void ToonLaatsteSessies_Click(object sender, RoutedEventArgs e)
        {
            int count = int.Parse(countLaatsteSessie.Text);
            bool fiets = (bool)FietsTrainingcheck.IsChecked;
            bool loop = (bool)LoopTrainingcheck.IsChecked;
            if(fiets && loop)
            {
                //nothing
            }
            else
            {
                listboxMaand.Items.Clear();
                if (fiets)
                {
                    foreach (CyclingSession c in DC.GetCountCyclingSessions(count))
                    {
                            listboxMaand.Items.Add(CyclingToString(c,"Fiets sessie"));
                    }
                }
                else
                {
                    foreach (RunningSession c in DC.GetCountRunningSessions(count))
                    {
                        listboxMaand.Items.Add(RunnungToString(c,"Loop sessie"));
                    }
                }
            }

        }
        private void besteTrainingen_Loaded(object sender, RoutedEventArgs e)
        {
            //besteTrainingOpVullen();
        }
        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            besteTrainingOpVullen();
        }
        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            besteTrainingOpVullen();
        }
        private void Verwijder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!listboxMaand.SelectedItem.Equals(null))
                {
                    int index = listboxMaand.SelectedIndex;
                    string st = listboxMaand.SelectedItem.ToString();
                    string[] str = st.Split(':');
                    List<int> cyclingSessionIds = new List<int>();
                    List<int> runningSessionIds = new List<int>();
                    if(str[0].Equals("Fiets sessie"))
                    {
                        cyclingSessionIds.Add(IDs[index]);
                    }
                    else
                    {
                        runningSessionIds.Add(IDs[index]);
                    }
                    DC.RemoveSession(cyclingSessionIds, runningSessionIds);
                    
                }
            }
            catch (Exception)
            {

            }

            VullListBoxOP();
        }
        private void besteTrainingOpVullen()
        {

            bool fiets = false;
            try
            {
                fiets = (bool)radioFiets.IsChecked;
            }
            catch (Exception)
            {

            }
            besteTrainingen.Items.Clear();
            //loop  langste afstand , gemiddelde snelheid EN gemiddelde snelheid
            //fiets langste afstand , gemiddelde  snelheid EN gemiddelde snelheid
            if (fiets)
            {
                List<CyclingSession> CyckingList = DC.GetAllCyclingSessions();
                CyclingSession topDistance = CyckingList[0];
                foreach (CyclingSession c in CyckingList)
                {
                    if (topDistance.Distance <= c.Distance)
                    {
                        if ((topDistance.Distance == c.Distance) && (topDistance.AverageSpeed < c.AverageSpeed))
                        {
                            topDistance = c;
                        }
                        if (topDistance.Distance < c.Distance)
                        {
                            topDistance = c;
                        }
                    }
                }
                besteTrainingen.Items.Add(CyclingToString(topDistance, "Fiets sessie met meeste afstand"));
                CyclingSession topSpeed = CyckingList[0];
                foreach (CyclingSession c in CyckingList)
                {
                    if (topSpeed.AverageSpeed <= c.AverageSpeed)
                    {
                        topSpeed = c;
                    }
                }
                besteTrainingen.Items.Add(CyclingToString(topSpeed, "Hoogste gemidelde snelheid"));
            }
            else
            {
                List<RunningSession> CyckingList = DC.GetAllRunningSessions();
                RunningSession topDistance = CyckingList[0];
                foreach (RunningSession c in CyckingList)
                {
                    if (topDistance.Distance <= c.Distance)
                    {
                        if ((topDistance.Distance == c.Distance) && (topDistance.AverageSpeed < c.AverageSpeed))
                        {
                            topDistance = c;
                        }
                        if (topDistance.Distance < c.Distance)
                        {
                            topDistance = c;
                        }
                    }
                }
                besteTrainingen.Items.Add(RunnungToString(topDistance, "Loop sessie met meeste afstand"));
                RunningSession topSpeed = CyckingList[0];
                foreach (RunningSession c in CyckingList)
                {
                    if (topSpeed.AverageSpeed <= c.AverageSpeed)
                    {
                        topSpeed = c;
                    }
                }
                besteTrainingen.Items.Add(RunnungToString(topSpeed, "Hoogste gemidelde snelheid"));
            }
            



            //besteTrainingen.Items.Add(CyclingToString(c));
        }
        private void VullListBoxOP()
        {
            int _maand = int.Parse(maand.Text);
            int _jaar = int.Parse(jaar.Text);
            bool fiets = (bool)FietsTrainingcheck.IsChecked;
            bool loop = (bool)LoopTrainingcheck.IsChecked;
            listboxMaand.Items.Clear();
            IDs.Clear();
            if (fiets && loop)
            {
                foreach (var s in DC.GetMonlyReport(_jaar, _maand).TimeLine)
                {
                    if(s.Item2 is CyclingSession)
                    {
                        CyclingSession tempCycl = (CyclingSession)s.Item2;
                        listboxMaand.Items.Add(CyclingToString(tempCycl, "Fiets sessie"));
                        IDs.Add(tempCycl.Id);
                    }
                    else
                    {
                        RunningSession tempCycl = (RunningSession)s.Item2;
                        listboxMaand.Items.Add(RunnungToString(tempCycl, "Loop sessie"));
                        IDs.Add(tempCycl.Id);
                    }
                }
            }
            else if (fiets && !loop)
            {
                foreach (var s in DC.GetMonlyCyclingReport(_jaar, _maand).TimeLine)
                {
                    CyclingSession tempCycl = (CyclingSession)s.Item2;
                    listboxMaand.Items.Add(CyclingToString(tempCycl, "Fiets sessie"));
                    IDs.Add(tempCycl.Id);
                }
            }
            else if (!fiets && loop)
            {
                foreach (var s in DC.GetMonlyRunningReport(_jaar, _maand).TimeLine)
                {
                    RunningSession tempCycl = (RunningSession)s.Item2;
                    listboxMaand.Items.Add(RunnungToString(tempCycl, "Loop sessie"));
                    IDs.Add(tempCycl.Id);
                }
            }


        }
        private string CyclingToString(CyclingSession s,string titel)
        {
            var finalString = titel + ":\n";
            finalString += "Datum: " + s.When+"\n";
            if(!(s.Distance==null))finalString += "Afstand: " + s.Distance+"km\n";
            finalString += "Tijd: " + s.Time + "\n";
            if (!(s.AverageSpeed == null)) finalString += "Gemidelde Snelheid: " + s.AverageSpeed + "\n";
            if (!(s.AverageWatt == null)) finalString += "Gemodelde Watt: " + s.AverageWatt + "\n";
            finalString += "Training tipe: " + s.TrainingType + "\n";
            if (!String.IsNullOrWhiteSpace(s.Comments)) finalString += "Comentaar: " + s.Comments + "\n";
            finalString += "Fiets tipe: " + s.BikeType + "\n";
            return finalString;
        }
        private string RunnungToString(RunningSession s, string titel)
        {
            var finalString = titel + "\n";
            finalString += "Datum: " + s.When + "\n";
            finalString += "Afstand: " + s.Distance + "m\n";
            finalString += "Tijd: " + s.Time + "\n";
            if (!(s.AverageSpeed == 0)) finalString += "Gemidelde Snelheid: " + s.AverageSpeed + "\n";
            finalString += "Training tipe: " + s.TrainingType + "\n" ;
            if (!String.IsNullOrWhiteSpace(s.Comments)) finalString += "Comentaar: " + s.Comments + "\n";
            return finalString;
        }


    }
}
