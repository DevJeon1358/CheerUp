using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheerUp.Model
{
    public class Place : INotifyPropertyChanged
    {
        private int idx;
        public int Idx
        {
            get
            {
                return idx;
            }
            set
            {
                idx = value;
                NotifyPropertyChanged(nameof(Idx));
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged(nameof(name));
            }
        }

        private string explain;
        public string Explain
        {
            get
            {
                return explain;
            }
            set
            {
                explain = value;
                NotifyPropertyChanged(nameof(explain));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
