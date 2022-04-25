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

namespace URE6XP_hft_2021222.WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            InstructorWindow instructorWindow = new InstructorWindow();
            instructorWindow.Show();
        }

        private void Button_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            PresentationWindow presentationWindow = new PresentationWindow();
            presentationWindow.Show();
        }

        private void Button_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            LactureHallWindow lactureHallWindow = new LactureHallWindow();
            lactureHallWindow.Show();
        }
    }
}
