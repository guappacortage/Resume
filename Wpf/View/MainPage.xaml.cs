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
using Wpf.Model;

namespace Wpf.View
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage
    {
        Core db = new Core();
        int idUser = Properties.Settings.Default.idClient;
        int idRole = Properties.Settings.Default.idRole;
        public MainPage()
        {
            InitializeComponent();
            if (idRole == 1 || idRole == 2)
            {
                BtnCheckResumes.Visibility = Visibility.Visible;
                BtnCreateResume.Visibility = Visibility.Collapsed;
            }
            if (idRole == 3)
            {
                BtnCheckResumes.Visibility = Visibility.Collapsed;
                BtnCreateResume.Visibility = Visibility.Visible;
            }
            if (idRole == 1)
            {
                BtnAddEmployer.Visibility = Visibility.Visible;
            }
        }

        private void BtnCheckResums_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ResumeListPage());
        }

        private void BtnCreateResume_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreateResumePage());
        }

        private void BtnAddEmployer_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddEmployerPage());
        }
    }
}
