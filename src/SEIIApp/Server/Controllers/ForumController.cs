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


        [Route("api/PostDefinition/post/delete")]
        [HttpGet("{PostID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void DeletePdf([FromRoute] int PostID)
        {
            PostDefinitonService.DeletePdf(PostID);
        }


        [Route("api/PostDefinition/post/Add")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void AddPost([FromBody] PostDto post)
        {
            if (ModelState.IsValid)
            {
                var mappedModel = Mapper.Map<PostDefinition>(post);
                PostDefinitonService.Save(mappedModel);
            }
            BadRequest(ModelState);
        }

    }
}
