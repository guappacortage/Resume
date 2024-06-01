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
using Wpf.Controllers;

namespace Wpf.View
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        Core db = new Core();
        List<Users> arrayUsers;
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UsersVM newObject = new UsersVM();
                if (TBoxLogin.Text != String.Empty & PBoxPassword.Password != String.Empty
                    && !String.IsNullOrWhiteSpace(TBoxLogin.Text)
                    && !String.IsNullOrWhiteSpace(PBoxPassword.Password))
                {
                    bool result = newObject.CheckAuth(TBoxLogin.Text, PBoxPassword.Password);
                    if (result)
                    {
                        arrayUsers = db.context.Users.Where(x => x.Username == TBoxLogin.Text).ToList();
                        foreach (var item in arrayUsers)
                        {
                            Properties.Settings.Default.idClient = item.IdUser;
                            Properties.Settings.Default.idRole = item.RoleId;
                            Properties.Settings.Default.Save();
                        }
                        this.NavigationService.Navigate(new MainPage());
                    }
                    else
                    {
                        MessageBox.Show("Такой пользователь не существует.");
                    }
                }
                else
                {
                    MessageBox.Show("Данные не введены");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegistrationPage());
        }
    }
}
