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
    public class EducationViewModel : ViewModelBase
    {
        private ObservableCollection<CityEvent> InfoCollectionEducation;
        public EducationViewModel(ObservableCollection<CityEvent> education_events)
        {
            InfoCollectionEducation = new ObservableCollection<CityEvent>();
            var array = education_events;
            for (int i = 0; i < education_events.Count(); i++)
            {
                if (array[i].Category.Contains("Образование") == true || array[i].Category.Contains("образование") == true)
                {
                    if (array[i].Description.Length > 134)
                    {
                        array[i].Description = array[i].Description.Substring(0, 134) + "...";
                    }
                    InfoCollectionEducation.Add(new CityEvent
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

        public ObservableCollection<CityEvent> InfoCollectionEducations
        {
            get => InfoCollectionEducation;
            set { this.RaiseAndSetIfChanged(ref InfoCollectionEducation, value); }
        }
    }
}
