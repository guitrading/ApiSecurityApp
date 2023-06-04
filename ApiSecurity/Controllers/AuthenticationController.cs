using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSecurity.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{

    public record AuthenticationData(string? UserName, string?Password); // equivalent of a creating a classes
    // with two properties and setting up a constructor that takes two parameters. Readonly object.
    public record UserData(int UserId, string UserName); 

    [HttpPost("token")]  // route becomes api/authentication/token
    public ActionResult<string> Authenticate([FromBody] AuthenticationData data) // method to authenticate user
    {
        return Ok("Authenticated");
    }

    private UserData ValidateCredentials(AuthenticationData data)
    {
        // THIS IS NOT PRODUCTION CODE
        // DO NOT STORE PASSWORDS IN PLAIN TEXT
        // This is simulating a database lookup

        if (CompareValues(data.UserName, "admin") && CompareValues(data.Password, "password"))
        {
            return new UserData(1, data.UserName!);
        }
        else
        {
            throw new Exception("Invalid Credentials");
        }

        if (CompareValues(data.UserName, "sstorm") && CompareValues(data.Password, "password"))
        {
            return new UserData(1, data.UserName!);
        }
        else
        {
            throw new Exception("Invalid Credentials");
        }

    }

    private bool CompareValues(string? actual, string expected) 
    { 
        if (actual is not null)
        {
            if (actual.Equals(expected))
            {
                return true;
            }

            
        }
        return false;
    }

}
