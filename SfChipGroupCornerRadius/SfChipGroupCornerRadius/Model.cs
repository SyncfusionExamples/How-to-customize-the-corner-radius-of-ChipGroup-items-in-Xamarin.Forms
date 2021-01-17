﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SfChipGroupCornerRadius
{
    public class Model : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }

            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
