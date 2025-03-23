using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizAppForDriverLicense.Dtos;
using QuizAppForDriverLicense.Models;

namespace QuizAppForDriverLicense.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomTempController : ControllerBase
    {
        public RandomTempController()
        {
            
        }
        [HttpPost]
        public IActionResult Post(RandomTempDto rt)
        {
            QuizAppContext _context = new QuizAppContext();
            RandomTemp randomTemp = new RandomTemp()
            {
                UserId = rt.UserId,
                Content = rt.Content,
                PassResult = rt.PassResult,
                Result = rt.Result
            };
            _context.RandomTemps.Add(randomTemp);
            var result =_context.SaveChanges();
            
            if(result >0)
                return Ok();
            return BadRequest();
        }
    }
}
