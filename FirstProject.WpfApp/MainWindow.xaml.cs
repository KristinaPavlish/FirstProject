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
using FirstProject.Bll.Implementations;
using FirstProject.Bll.Models;

namespace FirstProject.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Company company { get; set; }

        public MainWindow()
        {
            company = new Company();
            company.Employees = new List<Employee>();
            InitializeComponent();
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            CompanyService companyService = new CompanyService(new EmployeeService());
            Employee employee = new Employee()
            {
                FullName = textBoxFullName.Text,
                HourlyWage = Convert.ToUInt32(textBoxHourlyWage.Text),
                WorkExperience = Convert.ToUInt32(textBoxWorkExperience.Text),
                NumberOfHoursWorked = Convert.ToUInt32(textBoxNumberOfHoursWorked.Text),
                RateOfCompletedWorks = Convert.ToUInt32(textBoxRateOfCompletedWorks.Text) 
            };
            companyService.HireEmployee(company,employee);
            ApplyDataBinding();
        }

        private void TextBoxRateOfCompletedWorks_OnGotFocus(object sender, RoutedEventArgs e)
        {
            textBoxRateOfCompletedWorks.Text = "";
        }

        private void TextBoxNumberOfHoursWorked_OnGotFocus(object sender, RoutedEventArgs e)
        {
            textBoxNumberOfHoursWorked.Text = "";
        }

        private void TextBoxWorkExperience_OnGotFocus(object sender, RoutedEventArgs e)
        {
            textBoxWorkExperience.Text = "";
        }

        private void TextBoxHourlyWage_OnGotFocus(object sender, RoutedEventArgs e)
        {
            textBoxHourlyWage.Text = "";
        }

        private void TextBoxFullName_OnGotFocus(object sender, RoutedEventArgs e)
        {
            textBoxFullName.Text = "";
        }

        private void ApplyDataBinding()
        {
            lvDataBinding.ItemsSource = null;
            lvDataBinding.ItemsSource = company.Employees;
            companyNameLabel.Content = company.Name;
        }

        private void CompanyNameButton_OnClick(object sender, RoutedEventArgs e)
        {
            company.Name = companyNameTextBox.Text;
            companyNameLabel.Content = company.Name;
        }

        private void SaveChanges_OnClick(object sender, RoutedEventArgs e)
        {
            JsonFileService jsonFileService = new JsonFileService();
            jsonFileService.Save(company, "CompanyFromWpf.json");
        }

        private void UploadChanges_OnClick(object sender, RoutedEventArgs e)
        {
            JsonFileService jsonFileService = new JsonFileService();
            company = jsonFileService.Upload("CompanyFromWpf.json");
            ApplyDataBinding();
        }
    }
}
///TODO  add to main window option for edit or delete employee in company
/// TODO add key to employee 