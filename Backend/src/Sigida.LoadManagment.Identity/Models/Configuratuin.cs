using IdentityModel;
using IdentityServer4.Models;

namespace Sigida.LoadManagment.Identity.Models;

public class Configuratuin
{
    public static IEnumerable<ApiScope> ApiScopes
        => new List<ApiScope>
        {
            new ApiScope("LoadManagment", "Web API")
        };

    public static IEnumerable<IdentityResource> IdentityResources
        => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiResource> ApiResources
        => new List<ApiResource>
        {
            new ApiResource("LoadManagment", "WebAPI", new[]{ JwtClaimTypes.Name })
            {
                Scopes = {"LoadManagment"}
            }
        };

    public static IEnumerable<Client> Clients
        => new List<Client>
        {
            new Client
            {
                ClientId = "load-managment-web-api",
                ClientName = "Load Managment",
                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,
                RequirePkce = true,
                RedirectUris =
                {
                    "http://.../signin-iodc"
                },
                AllowedCorsOrigins =
                {
                    "http://..."
                },
                PostLogoutRedirectUris =
                {
                    "http://.../signout-oidc"
                }

            }
        };
}
