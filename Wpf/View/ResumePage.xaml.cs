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
using System.Drawing;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using static Wpf.Controllers.PhotoVM;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using Microsoft.Office.Interop.Word;
using System.Collections;

namespace Wpf.View
{
    /// <summary>
    /// Логика взаимодействия для ResumePage.xaml
    /// </summary>
    public partial class ResumePage : System.Windows.Controls.Page
    {
        Core db = new Core();
        SearchersInfo searchersInfo = new SearchersInfo();
        List<PreviousJobs> prevJobs = new List<PreviousJobs>();
        List<EducationPlace> educationPlaces = new List<EducationPlace>();
        List<UserLanguages> userLanguages = new List<UserLanguages>();
        LinkForPhoto photolink = new LinkForPhoto();
        UserEducationGrade educationgradeuser = new UserEducationGrade();
        EducationGrade educationgrade = new EducationGrade();
        UserCategories userCategory = new UserCategories();
        Model.Categories category = new Model.Categories();
        AdditionalInfo addInfo = new AdditionalInfo();
        UserComputerSkills userComputerSkill = new UserComputerSkills();
        List<UserCourses> userCourses = new List<UserCourses>();
        public ResumePage(int idSearcher)
        {
            InitializeComponent();
            photolink = db.context.LinkForPhoto.Where(x => x.IdSearcher == idSearcher).FirstOrDefault();
            educationgradeuser = db.context.UserEducationGrade.Where(x => x.IdSearcher == idSearcher).FirstOrDefault();
            educationgrade = db.context.EducationGrade.Where(x => x.IdEducationGrade == educationgradeuser.IdEducationGrade).FirstOrDefault();
            userCategory = db.context.UserCategories.Where(x => x.IdSearcher == idSearcher).FirstOrDefault();
            category = db.context.Categories.Where(x => x.IdCategory == userCategory.IdCategory).FirstOrDefault();
            userLanguages = db.context.UserLanguages.Where(x => x.IdSearcher == idSearcher).ToList();
            addInfo = db.context.AdditionalInfo.Where(x => x.IdSearcher == idSearcher).FirstOrDefault();
            userCourses = db.context.UserCourses.Where(x => x.IdSearcher == idSearcher).ToList();
            userComputerSkill = db.context.UserComputerSkills.Where(x => x.IdSearcher == idSearcher).FirstOrDefault();
            List<Model.Languages> languagesoutputlist = new List<Model.Languages>();
            string langoutput = "";
            foreach (var userlang in userLanguages)
            {
                languagesoutputlist.AddRange(db.context.Languages.Where(x => x.IdLanguage == userlang.LanguagesId));
            }
            for (int i = 0; i < languagesoutputlist.Count; i++)
            {
                if (i == 0)
                {
                    langoutput = languagesoutputlist[i].TitleLanguage;
                }
                else
                {
                    langoutput = langoutput + ", " + languagesoutputlist[i].TitleLanguage;
                }
            }
            prevJobs = db.context.PreviousJobs.Where(x => x.IdSearcher == idSearcher).ToList();
            educationPlaces = db.context.EducationPlace.Where(x => x.IdSearcher == idSearcher).ToList();
            if (photolink.PhotoLink != null)
            {
                ResumeImage.Source = ByteImage.Convert(ByteImage.GetImageFromByteArray(photolink.PhotoLink));
            }
            searchersInfo = db.context.SearchersInfo.Where(x => x.IdSearcher == idSearcher).FirstOrDefault();
            TBlockName.Text = searchersInfo.Name;
            TBlockSurname.Text = searchersInfo.Surname;
            TBlockPatronimyc.Text = searchersInfo.Patronymic;
            TBlockPhone.Text = searchersInfo.Phone;
            TBlockEmail.Text = searchersInfo.Email;
            TBlockCity.Text = searchersInfo.City;
            TBlockGender.Text = searchersInfo.Gender;
            TBlockBirthday.Text = searchersInfo.Birthday.ToString("dd/MM/yyyy");
            TBlockAdress.Text = searchersInfo.Address;
            TBlockFamily.Text = searchersInfo.FamilyStatus;
            TBlockChildren.Text = searchersInfo.Children;
            TBlockNumberPassport.Text = Convert.ToString(searchersInfo.PassportNumber);
            TBlockSeriaPassport.Text = Convert.ToString(searchersInfo.PassportSeria);
            if (searchersInfo.Gender == "Мужской")
            {
               TBlockArmy.Text = searchersInfo.Army;
               ArmyStackPanel.Visibility = Visibility.Visible;
            }
            TBlockGradeOfEducation.Text = educationgrade.GradeOfEducation;
            if (prevJobs != null)
            {
                foreach (var item in prevJobs)
                {
                    var newJobsAddStackPanel = new StackPanel();
                    newJobsAddStackPanel.Orientation = Orientation.Vertical;
                    newJobsAddStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = System.Windows.Media.Brushes.White, Text = "Название места работы:" });
                    newJobsAddStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = System.Windows.Media.Brushes.White, Text = item.NameOfPreviousJob });
                    newJobsAddStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = System.Windows.Media.Brushes.White, Text = "Дата начала работы:" });
                    newJobsAddStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = System.Windows.Media.Brushes.White, Text = Convert.ToDateTime(item.DateOfStartPreviousJob).ToString("dd/MM/yyyy") });
                    newJobsAddStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = System.Windows.Media.Brushes.White, Text = "Дата окончания работы:" });
                    newJobsAddStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = System.Windows.Media.Brushes.White, Text = Convert.ToDateTime(item.DateOfEndPreviousJob).ToString("dd/MM/yyyy") });
                    newJobsAddStackPanel.Margin = new Thickness(5);
                    PastJobsStackPanel.Children.Add(newJobsAddStackPanel);
                }
            }
            if (educationPlaces != null)
            {
                foreach (var item in educationPlaces)
                {
                    var newEducationStackPanel = new StackPanel();
                    newEducationStackPanel.Orientation = Orientation.Vertical;
                    newEducationStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = System.Windows.Media.Brushes.White, Text = "Название места учебы:" });
                    newEducationStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = System.Windows.Media.Brushes.White, Text = item.PlaceOfEducation });
                    newEducationStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = System.Windows.Media.Brushes.White, Text = "Дата начала учебы:" });
                    newEducationStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = System.Windows.Media.Brushes.White, Text = Convert.ToDateTime(item.DateOfStartEducation).ToString("dd/MM/yyyy") });
                    newEducationStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = System.Windows.Media.Brushes.White, Text = "Дата окончания учебы:" });
                    newEducationStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = System.Windows.Media.Brushes.White, Text = Convert.ToDateTime(item.DateOfEndEducation).ToString("dd/MM/yyyy") });
                    newEducationStackPanel.Margin = new Thickness(5);
                    EducationPlacesStackPanel.Children.Add(newEducationStackPanel);
                }
            }
            if (userCourses != null)
            {
                foreach (var item in userCourses)
                {
                    var newCoursesStackPanel = new StackPanel();
                    newCoursesStackPanel.Orientation = Orientation.Vertical;
                    newCoursesStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = System.Windows.Media.Brushes.White, Text = "Название курса:" });
                    newCoursesStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = System.Windows.Media.Brushes.White, Text = item.Course });
                    newCoursesStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = System.Windows.Media.Brushes.White, Text = "Дата прохождения курса:" });
                    newCoursesStackPanel.Children.Add(new TextBlock { Width = 130, Height = 22, Foreground = System.Windows.Media.Brushes.White, Text = Convert.ToDateTime(item.CourseDate).ToString("dd/MM/yyyy") });
                    newCoursesStackPanel.Margin = new Thickness(5);
                    CoursesStackPanel.Children.Add(newCoursesStackPanel);
                }
            }
            TBlockLanguages.Text = langoutput;
            TBlockCategories.Text = category.CategoryName;
            TBlockPersonal.Text = addInfo.PersonalQualities;
            TBlockDriverLicense.Text = addInfo.DriverLicense;
            TBlockComputerSkills.Text = userComputerSkill.ComputerSkill; 
        }

        private void CreateDocument()
        {
            try
            {
                string pastjobs = "";
                int i = 0;
                foreach (StackPanel stack in PastJobsStackPanel.Children)
                {
                    foreach (var child in stack.Children)
                    {
                        if (child is TextBlock textblock && i % 2 == 0)
                        {
                            pastjobs = pastjobs + textblock.Text + " ";
                        }
                        if (child is TextBlock textBlock && i % 2 != 0)
                        {
                            pastjobs = pastjobs + textBlock.Text + Environment.NewLine;
                        }
                        i++;
                    }
                }
                string educationplaces = "";
                int j = 0;
                foreach (StackPanel stack in EducationPlacesStackPanel.Children)
                {
                    foreach (var child in stack.Children)
                    {
                        if (child is TextBlock textblock && j % 2 == 0)
                        {
                            educationplaces = educationplaces + textblock.Text + " ";
                        }
                        if (child is TextBlock textBlock && j % 2 != 0)
                        {
                            educationplaces = educationplaces + textBlock.Text + Environment.NewLine;
                        }
                        j++;
                    }
                }
                string courses = "";
                int k = 0;
                foreach (StackPanel stack in CoursesStackPanel.Children)
                {
                    foreach (var child in stack.Children)
                    {
                        if (child is TextBlock textblock && k % 2 == 0)
                        {
                            courses = courses + textblock.Text + " ";
                        }
                        if (child is TextBlock textBlock && k % 2 != 0)
                        {
                            courses = courses + textBlock.Text + Environment.NewLine;
                        }
                        k++;
                    }
                }
                //Create an instance for word app
                Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();

                    //Set animation status for word application
                    winword.ShowAnimation = false;

                    //Set status for word application is to be visible or not.
                    winword.Visible = false;

                    //Create a missing variable for missing value
                    object missing = System.Reflection.Missing.Value;

                    //Create a new document
                    Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                    //Add header into the document
                    foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
                    {
                        //Get the header range and add the header details.
                        Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                        headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                        headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                        headerRange.Font.Size = 20;
                        headerRange.Text = $"Резюме {TBlockName.Text} {TBlockSurname.Text} {TBlockPatronimyc.Text}";
                    }

                    //adding text to document
                    document.Content.SetRange(0, 0);
                    document.Content.Text = $"Телефон: {TBlockPhone.Text} " + Environment.NewLine + $"Почта: {TBlockEmail.Text} " + Environment.NewLine
                        + $"Пол: {TBlockGender.Text} " + Environment.NewLine + $"Город: {TBlockGender.Text} " + Environment.NewLine + $"Адрес: {TBlockAdress.Text} " + Environment.NewLine
                        + $"День рождения: {TBlockBirthday.Text} " + Environment.NewLine + $"Уровень образования: {TBlockGradeOfEducation.Text} " + Environment.NewLine
                        + $"Семейное положение: {TBlockFamily.Text} " + Environment.NewLine + $"Наличие детей: {TBlockChildren.Text} " + Environment.NewLine
                        + $"Серия паспорта: {TBlockSeriaPassport.Text} " + Environment.NewLine + $"Номер паспорта: {TBlockNumberPassport.Text} " + Environment.NewLine
                        + $"О себе: {TBlockPersonal.Text} " + Environment.NewLine + $"Водительские права: {TBlockDriverLicense.Text} " + Environment.NewLine + $"Компьютерные навыки: {TBlockComputerSkills.Text}" 
                        + Environment.NewLine + $"Знаю языки: {TBlockLanguages.Text} " + Environment.NewLine + $"Сфера деятельности: {TBlockCategories.Text} " + Environment.NewLine 
                        + $"{pastjobs}" + $"{educationplaces}" + $"{courses}";

                    //Save the document
                    object filename = $@"C:\Users\Public\Резюме {TBlockName.Text} {TBlockSurname.Text} {TBlockPatronimyc.Text}.docx";
                    document.SaveAs(ref filename);
                    document.Close(ref missing, ref missing, ref missing);
                    document = null;
                    MessageBox.Show("Вы успешно сохранили резюме. Возвращение к странице списка резюме");
                    this.NavigationService.Navigate(new ResumeListPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSaveWord_Click(object sender, RoutedEventArgs e)
        {
            CreateDocument();
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
