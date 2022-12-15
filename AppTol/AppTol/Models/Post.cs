using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Newtonsoft.Json;

namespace AppTol.Models
{
    class Post : INotifyPropertyChanged
    {
        public int id { get; set; }

        private string _tittle;
        
        [JsonProperty("title")]
        public string Title
        {
            get => _title;
        }
    }
}
