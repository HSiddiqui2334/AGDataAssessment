using RestSharp;

[Binding]
public class ApiClient
{
    
    private readonly RestClient _client;

    public ApiClient(string baseUrl)
    {
        _client = new RestClient(baseUrl);
    }

    public RestResponse Execute(RestRequest request)
    {
        return _client.Execute(request);
    }

    public RestResponse<T> Execute<T>(RestRequest request) where T : new()
    {
        return _client.Execute<T>(request);
    }
}
