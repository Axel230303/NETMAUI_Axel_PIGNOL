namespace AxelPIGNOL
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnGifPageClicked(object sender, EventArgs e)
        {
            // Naviguer vers la page qui contient le GIF
            await Navigation.PushAsync(new GifPage());
        }

    }
}