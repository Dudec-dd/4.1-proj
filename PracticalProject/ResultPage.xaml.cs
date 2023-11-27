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

namespace PracticalProject
{
    /// <summary>
    /// Логика взаимодействия для ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
        public ResultPage()
        {
            InitializeComponent();
        }
        
        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DGField.SelectedItem != null) {
                UserToShow userToShow = DGField.SelectedValue as UserToShow;
                User.GetUser(userToShow.login).UserScore.Add(User.EventToEdit.EventName,Int32.Parse(ResCBox.SelectedValue.ToString()));
            if (User.GetUser((DGField.SelectedValue as UserToShow).login).UserScore[User.EventToEdit.EventName] == Int32.Parse(ResCBox.SelectedValue.ToString()))
                MessageBox.Show("Готово!");
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> l = new List<string>();
            l.Add("1");
            l.Add("2");
            l.Add("3");
            l.Add("4");
            l.Add("5");
            ResCBox.ItemsSource = l;
            ResCBox.SelectedIndex = 0;
            List<UserToShow> list = new List<UserToShow>();
            foreach (var item in User.EventToEdit.EventUsers)
            {
                list.Add(new UserToShow(item.name, item.surename, item.birthdayDate, item.login));
            }
            DGField.ItemsSource = list;
        }
    }
}
