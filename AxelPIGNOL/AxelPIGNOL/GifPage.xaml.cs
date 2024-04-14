using Microsoft.Maui.Controls;
using System;

namespace AxelPIGNOL
{
    public partial class GifPage : ContentPage
    {
        public GifPage()
        {
            InitializeComponent();
        }

        private async void ReturnToHomeClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
