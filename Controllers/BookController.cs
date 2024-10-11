using ApiDockerStudy.Contexts;
using ApiDockerStudy.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiDockerStudy.Controllers;

/// <summary>
/// BookController
/// </summary>
/// <param name="context"></param>
[ApiController]
[Route("api/[controller]/[action]")]
public class BookController(AppDbContext context) : ControllerBase
{
    /// <summary>
    /// ëSåèéÊìæ
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IAsyncEnumerable<Book> Get()
    {
        return context.Books.AsAsyncEnumerable();
    }

    /// <summary>
    /// ìoò^
    /// </summary>
    /// <param name="title"></param>
    /// <param name="author"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task Post(string title, string author)
    {
        context.Books.Add(new()
        { 
            Title = title,
            Author = author,
        });

        await context.SaveChangesAsync();
    }
}
