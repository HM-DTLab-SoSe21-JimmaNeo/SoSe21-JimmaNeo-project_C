using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Domain;
using SEIIApp.Server.Services;
using SEIIApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEIIApp.Server.Controllers
{
    // nimmt anfragen via HTTP vom Services des SEII.Client.Services entgegen siehe Class
    [ApiController]
    [Route("api/QuizDefinition")]
    public class QuizController : ControllerBase
    {
        private QuizService QuizDefinitonService { get; set; }
        private IMapper Mapper { get; set; }
        public QuizController(QuizService quiz, IMapper mapper)
        {
            // ServiceVideo in Services -> in Startup in die Config anlegen 
            QuizDefinitonService = quiz;
            // Configuration des Mappers 
            this.Mapper = mapper;
        }

        /// <summary>
        /// Returns all quizes 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<QuizDto[]> GetAllQuizesFromDB()
        {
            // Quizdefinition Domain Objects
            var quizes = QuizDefinitonService.GetAllQuizes();
            // mapped To QuizDTO Objects
            var mappedQuizes = Mapper.Map<QuizDto[]>(quizes);
            return Ok(mappedQuizes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<QuizDto> GetQuiz([FromRoute] int id)
        {
            var quiz= QuizDefinitonService.GetQuizWithId(id);
            if (quiz == null) return StatusCode(StatusCodes.Status404NotFound);
            var mappedQuiz = Mapper.Map<VideoDto>(quiz);
            return Ok(mappedQuiz);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<QuizDto> InsertOrUpdateQuiz([FromBody] QuizDto quiz)
        {
            if (ModelState.IsValid)
            {
                var mappedModel = Mapper.Map<QuizDefinition>(quiz);
                QuizDefinition[] quizes = QuizDefinitonService.GetAllQuizes();
                if (quizes.Any(q => q.QuizId == mappedModel.QuizId))
                {
                    QuizDefinitonService.UpdateQuiz(mappedModel);

                }
                else
                {
                    mappedModel = QuizDefinitonService.AddQuiz(mappedModel);
                }
                var model = Mapper.Map<QuizDto>(mappedModel);
                return Ok(model);
            }
            return BadRequest(ModelState);

        }

        [HttpDelete("{QuizID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteQuiz([FromRoute] int QuizID)
        {
            var quiz = QuizDefinitonService.GetQuizWithId(QuizID);
            if (quiz == null) return StatusCode(StatusCodes.Status404NotFound);
            QuizDefinitonService.DeleteQuiz(QuizID);
            return Ok();
        }

    }
}
