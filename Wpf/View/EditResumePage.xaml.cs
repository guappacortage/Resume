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
    /// Логика взаимодействия для EditResumePage.xaml
    /// </summary>
    public partial class EditResumePage : Page
    {
        Core db = new Core();
        List<SearchersInfo> searchersInfo = new List<SearchersInfo>();
        List<EducationGrade> educationGrades = new List<EducationGrade>();
        List<Categories> categories = new List<Categories>();
        List<PreviousJobs> pastJobs = new List<PreviousJobs>();
        List<EducationPlace> educationPlaces = new List<EducationPlace>();
        List<UserCourses> courses = new List<UserCourses>();
        List<UserLanguages> languages = new List<UserLanguages>();
        List<Languages> alllanguages = new List<Languages>();
        List<AdditionalInfo> addinfo = new List<AdditionalInfo>();
        List<UserComputerSkills> computerSkills = new List<UserComputerSkills>();
        List<int> languageslistint = new List<int>();
        List<string> courseslist = new List<string>();
        List<string> educationplacestextlist = new List<string>();
        List<DateTime> educationplacesdatestartlist = new List<DateTime>();
        List<DateTime> educationplacesdateendlist = new List<DateTime>();
        List<DateTime> coursesdatelist = new List<DateTime>();
        List<string> pastjobstextlist = new List<string>();
        List<DateTime> pastjobsdatestartlist = new List<DateTime>();
        List<DateTime> pastjobsdateendlist = new List<DateTime>();
        UserEducationGrade userEdGrade = new UserEducationGrade();
        UserCategories userCategory = new UserCategories();
        int globaliduser = 0;
        public EditResumePage(int iduser)
        {
            InitializeComponent();
            categories = db.context.Categories.ToList();
            educationGrades = db.context.EducationGrade.ToList();
            EducationGradeComboBox.ItemsSource = educationGrades;
            CategoriesComboBox.ItemsSource = categories;
            globaliduser = iduser;
            searchersInfo = db.context.SearchersInfo.Where(x => x.IdSearcher == iduser).ToList();
            pastJobs = db.context.PreviousJobs.Where(x => x.IdSearcher == iduser).ToList();
            educationPlaces = db.context.EducationPlace.Where(x => x.IdSearcher == iduser).ToList();
            courses = db.context.UserCourses.Where(x => x.IdSearcher == iduser).ToList();
            languages = db.context.UserLanguages.Where(x => x.IdSearcher == iduser).ToList();
            addinfo = db.context.AdditionalInfo.Where(x => x.IdSearcher == iduser).ToList();
            computerSkills = db.context.UserComputerSkills.Where(x => x.    IdSearcher == iduser).ToList();
            userEdGrade = db.context.UserEducationGrade.Where(x => x.IdSearcher == iduser).FirstOrDefault();
            EducationGradeComboBox.SelectedValue = userEdGrade.IdEducationGrade;
            userCategory = db.context.UserCategories.Where(x => x.  IdSearcher == iduser).FirstOrDefault();
            CategoriesComboBox.SelectedValue = userCategory.IdCategory;
            foreach (var item in searchersInfo)
            {
                TBoxName.Text = item.Name;
                TBoxSurname.Text = item.Surname;
                TBoxPatronimyc.Text = item.Patronymic;
                TBoxEmail.Text = item.Email;
                TBoxPhone.Text = item.Phone;
                TBoxFamily.Text = item.FamilyStatus;
                TBoxNumberPassport.Text = Convert.ToString(item.PassportNumber);
                TBoxSeriaPassport.Text = Convert.ToString(item.PassportSeria);
                TBoxCity.Text = item.City;
                BirthdayDate.SelectedDate = item.Birthday;
                TBoxAdress.Text = item.Address;
                if (item.Gender == "Мужской")
                {
                    MaleRadioButton.IsChecked = true;
                    if (item.Army == "Служил")
                    {
                        YesArmyRadioButton.IsChecked = true;
                    }
                    else
                    {
                        NoArmyRadioButton.IsChecked = true;
                    }
                }
                else
                {
                    FemaleRadioButton.IsChecked = true;
                }
                if (item.Children == "Есть")
                {
                    HaveChildren.IsChecked = true;
                }
                else
                {
                    DontHaveChildren.IsChecked = true;
                }
            }
            foreach (var item in pastJobs)
            {
                var newJobsAddStackPanel = new StackPanel();
                newJobsAddStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = Brushes.White, Text = "Название места работы" });
                newJobsAddStackPanel.Children.Add(new TextBox { Width = 130, Height = 22, Text = item.NameOfPreviousJob, Name = "PastJobTextBox" });
                newJobsAddStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = Brushes.White, Text = "Дата начала работы" });
                newJobsAddStackPanel.Children.Add(new DatePicker { Width = 130, Height = 22, SelectedDate = item.DateOfStartPreviousJob, Name = "DatePickerStartJob" });
                newJobsAddStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = Brushes.White, Text = "Дата окончания работы" });
                newJobsAddStackPanel.Children.Add(new DatePicker { Width = 130, Height = 22, SelectedDate = item.DateOfEndPreviousJob, Name = "DatePickerEndJob" });
                newJobsAddStackPanel.Margin = new Thickness(10);
                PastJobsStackPanel.Children.Add(newJobsAddStackPanel);
            }
            foreach (var item in educationPlaces)
            {
                var newPlaceEducationStackPanel = new StackPanel();
                newPlaceEducationStackPanel.Orientation = Orientation.Vertical;
                newPlaceEducationStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = Brushes.White, Text = "Название места учебы" });
                newPlaceEducationStackPanel.Children.Add(new TextBox { Width = 130, Height = 22, Text = item.PlaceOfEducation, Name = "EducationPlaceTextBox" });
                newPlaceEducationStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = Brushes.White, Text = "Дата начала учебы" });
                newPlaceEducationStackPanel.Children.Add(new DatePicker { Width = 130, Height = 22, SelectedDate = item.DateOfStartEducation, Name = "DatePickerStartEducation" });
                newPlaceEducationStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = Brushes.White, Text = "Дата окончания учебы" });
                newPlaceEducationStackPanel.Children.Add(new DatePicker { Width = 130, Height = 22, SelectedDate = item.DateOfEndEducation, Name = "DatePickerEndEducation" });
                newPlaceEducationStackPanel.Margin = new Thickness(10);
                EducationPlacesStackPanel.Children.Add(newPlaceEducationStackPanel);
            }
            foreach (var item in courses)
            {
                var newCoursesStackPanel = new StackPanel();
                newCoursesStackPanel.Orientation = Orientation.Vertical;
                newCoursesStackPanel.Children.Add(new TextBox { Width = 130, Height = 22, Text = item.Course, Name = "TBoxCourses" }); ;
                newCoursesStackPanel.Children.Add(new DatePicker { Width = 130, Height = 22, SelectedDate = item.CourseDate, Name = "YearOfCourse" });
                newCoursesStackPanel.Margin = new Thickness(10);
                CoursesStackPanel.Children.Add(newCoursesStackPanel);
            }
            foreach (var item in languages)
            {
                alllanguages = db.context.Languages.ToList();
                var newLanguageStackPanel = new StackPanel();
                newLanguageStackPanel.Orientation = Orientation.Vertical;
                newLanguageStackPanel.Children.Add(new ComboBox { Width = 130, Height = 22, ItemsSource = alllanguages, DisplayMemberPath = "TitleLanguage",
                    SelectedValuePath = "IdLanguage", Name = "LanguageComboBoxAdded", SelectedValue = item.LanguagesId });
                newLanguageStackPanel.Margin = new Thickness(10);
                LanguagesStackPanel.Children.Add(newLanguageStackPanel);
            }
            foreach (var item in addinfo)
            {
                TBoxPersonal.Text = item.PersonalQualities;
                if (item.DriverLicense == "Есть")
                {
                    HaveDriverLicense.IsChecked = true;
                }
                else
                {
                    HaveDriverLicense.IsChecked = false;
                }
            }
            foreach (var item in computerSkills)
            {
                TBoxComputerSkills.Text = item.ComputerSkill;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            CreateCourse();
            CreateEducationPlace();
            CreateLanguage();
            CreatePastJob();
            string gender = "";
            string army = "";
            if (MaleRadioButton.IsChecked == true)
            {
                gender = "Мужской";
                if (YesArmyRadioButton.IsChecked == true)
                {
                    army = "Служил";
                }
                else
                {
                    army = "Не служил";
                }
            }
            else
            {
                gender = "Женский";
                army = null;
            }
            string children = "";
            if (HaveChildren.IsChecked == true)
            {
                children = "Есть";
            }
            else
            {
                children = "Нет";
            }
            string driverlicense = "Отсутствует";
            if (HaveDriverLicense.IsChecked == true)
            {
                driverlicense = "Есть";
            }
            SearcherInfoVM searcher = new SearcherInfoVM();
            searcher.EditSearcher(globaliduser, TBoxName.Text, TBoxSurname.Text, TBoxPatronimyc.Text, TBoxAdress.Text, TBoxPhone.Text, TBoxEmail.Text,
                    TBoxCity.Text, BirthdayDate.SelectedDate.Value, TBoxFamily.Text, Convert.ToInt32(TBoxSeriaPassport.Text), Convert.ToInt32(TBoxNumberPassport.Text), children, gender, army,
                    TBoxPersonal.Text, driverlicense, pastjobstextlist, pastjobsdatestartlist, pastjobsdateendlist, educationplacestextlist, educationplacesdatestartlist,
                    educationplacesdateendlist, (int)EducationGradeComboBox.SelectedValue, languageslistint, courseslist, coursesdatelist, TBoxComputerSkills.Text, (int)CategoriesComboBox.SelectedValue);
            MessageBox.Show("Вы успешно изменили резюме. Возвращение на главную страницу");
            this.NavigationService.Navigate(new MainPage());
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

        public void CreateLanguage()
        {
            foreach (StackPanel stack in LanguagesStackPanel.Children)
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

        private void CreatePastJob()
        {
            foreach (StackPanel stack in PastJobsStackPanel.Children)
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

        private void CreateEducationPlace()
        {
            foreach (StackPanel stack in EducationPlacesStackPanel.Children)
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

        public void CreateCourse()
        {
            foreach (StackPanel stack in CoursesStackPanel.Children)
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
    }
}
