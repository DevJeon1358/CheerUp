using CheerUp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheerUp.ViewModel
{
    public class PlaceViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Place> Items { get; }

        public PlaceViewModel()
        {
            Items = new ObservableCollection<Place>();
        }

        public void Add(Place item)
        {
            Items.Add(item);
        }

        public void Delete(Place item)
        {
            Items.Remove(item);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
