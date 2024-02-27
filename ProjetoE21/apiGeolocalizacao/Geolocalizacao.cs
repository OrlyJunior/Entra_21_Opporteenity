using ProjetoE21.Dados;
using ProjetoE21.Models;

namespace ProjetoE21.apiGeolocalizacao
{
    public class Geolocalizacao
    {
        private readonly HttpClient _httpClient;
        private const string API_KEY = "de8ec31691d84fada09018809123c939";

        public Geolocalizacao()
        {
            _httpClient = new HttpClient();
        }

        public async Task GeocodingAsyncServicos()
        {
            var ruaJovem = Usuario.LogadoJ.Local.Rua;
            var cidadeJovem = Usuario.LogadoJ.Local.Cidade;

            var local = $"{ruaJovem}+{cidadeJovem}";
            var url1 = $"https://api.opencagedata.com/geocode/v1/json?q={local}&key={API_KEY}&pretty=1";

            double latitude1 = 0;
            double longitude1 = 0;

            var response1 = await _httpClient.GetAsync(url1);
            response1.EnsureSuccessStatusCode();
            var responseContent1 = await response1.Content.ReadAsStringAsync();
            dynamic item1 = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent1);

            latitude1 = item1.results[0].geometry.lat;
            longitude1 = item1.results[0].geometry.lng;


            foreach (var i in Listas.servicos)
            {
                var ruas = i.Local.Rua;
                var cidades = i.Local.Cidade;

                var endereco = $"{ruas}+{cidades}";
                var url2 = $"https://api.opencagedata.com/geocode/v1/json?q={endereco}&key={API_KEY}&pretty=1";

                double latitude2 = 0;
                double longitude2 = 0;

                var response2 = await _httpClient.GetAsync(url2);
                response2.EnsureSuccessStatusCode();
                var responseContent2 = await response2.Content.ReadAsStringAsync();
                dynamic item2 = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent2);

                latitude2 = item2.results[0].geometry.lat;
                longitude2 = item2.results[0].geometry.lng;

                var distancia = FormulaDeHaversine(latitude1, longitude1, latitude2, longitude2);

                i.Distancia = distancia;

                i.MostrarD = $"{Math.Round(distancia * 100) / 100}km";
            }

            Listas.servicos.OrderBy(servico => servico.Distancia);
        }

        public async Task GeocodingAsyncEmpregos()
        {
            var ruaJovem = Usuario.LogadoJ.Local.Rua;
            var cidadeJovem = Usuario.LogadoJ.Local.Cidade;

            var local = $"{ruaJovem}+{cidadeJovem}";
            var url1 = $"https://api.opencagedata.com/geocode/v1/json?q={local}&key={API_KEY}&pretty=1";

            double latitude1 = 0;
            double longitude1 = 0;

            var response1 = await _httpClient.GetAsync(url1);
            response1.EnsureSuccessStatusCode();
            var responseContent1 = await response1.Content.ReadAsStringAsync();
            dynamic item1 = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent1);

            latitude1 = item1.results[0].geometry.lat;
            longitude1 = item1.results[0].geometry.lng;


            foreach (var i in Listas.empregos)
            {
                var ruas = i.Local.Rua;
                var cidades = i.Local.Cidade;

                var endereco = $"{ruas}+{cidades}";
                var url2 = $"https://api.opencagedata.com/geocode/v1/json?q={endereco}&key={API_KEY}&pretty=1";

                double latitude2 = 0;
                double longitude2 = 0;

                var response2 = await _httpClient.GetAsync(url2);
                response2.EnsureSuccessStatusCode();
                var responseContent2 = await response2.Content.ReadAsStringAsync();
                dynamic item2 = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent2);

                latitude2 = item2.results[0].geometry.lat;
                longitude2 = item2.results[0].geometry.lng;

                var distancia = FormulaDeHaversine(latitude1, longitude1, latitude2, longitude2);

                i.Distancia = distancia;

                i.MostrarD = $"{Math.Round(distancia * 100) / 100}km";
            }

            Listas.empregos.OrderBy(emprego => emprego.Distancia);
        }


        public static double FormulaDeHaversine(double lat1, double lon1, double lat2, double lon2)
        {
            var R = 6371;
            var dLat = ToRadians(lat2 - lat1);
            var dLon = ToRadians(lon2 - lon1);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            var distance = R * c;

            return Math.Round(distance, 2);
        }

        public static double ToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
    }

    public class GeocodingResponse
    {
        public Result[] results { get; set; }
    }

    public class Result
    {
        public Geometry geometry { get; set; }
    }

    public class Geometry
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }
}
