using AxelPIGNOL.Models;
using AxelPIGNOL.ViewModels;

namespace AxelPIGNOL
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            this.BindingContext = new BeerViewModel();
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedBeer = e.CurrentSelection.FirstOrDefault() as Beer;
            if (selectedBeer != null)
            {
                await Navigation.PushAsync(new BeerDetailPage(selectedBeer));
            }

            // Désélectionner l'élément
            ((CollectionView)sender).SelectedItem = null;

        }
    }
}