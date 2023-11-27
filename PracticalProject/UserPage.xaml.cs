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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DataG.IsReadOnly = true;
            List<ScoreToShow> li = new List<ScoreToShow>();
            if (User.CurrentUser.UserScore.Count > 0) { 
            foreach(var ev in User.CurrentUser.UserScore)
            {
                li.Add(new ScoreToShow(ev.Key, ev.Value));
            }
            }

            DataG.ItemsSource = li;
            SaveBtn.IsEnabled = false;
            User us = User.CurrentUser;
        }
        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            List<UserToShow> l = DataG.ItemsSource as List<UserToShow>;
            User change = User.CurrentUser;
            change.name = l[0].name;
            change.surename = l[0].surname;
            change.birthdayDate = l[0].birthdayDate;
            change.login = l[0].login;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DataG.IsReadOnly = false;
            List<UserToShow> list = new List<UserToShow>();
            DataG.ItemsSource = list;
            list.Add(new UserToShow(User.CurrentUser.name,User.CurrentUser.surename,User.CurrentUser.birthdayDate,User.CurrentUser.login));
            
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveBtn.IsEnabled = true;
            DataG.IsReadOnly = false;
            List<UserToShow> list = new List<UserToShow>();
            DataG.ItemsSource = list;
            list.Add(new UserToShow(User.CurrentUser.name, User.CurrentUser.surename, User.CurrentUser.birthdayDate, User.CurrentUser.login));
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        class ScoreToShow
        {
            public string Мероприятие { get; set; }
            public int Балл { get; set; }
            public ScoreToShow(string vent, int score)
            {
                Мероприятие = vent;
                Балл = score;
            }
        }
    }
    
}
