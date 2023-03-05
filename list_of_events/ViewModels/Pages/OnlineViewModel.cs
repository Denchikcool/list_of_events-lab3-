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
    public class OnlineViewModel : ViewModelBase
    {
        private ObservableCollection<CityEvent> InfoCollectionOnline;
        public OnlineViewModel(ObservableCollection<CityEvent> online_events)
        {
            InfoCollectionOnline = new ObservableCollection<CityEvent>();
            var array = online_events;
            for (int i = 0; i < online_events.Count(); i++)
            {
                if (array[i].Category.Contains("Онлайн") == true || array[i].Category.Contains("онлайн") == true)
                {
                    if (array[i].Description.Length > 134)
                    {
                        array[i].Description = array[i].Description.Substring(0, 134) + "...";
                    }
                    InfoCollectionOnline.Add(new CityEvent
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

        public ObservableCollection<CityEvent> InfoCollectionOnlines
        {
            get => InfoCollectionOnline;
            set { this.RaiseAndSetIfChanged(ref InfoCollectionOnline, value); }
        }
    }
}
