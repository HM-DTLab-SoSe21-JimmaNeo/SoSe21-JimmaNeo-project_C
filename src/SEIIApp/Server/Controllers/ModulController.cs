using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Domain;
using SEIIApp.Server.Services;
using SEIIApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using SEIIApp.Shared.Moduldto;

namespace SEIIApp.Server.Controllers
{
    [ApiController]
    [Route("api/ModulDefinition")]
    public class ModulController : ControllerBase
    {
        private ModulService ModulDefinitonService { get; set; }
        private IMapper Mapper { get; set; }

        public ModulController(ModulService modul, IMapper mapper)
        {
            ModulDefinitonService = modul;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Returns all moduls 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ModulDto[]> GetAllModulsFromDB()
        {
            // Moduldefinition Domain Objects
            var moduls = ModulDefinitonService.GetAllModuls();

            // mapped To ModulDTO Objects
            var mappedModuls = Mapper.Map<ModulDto[]>(moduls);
            return Ok(mappedModuls);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ModulDto> GetModul([FromRoute] int id)
        {
            var modul = ModulDefinitonService.GetModulWithId(id);
            if (modul == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedModul = Mapper.Map<ModulDto>(modul);
            return Ok(mappedModul);
        }

        /*
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ModulDto> AddModul([FromBody] ModulDto modul)
        {
            if (ModelState.IsValid)
            {
                var mappedModel = Mapper.Map<ModulDefinition>(modul);
                ModulDefinitonService.Save(mappedModel);
                var model = Mapper.Map<ModulDto>(mappedModel);
                return Ok(model);
            }
            return BadRequest(ModelState);
        }*/

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ModulDto> InsertOrUpdateModul([FromBody] ModulDto modul)
        {
            if (ModelState.IsValid)
            {
                var mappedModel = Mapper.Map<ModulDefinition>(modul);
                ModulDefinition[] moduls = ModulDefinitonService.GetAllModuls();
                if (moduls.Any(p => p.ModulId == mappedModel.ModulId))
                {
                    ModulDefinitonService.Update(mappedModel);

                }
                else
                {
                    mappedModel = ModulDefinitonService.AddModul(mappedModel);
                }
                var model = Mapper.Map<ModulDto>(mappedModel);
                return Ok(model);
            }
            return BadRequest(ModelState);

        }

        
        [Route("video")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ModulDto> AddVideo([FromBody] ModulDto modul)
        {
            if (ModelState.IsValid)
            {
                var mappedModel = Mapper.Map<ModulDefinition>(modul);
                //int insertPosition = modul.Videos.Count - 1;
                ModulDefinitonService.UploadVideo(mappedModel.ModulId, mappedModel.Videos[0]);
                var model = Mapper.Map<ModulDto>(mappedModel);
                return Ok(model);
            }
            return BadRequest(ModelState);
        }
       

    }
}
