using AppTol.Views;
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
        
        public static FlyoutPage masterDetail { get; set; }
        public MainPage()
        {
            InitializeComponent();
            this.Master = new Master();
            this.Detail = new NavigationPage(new Detail());
            SizeChanged += MainPage_SizeChanged;
        }
        
        private void MainPage_SizeChanged(object sender, EventArgs e)
        {
            this.WidthRequest = Math.Min(this.Width, 300);
            
        }
    }
}
