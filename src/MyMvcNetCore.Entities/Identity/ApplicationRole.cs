using Microsoft.AspNetCore.Identity;

namespace MyMvcNetCore.Entities.Identity;

public class ApplicationRole : IdentityRole<int>
{
    public ApplicationRole(string name)
  : base(name)
    {

    }
}
