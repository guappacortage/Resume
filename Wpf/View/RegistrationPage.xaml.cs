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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        Core db = new Core();
        List<Users> arrayUsers;
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            int checkClient = db.context.Users.Where(x => x.Username == TBoxLogin.Text).Count();
            if (TBoxLogin.Text != String.Empty & PBoxPassword.Password != String.Empty
             && !String.IsNullOrWhiteSpace(TBoxLogin.Text)
             && !String.IsNullOrWhiteSpace(PBoxPassword.Password))
            {
                if (checkClient == 0)
                {
                    Users newUser = new Users()
                    {
                        Username = TBoxLogin.Text,
                        Password = PBoxPassword.Password,
                        RoleId = 3
                    };
                    db.context.Users.Add(newUser);
                    db.context.SaveChanges();
                    MessageBox.Show("Вы успешно зарегистрировались. Возвращение на страницу авторизации");
                    this.NavigationService.Navigate(new LoginPage());
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином уже существует.");
                }
            }
            else
            {
                MessageBox.Show("Вы не заполнили поля.");
            }
        }
    }
}
