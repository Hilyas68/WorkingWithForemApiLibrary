using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Forem.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorkingWithForemApiLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticlesService _articlesService;

        public ArticleController(IArticlesService articlesService)
        {
            _articlesService = articlesService;
        }



        [HttpGet("getAllArticles")]
        public async Task<IActionResult> GetAllArticles(int page, int itemPerPage)
        {
            var articlesService = new ArticlesService(new Uri("https://dev.to/"), new HttpClient());
            return Ok(await articlesService.GetArticlesAsync(page, itemPerPage));
        }
    }
}
