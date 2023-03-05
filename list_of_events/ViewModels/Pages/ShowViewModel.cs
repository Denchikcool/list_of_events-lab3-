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
    public class ShowViewModel : ViewModelBase
    {
        private ObservableCollection<CityEvent> InfoCollectionShow;
        public ShowViewModel(ObservableCollection<CityEvent> show_events)
        {
            InfoCollectionShow = new ObservableCollection<CityEvent>();
            var array = show_events;
            for (int i = 0; i < show_events.Count(); i++)
            {
                if (array[i].Category.Contains("Шоу") == true || array[i].Category.Contains("шоу") == true)
                {
                    if (array[i].Description.Length > 134)
                    {
                        array[i].Description = array[i].Description.Substring(0, 134) + "...";
                    }
                    InfoCollectionShow.Add(new CityEvent
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

        public ObservableCollection<CityEvent> InfoCollectionShows
        {
            get => InfoCollectionShow;
            set { this.RaiseAndSetIfChanged(ref InfoCollectionShow, value); }
        }
    }
}
