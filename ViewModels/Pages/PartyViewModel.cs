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
    public class PartyViewModel : ViewModelBase
    {
        private ObservableCollection<CityEvent> InfoCollectionParty;
        public PartyViewModel(ObservableCollection<CityEvent> party_events)
        {
            InfoCollectionParty = new ObservableCollection<CityEvent>();
            var array = party_events;
            for (int i = 0; i < party_events.Count(); i++)
            {
                if (array[i].Category.Contains("Вечеринки") == true || array[i].Category.Contains("вечеринки") == true)
                {
                    if (array[i].Description.Length > 134)
                    {
                        array[i].Description = array[i].Description.Substring(0, 134) + "...";
                    }
                    InfoCollectionParty.Add(new CityEvent
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

        public ObservableCollection<CityEvent> InfoCollectionPartys
        {
            get => InfoCollectionParty;
            set { this.RaiseAndSetIfChanged(ref InfoCollectionParty, value); }
        }
    }
}
