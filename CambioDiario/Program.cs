//Exchange Rates API
//Taxa de câmbio diária

var client = new HttpClient();

try
{
    await GetExchangeRateAsync("USD", client);
    await GetExchangeRateAsync("ZAR", client);
    await GetExchangeRateAsync("EUR", client);
}
catch (HttpRequestException e)
{
    Console.WriteLine("\nException Caught!");
    Console.WriteLine("Message :{0} ", e.Message);
}

async Task GetExchangeRateAsync(string baseCurrency, HttpClient client)
{
    // Substitua YOUR_ACCESS_KEY pela sua chave de acesso
    HttpResponseMessage response = await client.GetAsync($"https://api.exchangeratesapi.io/latest?base={baseCurrency}&access_key=YOUR_ACCESS_KEY");
    response.EnsureSuccessStatusCode();
    string responseBody = await response.Content.ReadAsStringAsync();

    // Agora você tem a resposta em JSON, e pode fazer o parse e usar como quiser
    Console.WriteLine(responseBody);
}