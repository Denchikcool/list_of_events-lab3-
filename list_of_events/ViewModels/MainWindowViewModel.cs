using list_of_events.Models;
using list_of_events.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace list_of_events.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<ViewModelBase> InfoCollection;
        private ObservableCollection<CityEvent> EventsCollection;

        public MainWindowViewModel()
        {
            EventsCollection = new ObservableCollection<CityEvent>();
            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<CityEvent>));
            using (StreamReader rd = new StreamReader(@"..\..\..\all_events.xml"))
            {
                EventsCollection = xs.Deserialize(rd) as ObservableCollection<CityEvent>;
            }

            InfoCollection = new ObservableCollection<ViewModelBase>();
            InfoCollection.Add(new KidsViewModel(EventsCollection));
            InfoCollection.Add(new SportsViewModel(EventsCollection));
            InfoCollection.Add(new CultureViewModel(EventsCollection));
            InfoCollection.Add(new TravelViewModel(EventsCollection));
            InfoCollection.Add(new LifestyleViewModel(EventsCollection));
            InfoCollection.Add(new PartyViewModel(EventsCollection));
            InfoCollection.Add(new EducationViewModel(EventsCollection));
            InfoCollection.Add(new OnlineViewModel(EventsCollection));
            InfoCollection.Add(new ShowViewModel(EventsCollection));

            //EventsCollection = new ObservableCollection<CityEvent>();

            
        }
 
        public object Kid
        {
            get => InfoCollection[0];
        }

        public object Sport
        {
            get => InfoCollection[1];
        }
        public object Culture
        {
            get => InfoCollection[2];
        }
        public object Travel
        {
            get => InfoCollection[3];
        }
        public object Lifestyle
        {
            get => InfoCollection[4];
        }
        public object Party
        {
            get => InfoCollection[5];
        }
        public object Education
        {
            get => InfoCollection[6];
        }
        public object Online
        {
            get => InfoCollection[7];
        }
        public object Show
        {
            get => InfoCollection[8];
        }
    }
}
