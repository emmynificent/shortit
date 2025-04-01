using shortit.models;
using shortit.models.Dto;
namespace shortit.Interface 
{
    public interface IUrlService
    {
        Task <OriginalUrl> ShortenUrl(OriginalUrl urlRequest, HttpContext httpContext);
        Task<string> RedirectToOriginalUrl (string shortCode);
    }
}