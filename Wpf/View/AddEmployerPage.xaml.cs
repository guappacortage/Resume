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
using Wpf.Controllers;
using Wpf.Model;

namespace Wpf.View
{
    /// <summary>
    /// Логика взаимодействия для AddEmployerPage.xaml
    /// </summary>
    public partial class AddEmployerPage : Page
    {
        Core db = new Core();
        public AddEmployerPage()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EmployersInfoVM newEmployer = new EmployersInfoVM();
                if (newEmployer.EmployerCheck(TBoxNameOfOrganization.Text, TBoxLogin.Text, PasswordBoxPass.Password))
                {
                    newEmployer.AddNewEmployer(TBoxNameOfOrganization.Text, TBoxLogin.Text, PasswordBoxPass.Password);
                    MessageBox.Show("Вы успешно добавили работодателя. Возвращение на главную страницу");
                    this.NavigationService.Navigate(new MainPage());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
