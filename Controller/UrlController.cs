using Microsoft.AspNetCore.Mvc;
using shortit.Interface;
using AutoMapper;
using shortit.models.Dto;
using shortit.models;

namespace shortit.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IUrlService _urlService;
        private readonly IMapper _mapper;
        public UrlController(IUrlService urlService, IMapper mapper)
        {
            _urlService = urlService;
            _mapper = mapper;
        }

        [HttpPost("shorten")]
        public async Task<IActionResult> ShortenUrl(shortenUrlRequestDto request)
        {
            try{
                var requestMap = _mapper.Map<OriginalUrl>(request);
                var response = await _urlService.ShortenUrl(requestMap, HttpContext);
                var responseMap = _mapper.Map<shortenUrlResponseDto>(response);
                
                //return Redirect(responseMap);
                return Ok(responseMap);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // [HttpGet("shortcode")]
        // public async Task<IActionResult> RedirectUrl(string shortCode)
        // {
        //     try{
        //         var originalUrls = await _urlService.RedirectToOriginalUrl(shortCode);
        //         return Redirect(originalUrls);
        //     }
        //     catch(KeyNotFoundException ex)
        //     {
        //         return NotFound(ex.Message);
        //     }
        // }

    }
}