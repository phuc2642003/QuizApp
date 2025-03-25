using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizAppForDriverLicense.Models;
using QuizAppForDriverLicense.Repository.IRepository;

namespace QuizAppForDriverLicense.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IRandomTempRepository _randomTempRepository;
        public QuestionController(IQuestionRepository questionRepository, IRandomTempRepository randomTempRepository)
        {
            _questionRepository = questionRepository;
            _randomTempRepository = randomTempRepository;
        }
        [HttpGet("{categoryId}")]
        public IActionResult Get(int? categoryId)
        {
            var questions = _questionRepository.GetQuestionsByCategoryId(categoryId);

            return Ok(questions);
        }
        [HttpPost("AddToTemp/{userId}")]
        public IActionResult Post(string userId)
        {
            var questions = _questionRepository.GetRandomQuestionForRandomTemp();
            bool result = _randomTempRepository.AddQuestions(questions, userId);
            
            if(result)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("RandomTemp/{tempId}")]    
        
        public IActionResult Get(int tempId)
        {
            var questions = _questionRepository.GetByRandomTempId(tempId);
            return Ok(questions);
        }

        
    }
}
