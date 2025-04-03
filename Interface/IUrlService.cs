using shortit.models;
using shortit.models.Dto;
namespace shortit.Interface 
{
    public interface IUrlService
    {
        Task <string> ShortenUrl(OriginalUrl urlRequest, HttpContext httpContext);
        Task<string> RedirectToOriginalUrl (string shortCode);
    }
}