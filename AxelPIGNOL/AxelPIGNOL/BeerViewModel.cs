using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AxelPIGNOL.Models;

namespace AxelPIGNOL.ViewModels
{
    public class BeerViewModel
    {
        public ObservableCollection<Beer> Beers { get; } = new ObservableCollection<Beer>();

        public BeerViewModel()
        {
            Task.Run(() => LoadBeer());
        }

        private async Task LoadBeer()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://api.sampleapis.com/beers/ale");
            var beers = JsonSerializer.Deserialize<List<Beer>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (beers != null)
            {
                foreach (var beer in beers)
                {
                    Beers.Add(beer);
                }
            }
        }

        public void AddBeer(Beer beer)
        {
            Beers.Add(beer);
            Task.Run(() => SaveBeerAsync(beer));
        }

        private async Task SaveBeerAsync(Beer beer)
        {
            var httpClient = new HttpClient();

            var beerJson = JsonSerializer.Serialize(beer);
            var content = new StringContent(beerJson, System.Text.Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://api.sampleapis.com/beers/add", content);
        }
}
}
