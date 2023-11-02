using FacilityFeedback.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;

namespace WebApp.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var url = httpContext.Request.GetEncodedUrl().ToLower();
            if (!url.Contains("login") && !url.Contains("logout") && !url.Contains("error"))
            {
                var userString = httpContext.Session.GetString("ACCOUNT");
                if (userString != null)
                {
                    var userConvert = JsonConvert.DeserializeObject<Account>(userString);
                    if (userConvert != null)
                    {
                        // User page
                        if (url.Contains("user"))
                        {
                            if (userConvert.Role != "USER")
                            {
                                httpContext.Response.Redirect("/Error");
                                return;
                            }
                        }
                        else
                        {
                            // Staff page
                            if (url.Contains("staff"))
                            {
                                if (userConvert.Role != "STAFF")
                                {
                                    httpContext.Response.Redirect("/Error");
                                    return;
                                }
                            }
                            else
                            {
                                // Admin page
                                if (userConvert.Role != "ADMIN")
                                {
                                    httpContext.Response.Redirect("/Error");
                                    return;
                                }

                            }
                        }
                    }
                }
                else
                {
                    httpContext.Response.Redirect("/Login");
                    return;
                }
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }
}
