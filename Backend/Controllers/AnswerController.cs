using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizAppForDriverLicense.Models;
using QuizAppForDriverLicense.Repository.IRepository;

namespace QuizAppForDriverLicense.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly QuizAppContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAnswerRepository _answerRepository;

        public AnswerController(UserManager<IdentityUser> userManager, QuizAppContext context, IAnswerRepository answerRepository)
        {
            _userManager = userManager;
            _context = context;
            _answerRepository = answerRepository;
        }
        [HttpPost]
        public IActionResult Post(int answerId, string userId)
        {
            var userAnswer = new UserAnswer
            {
                UserId = userId,  
                AnswerId = answerId 
            };

            _context.UserAnswers.Add(userAnswer);
            if(_context.SaveChanges()>0)
            {
                return Ok();
            }

            return BadRequest();
        }
        [HttpDelete("userId")]
        public IActionResult Delete(string userId)
        {
            bool result = _answerRepository.ClearAllAnswerByUserId(userId);
            if(result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
