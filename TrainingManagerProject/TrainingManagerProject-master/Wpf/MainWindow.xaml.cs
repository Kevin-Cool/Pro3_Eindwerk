using DomainLibrary.Domain;
using DataLayer;
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

namespace Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TrainingManager m = new TrainingManager(new UnitOfWork(new TrainingContext("Production")));
        }

        private void NieuweFiets_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new Fiets();
            newForm.Show();
        }
        private void NieuwLoop_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new Loop();
            newForm.Show();
        }


        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            
        }


    }
}
