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
    /// Логика взаимодействия для JuryPage.xaml
    /// </summary>
    public partial class JuryPage : Page
    {
        public JuryPage()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            List<EventToShow> eventToShows = new List<EventToShow>();
            foreach (var item in User.GetListForJury())
            {
                eventToShows.Add(new EventToShow(item.EventName, item.EventTheme, item.EventJury.name, item.EventOrg.name, item.EventModeratorsToString(), item.EventUsersToString(), item.EventActivitiesToString()));
            }
            DataG.ItemsSource = eventToShows;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(DataG.SelectedItem != null) { 
            User.EventToEdit = Event.GetEventByName((DataG.SelectedItem as EventToShow).Название);
            NavigationService.Navigate(new ResultPage());
        }
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
