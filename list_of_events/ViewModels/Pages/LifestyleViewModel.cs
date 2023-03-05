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
    public class LifestyleViewModel : ViewModelBase
    {
        private ObservableCollection<CityEvent> InfoCollectionLifeStyle;
        public LifestyleViewModel(ObservableCollection<CityEvent> lifestyle_events)
        {
            InfoCollectionLifeStyle = new ObservableCollection<CityEvent>();
            var array = lifestyle_events;
            for (int i = 0; i < lifestyle_events.Count(); i++)
            {
                if (array[i].Category.Contains("Образ жизни") == true || array[i].Category.Contains("образ жизни") == true)
                {
                    if (array[i].Description.Length > 134)
                    {
                        array[i].Description = array[i].Description.Substring(0, 134) + "...";
                    }
                    InfoCollectionLifeStyle.Add(new CityEvent
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

        public ObservableCollection<CityEvent> InfoCollectionLifeStyles
        {
            get => InfoCollectionLifeStyle;
            set { this.RaiseAndSetIfChanged(ref InfoCollectionLifeStyle, value); }
        }
    }
}
