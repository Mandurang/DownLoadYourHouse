namespace DownLoadYourHouse.API
{
    public class GeoapifyService
    {
        private readonly HttpClient _client;

        public GeoapifyService()
        {
            _client = new HttpClient();
        }
        	
        public async Task<string> GeocodeAddressAsync(string address)
        {
            https://api.geoapify.com/v1/batch/geocode/search?&apiKey=02e9a303276b4367ba6a45ae7c96202a
            string apiKey = "02e9a303276b4367ba6a45ae7c96202a";
            string encodedAddress = Uri.EscapeDataString(address);
            string url = $"https://api.geoapify.com/v1/geocode/search?text={encodedAddress}&apiKey={apiKey}";

            HttpResponseMessage response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new HttpRequestException($"Error: {response.StatusCode}");
            }
        }
    }
}
