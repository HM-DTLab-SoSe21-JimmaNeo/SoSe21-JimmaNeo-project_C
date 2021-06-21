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
    [Route("api/VideoDefinition")]
    public class VideoController : ControllerBase
    {
        private VideoService VideoDefinitonService { get; set; }
        private IMapper Mapper { get; set; }
        public VideoController(VideoService video, IMapper mapper)
        {
            // ServiceVideo in Services -> in Startup in die Config anlegen 
            VideoDefinitonService = video;
            // Configuration des Mappers 
            this.Mapper = mapper;
        }

        /// <summary>
        /// Returns all videos 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<VideoDto[]> GetAllVideosFromDB()
        {
            // Videodefinition Domain Objects
            var videos = VideoDefinitonService.GetAllVideos();
            // mapped To VideoDTO Objects
            var mappedVideos = Mapper.Map<VideoDto[]>(videos);
            return Ok(mappedVideos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VideoDto> GetVideo([FromRoute] int id)
        {
            var video = VideoDefinitonService.GetVideoWithId(id);
            if (video == null) return StatusCode(StatusCodes.Status404NotFound);
            var mappedVideo = Mapper.Map<VideoDto>(video);
            return Ok(mappedVideo);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VideoDto> InsertOrUpdateVideo([FromBody] VideoDto video)
        {
            if (ModelState.IsValid)
            {
                var mappedModel = Mapper.Map<VideoDefinition>(video);
                VideoDefinition[] videos = VideoDefinitonService.GetAllVideos();
                if (videos.Any(v => v.VideoId == mappedModel.VideoId))
                {
                    VideoDefinitonService.UpdateVideo(mappedModel);

                }
                else
                {
                    mappedModel = VideoDefinitonService.AddVideo(mappedModel);
                }
                var model = Mapper.Map<VideoDto>(mappedModel);
                return Ok(model);
            }
            return BadRequest(ModelState);

        }

        [HttpDelete("{VideoID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteVideo([FromRoute] int VideoID)
        {
            var video = VideoDefinitonService.GetVideoWithId(VideoID);
            if (video == null) return StatusCode(StatusCodes.Status404NotFound);
            VideoDefinitonService.DeleteVideo(VideoID);
            return Ok();
        }
    }
}
