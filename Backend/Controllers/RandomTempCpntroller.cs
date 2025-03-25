using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizAppForDriverLicense.Dtos;
using QuizAppForDriverLicense.Models;
using QuizAppForDriverLicense.Repository.IRepository;

namespace QuizAppForDriverLicense.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomTempController : ControllerBase
    {
        private readonly IRandomTempRepository _randomTempRepository;
        
        public RandomTempController(IRandomTempRepository randomTempRepository)
        {
            _randomTempRepository = randomTempRepository;
        }
        [HttpPost]
        public IActionResult Post(RandomTempDto rt)
        {
            bool result = _randomTempRepository.Add(rt);
            
            if(result)
                return Ok();
            return BadRequest();
        }
        [HttpGet("LastTemp/{userId}")]
        public IActionResult Get(string userId)
        {
            RandomTemp temp= _randomTempRepository.GetLastTemp(userId);

            return Ok(temp);
        }
        [HttpPost("Submit")]    
        public IActionResult Post([FromBody] AnswerSubmissionDto model)
        {
            if (model == null || model.AnswerId == null || !model.AnswerId.Any())
            {
                return BadRequest("Danh sách câu trả lời không được để trống.");
            }
            bool result = _randomTempRepository.AddTempAnswers(model.AnswerId, model.TempId);
            if (result)
            {
                _randomTempRepository.UpdateResult(model.AnswerId, model.TempId);
                return Ok();
            }
            return BadRequest();
        }
        
    }
}
