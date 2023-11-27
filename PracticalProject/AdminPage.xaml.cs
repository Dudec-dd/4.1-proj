using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Data.SqlTypes;

namespace PracticalProject
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {

        
        public AdminPage()
        {

            InitializeComponent();
        }
        

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEventAndActivity());
        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if(DataG.SelectedItem != null) { 
                Event selectedEvent = Event.GetEventByName((DataG.SelectedItem as EventToShow).Название);
                selectedEvent.RemoveEvent();
                MessageBox.Show("Мероприятие удалено!");
                DataG.ItemsSource = new List<User>();
                DataG.ItemsSource = Event.ShowEvents();
            }
            else
            {
                MessageBox.Show("Выберите значение в таблице");
            }
            
            DataG.ItemsSource = Event.ShowEvents();
        }

        

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DataG.ItemsSource = Event.ShowEvents();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            List<EventToShow> events = DataG.ItemsSource as List<EventToShow>;
            int i = 0;
            foreach(var  eventToShow in events)
            {
                if (i > Event.Events.Count-1) break;
                if(eventToShow != null)
                {
                    Event.Events[i].EventName = eventToShow.Название;
                    Event.Events[i].EventTheme = eventToShow.Тема;
                }
                
                i++;
            }
        }
    }

}
