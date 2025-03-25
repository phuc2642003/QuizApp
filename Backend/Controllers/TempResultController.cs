using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizAppForDriverLicense.Repository.IRepository;

namespace QuizAppForDriverLicense.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempResultController : ControllerBase
    {
        private readonly IRandomTempRepository _randomTempRepository;

        public TempResultController(IRandomTempRepository randomTempRepository)
        {
            _randomTempRepository = randomTempRepository;
        }
        [HttpGet("History/{userId}")]
        public IActionResult Get(string userId)
        {
            var tempResultInfoDtos = _randomTempRepository.GetResults(userId);

            return Ok(tempResultInfoDtos);
        }
    }
}
