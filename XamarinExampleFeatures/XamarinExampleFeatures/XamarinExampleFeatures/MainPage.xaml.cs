using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinExampleFeatures
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnLocation.Clicked += BtnLocation_Clicked;
        }

        private async void BtnLocation_Clicked(object sender, EventArgs e)
        {
            var location = await Localizator.GetLocation();
            var encoded = await location.EncodeLocation();
        }
    }
}
