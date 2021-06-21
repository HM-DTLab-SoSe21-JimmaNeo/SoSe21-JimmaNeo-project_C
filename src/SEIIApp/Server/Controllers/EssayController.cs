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
    [Route("api/EssayDefinition")]
    public class EssayController : ControllerBase
    {
        private EssayService EssayDefinitonService { get; set; }
        private IMapper Mapper { get; set; }
        public EssayController(EssayService essay, IMapper mapper)
        {
            // ServiceEssay in Services -> in Startup in die Config anlegen 
            EssayDefinitonService = essay;
            // Configuration des Mappers 
            this.Mapper = mapper;
        }

        /// <summary>
        /// Returns all essays
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<EssayDto[]> GetAllEssaysFromDB()
        {
            // Essaydefinition Domain Objects
            var essays = EssayDefinitonService.GetAllEssays();
            // mapped To EssayDTO Objects
            var mappedEssays = Mapper.Map<EssayDto[]>(essays);
            return Ok(mappedEssays);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<EssayDto> GetEssay([FromRoute] int id)
        {
            var essay = EssayDefinitonService.GetEssayWithId(id);
            if (essay == null) return StatusCode(StatusCodes.Status404NotFound);
            var mappedEssay = Mapper.Map<EssayDto>(essay);
            return Ok(mappedEssay);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<EssayDto> InsertOrUpdateEssay([FromBody] EssayDto essay)
        {
            if (ModelState.IsValid)
            {
                var mappedModel = Mapper.Map<EssayDefinition>(essay);
                EssayDefinition[] essays = EssayDefinitonService.GetAllEssays();
                if (essays.Any(e => e.EssayId== mappedModel.EssayId))
                {
                    EssayDefinitonService.UpdateEssay(mappedModel);

                }
                else
                {
                    mappedModel = EssayDefinitonService.AddEssay(mappedModel);
                }
                var model = Mapper.Map<EssayDto>(mappedModel);
                return Ok(model);
            }
            return BadRequest(ModelState);

        }

        [HttpDelete("{EssayID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteEssay([FromRoute] int EssayID)
        {
            var essay = EssayDefinitonService.GetEssayWithId(EssayID);
            if (essay == null) return StatusCode(StatusCodes.Status404NotFound);
            EssayDefinitonService.DeleteEssay(EssayID);
            return Ok();
        }
    }
}
