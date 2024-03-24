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
            // Utilisez Navigation.PopAsync pour revenir à la page précédente
            await Navigation.PopAsync();
        }
    }
}
