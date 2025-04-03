using Microsoft.EntityFrameworkCore;
using shortit.Data;
using shortit.Interface;
using shortit.models;
using shortit.models.Dto;

namespace shortit.UrlService
{
    public class UrlService : IUrlService
    {
        private readonly ShortenDbContext _shortenDbContext;
        //private readonly Random _random  = new();
    
        public UrlService(ShortenDbContext shortenDbContext)
        {
            _shortenDbContext = shortenDbContext;
        }

        public async Task<string> ShortenUrl(OriginalUrl urlRequest, HttpContext httpContext)
        {
            if(!Uri.TryCreate(urlRequest.Url, UriKind.Absolute, out  _))
            {
                throw new ArgumentException("Invalid URL has been provided");
            }
            var shortCode = GenerateShortCode();
            
            var newUrl = new OriginalUrl{
                 Url = urlRequest.Url,
                 shortUrl = shortCode
            };

            _shortenDbContext.Add(newUrl);
            await _shortenDbContext.SaveChangesAsync();

            return  $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/{shortCode}";
            

        }

        public async Task<string> RedirectToOriginalUrl(string shortCode)
        {
            var url = await _shortenDbContext.originalUrls.
            FirstOrDefaultAsync(u=> u.shortUrl == shortCode.Trim());
                        

            // var url =await  _shortenDbContext.originalUrls
            // .FirstOrDefaultAsync( u=> u.shortUrl == shortCode);

            // var url = await _shortenDbContext.originalUrls
            // .FirstOrDefaultAsync(u => u.shortUrl == shortCode.Trim());
            if(url == null)
            {
                throw new KeyNotFoundException("Short Url Not Found");
            }

            return url.Url;

        }
        

        private string GenerateShortCode()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 7)
            .Select(s=>s[random.Next(s.Length)])
            .ToArray());
            
        }
    }
}
