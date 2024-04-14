using AxelPIGNOL.Models;
using AxelPIGNOL.ViewModels;

namespace AxelPIGNOL
{
    public partial class FavoritesPage : ContentPage
    {
        int count = 0;

        public FavoritesPage()
        {
            InitializeComponent();
        }

        private async void OnAddBeerClicked(object sender, EventArgs e)
        {
            var beer = new Beer
            {
                Name = nameEntry.Text,
                Price = priceEntry.Text,
                Rating = new Rating
                {
                    Average = double.Parse(averageRatingEntry.Text),
                    Reviews = int.Parse(reviewsEntry.Text)
                },
                Image = imageUrlEntry.Text
            };

            var viewModel = BindingContext as BeerViewModel;
            viewModel?.AddBeer(beer);

            await DisplayAlert("Bravo", "La bière a bien été ajouté", "OK");
            await Navigation.PopAsync();
        }
    }

}
