using list_of_events.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list_of_events.ViewModels.Pages
{
    public class TravelViewModel : ViewModelBase
    {
        private ObservableCollection<CityEvent> InfoCollectionTravel;
        public TravelViewModel(ObservableCollection<CityEvent> travel_events)
        {
            InfoCollectionTravel = new ObservableCollection<CityEvent>();
            var array = travel_events;
            for (int i = 0; i < travel_events.Count(); i++)
            {
                if (array[i].Category.Contains("Экскурсия") == true || array[i].Category.Contains("экскурсия") == true)
                {
                    if (array[i].Description.Length > 134)
                    {
                        array[i].Description = array[i].Description.Substring(0, 134) + "...";
                    }
                    InfoCollectionTravel.Add(new CityEvent
                    {
                        Header = array[i].Header,
                        Description = array[i].Description,
                        Image = array[i].Image,
                        Date = array[i].Date,
                        Category = array[i].Category,
                        Price = array[i].Price
                    });
                }
            }
        }

        public ObservableCollection<CityEvent> InfoCollectionTravels
        {
            get => InfoCollectionTravel;
            set { this.RaiseAndSetIfChanged(ref InfoCollectionTravel, value); }
        }
    }
}
