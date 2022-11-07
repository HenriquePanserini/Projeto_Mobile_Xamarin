using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppTol
{
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        
        public static MasterDetailPage masterDetail { get; set; }
        public MainPage()
        {
            InitializeComponent();
            this.Master = new Master();
            this.Detail = new NavigationPage(new Detail());
            App.masterDetail = this;
        }
    }
}
