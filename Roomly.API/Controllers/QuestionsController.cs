using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roomly.API.Contracts;
using Roomly.Business;

namespace Roomly.API.Controllers
{
    [Produces("application/json")]
    public class QuestionsController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        
        [HttpGet("/questions/")]
        public IActionResult Get()
        {
            var models = _questionService.Get();
            return Ok(models);
        }

        
        [HttpGet("/questions/{questionId}")]
        public IActionResult Get(Guid questionId)
        {
            var model = _questionService.Get(questionId);
            return Ok(model);
        }

       
        [HttpPost("/questions/")]
        public Question Post([FromBody] Question model)
        {
            var entity = _questionService.Get(model.QuestionId);
            var result = new Question();
            if (entity == null)
            {
                result = _questionService.Create(model);
                return result;
            }

            result = _questionService.Update(model);
            return result;

        }

     
        [HttpPut("/questions/{questionId}")]
        public Question Put(Guid questionId, [FromBody] Question model)
        {
            return Post(model);
            
        }


        [HttpDelete("/questions/{questionId}")]
        public void Delete(Guid questionId)
        {
            var model = _questionService.Get(questionId);
            model.IsDeleted = true;
            model.IsActive = false;
            _questionService.Update(model);
        }
    }
}
