using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        public readonly AppDbContext _db;
        public BlogController() 
        { 
            _db = new AppDbContext();
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            List<BlogModel> list = _db.Blogs.OrderByDescending(x=>x.BlogId).ToList();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult GetBlogs(int id)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if (item == null) 
            {
                return NotFound("Data not found");
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            _db.Blogs.Add(blog);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Saving success" : "Saving fail";
            return Ok(message);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id,
BlogModel blog)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if (item == null)
            {
                Console.WriteLine("No data found");
                return NotFound();
            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            int result = _db.SaveChanges();

            string message = result > 0 ? "Saving success" : "Saving fail";
            return Ok(message);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if (item is null) 
            { 
                return NotFound("No data found");
            }
           _db.Blogs.Remove(item);
            int result = _db.SaveChanges();

            string message = result > 0 ? "Saving success" : "Saving fail";
            return Ok(message);


        }
    }
}
