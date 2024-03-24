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
            Task.Run(() => LoadBeersAsync());
        }

        private async Task LoadBeersAsync()
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
    }
}
