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
    public class KidsViewModel : ViewModelBase
    {
        private ObservableCollection<CityEvent> InfoCollectionKids;
        public KidsViewModel(ObservableCollection<CityEvent> kids_events)
        {
            InfoCollectionKids = new ObservableCollection<CityEvent>();
            var array = kids_events;
            for (int i = 0; i < kids_events.Count(); i++)
            {
                if (array[i].Category.Contains("Для детей") == true || array[i].Category.Contains("для детей") == true)
                {
                    if (array[i].Description.Length > 134)
                    {
                        array[i].Description = array[i].Description.Substring(0, 134) + "...";
                    }

                    InfoCollectionKids.Add(new CityEvent
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

        public ObservableCollection<CityEvent> InfoCollectionKidss
        {
            get => InfoCollectionKids;
            set { this.RaiseAndSetIfChanged(ref InfoCollectionKids, value); }
        }
    }
}
