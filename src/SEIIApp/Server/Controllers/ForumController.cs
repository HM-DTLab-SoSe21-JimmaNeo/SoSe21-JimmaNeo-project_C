using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Domain;
using SEIIApp.Server.Services;
using SEIIApp.Shared;
using System;

namespace SEIIApp.Server.Controllers
{
    [ApiController]
    [Route("api/PostDefinition")]
    public class ForumController : ControllerBase
    {

        private ForumService PostDefinitonService { get; set; }
        private IMapper Mapper { get; set; }
        public ForumController(ForumService post, IMapper mapper)
        {
            PostDefinitonService = post;
            this.Mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PostDto> GetPost([FromRoute] int id)
        {
            var post = PostDefinitonService.GetPostWithId(id);
            if (post == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedPost = Mapper.Map<PostDto>(post);
            return Ok(mappedPost);
        }

        /// <summary>
        /// Returns all posts 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<PostDto[]> GetAllPostsFromDB()
        {
            // Postdefinition Domain Objects
            var posts = PostDefinitonService.GetAllPosts();
            // mapped To PostDTO Objects
            var mappedPosts = Mapper.Map<PostDto[]>(posts);
            return Ok(mappedPosts);
        }

        [HttpGet("{category}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PostDto> GetPost([FromRoute] String category)
        {
            var post = PostDefinitonService.GetPostwithCategory(category);
            if (post == null) return StatusCode(StatusCodes.Status404NotFound);
            var mappedPost = Mapper.Map<PostDto>(post);
            return Ok(mappedPost);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PostDto> AddPost([FromBody] PostDto post)
        {
            if (ModelState.IsValid)
            {
                var mappedModel = Mapper.Map<PostDefinition>(post);
                PostDefinitonService.Save(mappedModel);
                var model = Mapper.Map<PostDto>(mappedModel);
                return Ok(model);
            }
            return BadRequest(ModelState);
        }

        [Route("api/PostDefinition/pdf")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PostDto> AddPdf([FromBody] PostDto post)
        {
            if (ModelState.IsValid)
            {
                var mappedModel = Mapper.Map<PostDefinition>(post);
                PostDefinitonService.UploadPdf(mappedModel.PostId, mappedModel.Attachment);
                var model = Mapper.Map<PostDto>(mappedModel);
                return Ok(model);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{PostID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeletePdf([FromRoute] int PostID)
        {
            var post = PostDefinitonService.GetPostWithId(PostID);
            if (post == null) return StatusCode(StatusCodes.Status404NotFound);
            PostDefinitonService.DeletePdf(PostID);
            return Ok();
        }

        [Route("api/PostDefinition/post")]
        [HttpDelete("{PostID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeletePost([FromRoute] int PostID)
        {
            var post = PostDefinitonService.GetPostWithId(PostID);
            if (post == null) return StatusCode(StatusCodes.Status404NotFound);
            PostDefinitonService.DeletePost(PostID);
            return Ok();
        }

    }
}
