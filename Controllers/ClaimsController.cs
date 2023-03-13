using Microsoft.AspNetCore.Mvc;
using ClaimsService;
using System.Linq;

namespace ClaimsService.Controllers;

[ApiController]
[Route("[controller]")]
public class ClaimsController : ControllerBase
{
    private static List<Claims> _claims = new List<Claims>() {
 new Claims() {
 ClaimId = 1,
 ClaimDate = new DateTime(2023, 02, 06, 12, 11, 0),
 CustomerId = 2266,
 Description = "Hvorfor kommer taxa'en ikke?"
 }
 };

    private readonly ILogger<ClaimsController> _logger;

    public ClaimsController(ILogger<ClaimsController> logger)
    {
        _logger = logger;
        _logger.LogInformation("Metode ClaimsController called at {time}", DateTime.Now,
                DateTime.UtcNow.ToLongTimeString());

    }

    [HttpGet("{claimId}", Name = "GetClaimById")]
    public Claims Get(int claimId)
    {
        _logger.LogInformation("Metode Get called at {time}", DateTime.Now,
                DateTime.UtcNow.ToLongTimeString());
        return _claims.Where(c => c.ClaimId == claimId).First();

    }


    //POST metode til at tilføje en ny claim. Indeholder en try/catch, så der kan logges fejl.
    [HttpPost("{claimId}", Name = "PostClaimById")]

    public List<Claims> Post([FromBody] Claims claims)
    {
        try
        {

            _claims.Add(claims);
            _logger.LogInformation("Metode Post called at {time}", DateTime.Now,
                DateTime.UtcNow.ToLongTimeString());
            return _claims;
        }
        catch (Exception ex)
        {
            _logger.LogError("Fejl ved kald af Post metode: {error}", ex.Message);
            throw ex;
        }

    }
}
