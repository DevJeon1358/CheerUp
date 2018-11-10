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
    public class MessageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Message> Items { get; }

        public MessageViewModel()
        {
            Items = new ObservableCollection<Message>();
        }

        public void Add(Message item)
        {
            Items.Add(item);
        }

        public void Delete(Message item)
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
