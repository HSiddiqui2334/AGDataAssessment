using RestSharp;
using FluentAssertions;
using System.Net;

[Binding]
public class ApiTests
{
    private readonly ApiClient _client;
    private const string BaseUrl = "https://jsonplaceholder.typicode.com";

    public ApiTests()
    {
        _client = new ApiClient(BaseUrl);
    }


    [Given(@"user gets all post requests")]
    public void GivenUserGetsAllPostRequests()
    {
        // Arrange
        var request = new RestRequest("/posts", Method.Get);

        // Act
        var response = _client.Execute(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNullOrEmpty();
    }

    [Given(@"user gets all post requests by comment id")]
    public void GivenUserGetsAllPostRequestsByCommentId()
    {
        // Arrange
        var postId = 1;
        var request = new RestRequest($"/comments", Method.Get);
        request.AddParameter("postId", postId);

        // Act
        var response = _client.Execute(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNullOrEmpty();
    }

    [Given(@"user post method")]
    public void GivenUserPostMethod()
    {
        var request = new RestRequest("/posts", Method.Post);
        request.AddJsonBody(new
        {
            title = "foo",
            body = "bar",
            userId = 1
        });

        // Act
        var response = _client.Execute(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        response.Content.Should().Contain("id");
    }

    [Given(@"user post request for comment")]
    public void GivenUserPostRequestForComment()
    {
        // Arrange
        var postId = 1;
        var request = new RestRequest($"/posts/{postId}/comments", Method.Post);
        request.AddJsonBody(new
        {
            name = "My Comment",
            email = "test@example.com",
            body = "This is a test comment."
        });

        // Act
        var response = _client.Execute(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        response.Content.Should().Contain("id");
    }

    [Given(@"user update request by put method")]
    public void GivenUserUpdateRequestByPutMethod()
    {
        // Arrange
        var postId = 1;
        var request = new RestRequest($"/posts/{postId}", Method.Put);
        request.AddJsonBody(new
        {
            id = postId,
            title = "updated title",
            body = "updated body",
            userId = 1
        });

        // Act
        var response = _client.Execute(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().Contain("updated title");
    }

    [Given(@"user delete the post by postid")]
    public void GivenUserDeleteThePostByPostid()
    {
        // Arrange
        var postId = 1;
        var request = new RestRequest($"/posts/{postId}", Method.Delete);

        // Act
        var response = _client.Execute(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }


}
