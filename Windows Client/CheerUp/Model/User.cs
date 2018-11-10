using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheerUp.Model
{
    public class User : INotifyPropertyChanged
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

        private string id;
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                NotifyPropertyChanged(nameof(Id));
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                NotifyPropertyChanged(nameof(Password));
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
                NotifyPropertyChanged(nameof(Name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
