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
    /// Логика взаимодействия для ResumeListPage.xaml
    /// </summary>
    public partial class ResumeListPage : Page
    {
        Core db = new Core();
        List <SearchersInfo> searchersInfo = new List <SearchersInfo> ();
        List<Categories> categories = new List<Categories>();
        List<UserCategories> usercategories = new List<UserCategories>();
        int idRole = Properties.Settings.Default.idRole;
        public ResumeListPage()
        {
            InitializeComponent();
            if (idRole == 2)
            {
                searchersInfo = db.context.SearchersInfo.Where(x => x.Status != 1).ToList();
            }
            else
            {
                searchersInfo = db.context.SearchersInfo.ToList();
            }
            categories = db.context.Categories.ToList();
            SearchersListView.ItemsSource = searchersInfo;
            CategoryComboBox.ItemsSource = categories;
        }

        private void TextBoxSearchTextChanged(object sender, TextChangedEventArgs e)
        {

            if (TypeOfSearchComboBox.SelectedIndex == 0)
            {
                searchersInfo = searchersInfo.Where(x => Convert.ToString(x.PassportNumber).Contains(TBoxSearch.Text.ToLower())).ToList();
            }
            if (TypeOfSearchComboBox.SelectedIndex == 1)
            {
                searchersInfo = searchersInfo.Where(x => Convert.ToString(x.PassportSeria).Contains(TBoxSearch.Text.ToLower())).ToList();
            }
            if (TypeOfSearchComboBox.SelectedIndex == 2)
            {
                searchersInfo = searchersInfo.Where(x => x.Name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            }
            if (TypeOfSearchComboBox.SelectedIndex == 3)
            {
                searchersInfo = searchersInfo.Where(x => x.Surname.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            }
            if (TypeOfSearchComboBox.SelectedIndex == 4)
            {
                searchersInfo = searchersInfo.Where(x => x.Patronymic.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            }
            SearchersListView.ItemsSource = searchersInfo;
        }

        private void ComboBoxCategorySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            usercategories.Clear();
            searchersInfo.Clear();
            usercategories = db.context.UserCategories.Where(x => x.IdCategory == (int)CategoryComboBox.SelectedValue).ToList();
            foreach (var category in usercategories)
            {
                searchersInfo.AddRange(db.context.SearchersInfo.Where(x => x.IdSearcher == category.IdSearcher).ToList());
            }
            SearchersListView.ItemsSource = searchersInfo;
        }

        private void OpenClick(object sender, MouseButtonEventArgs e)
        {
            Image activeElement = sender as Image;
            SearchersInfo activeSearcher = activeElement.DataContext as SearchersInfo;
            int idSearcher = activeSearcher.IdSearcher;
            this.NavigationService.Navigate(new ResumePage(idSearcher));
        }

        private void CheckClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (idRole == 2)
                {
                    Image activeElement = sender as Image;
                    SearchersInfo activeSearcher = activeElement.DataContext as SearchersInfo;
                    int idSearcher = activeSearcher.IdSearcher;
                    SearcherInfoVM EditStatus = new SearcherInfoVM();
                    EditStatus.EditStatus(idSearcher, 1);
                    MessageBox.Show("Вы успешно отметили резюме как подходящее вашей компании. Возвращение на главную страницу");
                    this.NavigationService.Navigate(new MainPage());
                }
                else
                {
                    throw new Exception("Вы не являетесь работодателем для использования данной команды");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditClick(object sender, MouseButtonEventArgs e)
        {
            try
            { 
                if (idRole == 1)
                {
                    Image activeElement = sender as Image;
                    SearchersInfo activeSearcher = activeElement.DataContext as SearchersInfo;
                    int idSearcher = activeSearcher.IdSearcher;
                    this.NavigationService.Navigate(new EditResumePage(idSearcher));
                }
                else
                {
                    throw new Exception("Вы не обладаете правами администратора для использования данной команды");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteClick(object sender, MouseButtonEventArgs e)
        {
            try
            { 
                if (idRole == 1)
                {
                    Image activeElement = sender as Image;
                    SearchersInfo activeSearcher = activeElement.DataContext as SearchersInfo;
                    int idSearcher = activeSearcher.IdSearcher;
                    MessageBoxResult rez = MessageBox.Show($"Вы уверены что хотите удалить пользователя \"{activeSearcher.Name}" + $" {activeSearcher.Surname}" + $" {activeSearcher.Patronymic}\"?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (rez == MessageBoxResult.Yes)
                    {
                        SearcherInfoVM deleteSearcher = new SearcherInfoVM();
                        deleteSearcher.DeleteSearcher(idSearcher);
                        MessageBox.Show("Вы успешно удалили пользователя. Возвращение на главную страницу");
                        this.NavigationService.Navigate(new MainPage());
                    }
                }
                else
                {
                    throw new Exception("Вы не обладаете правами администратора для использования данной команды");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }
    }
}
