using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace Wpf.View
{
    /// <summary>
    /// Логика взаимодействия для CreateResumePage.xaml
    /// </summary>
    public partial class CreateResumePage : Page
    {
        Core db = new Core();
        List<Languages> languageslist = new List<Languages>();
        List<EducationGrade> educationGrades = new List<EducationGrade>();
        List<Categories> categories = new List<Categories>();
        private StackPanel PastJobsAddStackPanel = new StackPanel();
        private StackPanel EducationPlacesNewStackPanel = new StackPanel();
        private StackPanel LanguagesNewStackPanel = new StackPanel();
        private StackPanel CoursesAddStackPanel = new StackPanel();
        List <string> courseslist = new List<string>();
        List <DateTime> coursesdatelist = new List<DateTime>();
        List<string> pastjobstextlist = new List<string>();
        List<int> languageslistint = new List<int>();
        List<DateTime> pastjobsdatestartlist = new List<DateTime>();
        List<DateTime> pastjobsdateendlist = new List<DateTime>();
        List<string> educationplacestextlist = new List<string>();
        List<DateTime> educationplacesdatestartlist = new List<DateTime>();
        List<DateTime> educationplacesdateendlist = new List<DateTime>();
        byte[] image_bytes = new byte[0];
        bool checkimageadded = false;

        public CreateResumePage()
        {
            InitializeComponent();
            educationGrades = db.context.EducationGrade.ToList();
            categories = db.context.Categories.ToList();
            PastJobsAddStackPanel = new StackPanel();
            PastJobsStackPanel.Children.Add(PastJobsAddStackPanel);
            EducationPlacesNewStackPanel = new StackPanel();
            EducationPlacesStackPanel.Children.Add(EducationPlacesNewStackPanel);
            LanguagesNewStackPanel = new StackPanel();
            LanguagesStackPanel.Children.Add(LanguagesNewStackPanel);
            CoursesAddStackPanel = new StackPanel();
            CoursesStackPanel.Children.Add(CoursesAddStackPanel);
            CategoriesComboBox.ItemsSource = categories;
            EducationGradeComboBox.ItemsSource = educationGrades;
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CreateCourse();
                CreatePastJob();
                CreateEducationPlace();
                CreateLanguage();
                string gender = "";
                string army = "";
                if (MaleRadioButton.IsChecked == true)
                {
                    gender = "Мужской";
                    if (YesArmyRadioButton.IsChecked == true)
                    {
                        army = "Служил";
                    }
                    if (NoArmyRadioButton.IsChecked == true) 
                    {
                        army = "Не служил";
                    }
                }
                if (FemaleRadioButton.IsChecked == true) 
                {
                    gender = "Женский";
                    army = null;
                }
                string children = "";
                if (HaveChildren.IsChecked == true)
                {
                    children = "Есть";
                }
                if (DontHaveChildren.IsChecked == true)
                {
                    children = "Нет";
                }
                string driverlicense = "Отсутствует";
                if (HaveDriverLicense.IsChecked == true)
                {
                    driverlicense = "Есть";
                }
                if (BirthdayDate.SelectedDate != null || BirthdayDate.SelectedDate > DateTime.Now)
                {
                    if (!String.IsNullOrEmpty(TBoxSeriaPassport.Text) || TBoxSeriaPassport.Text.Any(char.IsLetter))
                    {
                        if (!String.IsNullOrEmpty(TBoxNumberPassport.Text) || TBoxNumberPassport.Text.Any(char.IsLetter))
                        {
                            if (EducationGradeComboBox.SelectedValue != null)
                            {
                                if (CategoriesComboBox.SelectedValue != null)
                                {
                                    SearcherInfoVM newsearcher = new SearcherInfoVM();
                                    if (newsearcher.CheckCreateResume(TBoxName.Text, TBoxSurname.Text, TBoxPatronimyc.Text, TBoxAdress.Text, TBoxPhone.Text, TBoxEmail.Text,
                                        TBoxCity.Text, TBoxFamily.Text, children, army, gender))
                                    {
                                        newsearcher.AddSearcher(TBoxName.Text, TBoxSurname.Text, TBoxPatronimyc.Text, TBoxAdress.Text, TBoxPhone.Text, TBoxEmail.Text,
                                            TBoxCity.Text, BirthdayDate.SelectedDate.Value, TBoxFamily.Text, Convert.ToInt32(TBoxSeriaPassport.Text), Convert.ToInt32(TBoxNumberPassport.Text), children, gender, army,
                                            TBoxPersonal.Text, driverlicense, pastjobstextlist, pastjobsdatestartlist, pastjobsdateendlist, educationplacestextlist, educationplacesdatestartlist,
                                            educationplacesdateendlist, (int)EducationGradeComboBox.SelectedValue, languageslistint, courseslist, coursesdatelist, TBoxComputerSkills.Text,
                                            (int)CategoriesComboBox.SelectedValue, image_bytes, checkimageadded);
                                        MessageBox.Show("Вы успешно разместили резюме. Возвращение на главную страницу");
                                        this.NavigationService.Navigate(new MainPage());
                                    }
                                }
                                else
                                {
                                    throw new Exception("Вы не указали сферу деятельности");
                                }
                            }
                            else
                            {
                                throw new Exception("Вы не указали уровень образования");
                            }
                        }
                        else
                        {
                            throw new Exception("Номер паспорта введен некорректно");
                        }
                    }
                    else
                    {
                        throw new Exception("Серия паспорта введена некорректно");
                    }
                }
                else
                {
                    throw new Exception("Дата рождения введена некорректно");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MaleRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            ArmyLabel.Visibility = Visibility.Visible;
            ArmyStackPanel.Visibility = Visibility.Visible;
        }

        private void FemaleRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            ArmyLabel.Visibility = Visibility.Collapsed;
            ArmyStackPanel.Visibility = Visibility.Collapsed;
        }

        private void AddPastJobClick(object sender, RoutedEventArgs e)
        {
            var newJobsAddStackPanel = new StackPanel();
            newJobsAddStackPanel.Orientation = Orientation.Vertical;
            newJobsAddStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = Brushes.White, Text = "Название места работы" });
            newJobsAddStackPanel.Children.Add(new TextBox { Width = 130, Height = 22, Name = "PastJobTextBox" });
            newJobsAddStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = Brushes.White, Text = "Дата начала работы" });
            newJobsAddStackPanel.Children.Add(new DatePicker { Width = 130, Height = 22, Name = "DatePickerStartJob" });
            newJobsAddStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = Brushes.White, Text = "Дата окончания работы" });
            newJobsAddStackPanel.Children.Add(new DatePicker { Width = 130, Height = 22, Name = "DatePickerEndJob" });
            newJobsAddStackPanel.Margin = new Thickness(10);
            PastJobsAddStackPanel.Children.Add(newJobsAddStackPanel);
        }

        private void CreatePastJob()
        {
            foreach (StackPanel stack in PastJobsAddStackPanel.Children)
            {
                foreach (var child in stack.Children)
                {
                    if (child is TextBox checkpastjobs)
                    {
                        string pastjob = checkpastjobs.Text;
                        if (!String.IsNullOrEmpty(pastjob))
                        {
                            pastjobstextlist.Add(pastjob);
                        }
                    }
                    if (child is DatePicker checkpastjobsdatestart && checkpastjobsdatestart.Name == "DatePickerStartJob")
                    {
                        DateTime pastjobdatestart = checkpastjobsdatestart.SelectedDate.Value;
                        if (pastjobdatestart != null)
                        {
                            pastjobsdatestartlist.Add(pastjobdatestart);
                        }
                    }
                    if (child is DatePicker checkpastjobsdateend && checkpastjobsdateend.Name == "DatePickerEndJob")
                    {
                        DateTime pastjobdateend = checkpastjobsdateend.SelectedDate.Value;
                        if (pastjobdateend != null)
                        {
                            pastjobsdateendlist.Add(pastjobdateend);
                        }
                    }
                }
            }
        }

        private void AddEducationPlaceClick(object sender, RoutedEventArgs e)
        {
            var newPlaceEducationStackPanel = new StackPanel();
            newPlaceEducationStackPanel.Orientation = Orientation.Vertical;
            newPlaceEducationStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = Brushes.White, Text = "Название места учебы" });
            newPlaceEducationStackPanel.Children.Add(new TextBox { Width = 130, Height = 22, Name = "EducationPlaceTextBox" });
            newPlaceEducationStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = Brushes.White, Text = "Дата начала учебы" });
            newPlaceEducationStackPanel.Children.Add(new DatePicker { Width = 130, Height = 22, Name = "DatePickerStartEducation" });
            newPlaceEducationStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = Brushes.White, Text = "Дата окончания учебы" });
            newPlaceEducationStackPanel.Children.Add(new DatePicker { Width = 130, Height = 22, Name = "DatePickerEndEducation" });
            newPlaceEducationStackPanel.Margin = new Thickness(10);
            EducationPlacesNewStackPanel.Children.Add(newPlaceEducationStackPanel);
        }

        private void CreateEducationPlace()
        {
            foreach (StackPanel stack in EducationPlacesNewStackPanel.Children)
            {
                foreach (var child in stack.Children)
                {
                    if (child is TextBox checkeducationplacestext)
                    {
                        string educationplace = checkeducationplacestext.Text;
                        if (!String.IsNullOrEmpty(educationplace))
                        {
                            educationplacestextlist.Add(educationplace);
                        }
                    }
                    if (child is DatePicker checkedplacesdatestart && checkedplacesdatestart.Name == "DatePickerStartEducation")
                    {
                        DateTime edplacedatestart = checkedplacesdatestart.SelectedDate.Value;
                        if (checkedplacesdatestart != null)
                        {
                            educationplacesdatestartlist.Add(edplacedatestart);
                        }
                    }
                    if (child is DatePicker checkedplacesdateend && checkedplacesdateend.Name == "DatePickerEndEducation")
                    {
                        DateTime edplacedateend = checkedplacesdateend.SelectedDate.Value;
                        if (edplacedateend != null)
                        {
                            educationplacesdateendlist.Add(edplacedateend);
                        }
                    }
                }
            }
        }

        private void AddLanguageClick(object sender, RoutedEventArgs e)
        {
            languageslist = db.context.Languages.ToList();
            var newLanguageStackPanel = new StackPanel();
            newLanguageStackPanel.Orientation = Orientation.Vertical;
            newLanguageStackPanel.Children.Add(new ComboBox { Width = 130, Height = 22, ItemsSource = languageslist, DisplayMemberPath = "TitleLanguage", SelectedValuePath ="IdLanguage", Name = "LanguageComboBoxAdded" });
            newLanguageStackPanel.Margin = new Thickness(10);
            LanguagesNewStackPanel.Children.Add(newLanguageStackPanel) ;
        }

        public void CreateLanguage()
        {
            foreach (StackPanel stack in LanguagesNewStackPanel.Children)
            {
                foreach (var child in stack.Children)
                {
                    if (child is ComboBox languagescheck)
                    {
                        int language = (int)languagescheck.SelectedValue;
                        languageslistint.Add(language);
                    }
                }
            }
        }

        public void CreateCourse()
        {
            foreach (StackPanel stack in CoursesAddStackPanel.Children)
            {
                foreach (var child in stack.Children)
                {
                    if (child is TextBox coursescheck)
                    {
                        string course = coursescheck.Text;
                        courseslist.Add(course);
                    }
                    if (child is DatePicker coursesdate)
                    {
                        DateTime coursedate = coursesdate.SelectedDate.Value;
                        coursesdatelist.Add(coursedate);
                    }
                }
            }
        }

        private void AddCourseClick(object sender, RoutedEventArgs e)
        {
            var newCoursesStackPanel = new StackPanel();
            newCoursesStackPanel.Orientation = Orientation.Vertical;
            newCoursesStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, TextAlignment = TextAlignment.Center, Foreground = Brushes.White, Text = "Название курса" });
            newCoursesStackPanel.Children.Add(new TextBox { Width = 130, Height = 22, Name = "TBoxCourses" });
            newCoursesStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, TextAlignment=TextAlignment.Center, Foreground = Brushes.White, Text = "Дата прохождения курса" });
            newCoursesStackPanel.Children.Add(new DatePicker { Width = 130, Height = 22, Name = "YearOfCourse" });
            newCoursesStackPanel.Margin = new Thickness(10);
            CoursesAddStackPanel.Children.Add(newCoursesStackPanel);
        }

        private void AddPhotoClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();   
            openFileDialog.ShowDialog();
            image_bytes = File.ReadAllBytes(openFileDialog.FileName);
            checkimageadded = true;
        }
    }
}
