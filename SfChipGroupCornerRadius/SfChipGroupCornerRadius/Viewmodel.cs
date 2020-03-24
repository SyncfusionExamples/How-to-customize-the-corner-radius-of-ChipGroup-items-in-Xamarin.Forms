using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace SfChipGroupCornerRadius
{
    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Model> items = new ObservableCollection<Model>();
        public ObservableCollection<Model> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
                RaisePropertyChanged("Items");
            }
        }

        public ViewModel()
        {
            Items.Add(new Model() { Name = "Dom" });
            Items.Add(new Model() { Name = "Mary" });
            Items.Add(new Model() { Name = "Jeny" });
            Items.Add(new Model() { Name = "Mark" });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
