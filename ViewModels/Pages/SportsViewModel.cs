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
    public class SportsViewModel : ViewModelBase
    {
        private ObservableCollection<CityEvent> InfoCollectionSports;
        public SportsViewModel(ObservableCollection<CityEvent> sports_events)
        {
            InfoCollectionSports = new ObservableCollection<CityEvent>();
            var array = sports_events;
            for (int i = 0; i < sports_events.Count(); i++)
            {
                if (array[i].Category.Contains("Спорт") == true || array[i].Category.Contains("спорт") == true)
                {
                    if (array[i].Description.Length > 134)
                    {
                        array[i].Description = array[i].Description.Substring(0, 134) + "...";
                    }
                    InfoCollectionSports.Add(new CityEvent
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

        public ObservableCollection<CityEvent> InfoCollectionSportss
        {
            get => InfoCollectionSports;
            set { this.RaiseAndSetIfChanged(ref InfoCollectionSports, value); }
        }
    }
}
