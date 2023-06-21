using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace PlaidDotNetWithoutPackage.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BankController : ControllerBase
{
    private const string PlaidBaseUrl = "https://sandbox.plaid.com";
    private const string PlaidClientId = "64915d0f804bdc0019280530";
    private const string PlaidSecret = "1101bdf48c575e279b8acaa56c4f0c";
    private const string PlaidAccessToken = "access-sandbox-4b372bc5-4426-4924-b17c-0ba302576edd";


    [HttpGet("balance")]
    public async Task<IActionResult> GetBalance()
    {
        var httpClient = new HttpClient();

        var request = new HttpRequestMessage(new HttpMethod("POST"), "https://sandbox.plaid.com/accounts/balance/get");

        var requestBody = new
        {
            client_id = PlaidClientId,
            secret = PlaidSecret,
            access_token = PlaidAccessToken,
            options = new
            {
                account_ids = new string[] { }
            }
        };

        request.Content = new StringContent(JsonConvert.SerializeObject(requestBody));

        
        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

        var response = await httpClient.SendAsync(request);

        //try
        //{
        //    var response = await httpClient.SendAsync(request);
        //    response.EnsureSuccessStatusCode();

        //    var responseContent = await response.Content.ReadAsStringAsync();
        //    // Handle the response based on your requirements

        //    return Ok(responseContent);
        //}
        //catch (HttpRequestException)
        //{
        //    return StatusCode(500, "Failed to retrieve bank balance.");
        //}
        return Ok(response);
        
    }
}
