using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace AppTol.Models
{
    class Post : INotifyPropertyChanged
    {
        public int id { get; set; }

        private string _title;
        
        [JsonProperty("title")]
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                //Notifica a sua View ou ViewModel que o valor que a propriedade
                //no modelo mudou e a view precisa ser atualizada
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
