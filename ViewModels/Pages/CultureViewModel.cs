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
    public class CultureViewModel : ViewModelBase
    {
        private ObservableCollection<CityEvent> InfoCollectionCulture;
        public CultureViewModel(ObservableCollection<CityEvent> culture_events)
        {
            InfoCollectionCulture = new ObservableCollection<CityEvent>();
            var array = culture_events;
            for (int i = 0; i < culture_events.Count(); i++)
            {
                if (array[i].Category.Contains("Культура") == true || array[i].Category.Contains("культура") == true)
                {
                    if (array[i].Description.Length > 135)
                    {
                        array[i].Description = array[i].Description.Substring(0, 134) + "...";
                    }
                    InfoCollectionCulture.Add(new CityEvent
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

        public ObservableCollection<CityEvent> InfoCollectionCultures
        {
            get => InfoCollectionCulture;
            set { this.RaiseAndSetIfChanged(ref InfoCollectionCulture, value); }
        }
    }
}
