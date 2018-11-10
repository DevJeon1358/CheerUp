using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheerUp.Model
{
    public class Message : INotifyPropertyChanged
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

        private int place;
        public int Place
        {
            get
            {
                return place;
            }
            set
            {
                place = value;
                NotifyPropertyChanged(nameof(Place));
            }
        }

        private int user;
        public int User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                NotifyPropertyChanged(nameof(User));
            }
        }

        private string content;
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
                NotifyPropertyChanged(nameof(Content));
            }
        }

        private DateTime upTime;
        public DateTime UpTime
        {
            get
            {
                return upTime;
            }
            set
            {
                upTime = value;
                NotifyPropertyChanged(nameof(UpTime));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
