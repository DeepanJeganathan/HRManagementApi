using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HrMangementApi.Services;
using AutoMapper;
using HrMangementApi.Models;
using HrManagementApi.DTOs.CommentDTOs;

namespace HrMangementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentsController(ICommentRepository commentRepository, IMapper mapper)
        {
            this._commentRepository = commentRepository;
            this._mapper = mapper;
        }


        /// <summary>
        /// Get list of comments
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> Comments()
        {
            var commentList = await _commentRepository.GetAllAsync();

            var commentListDto = new List<CommentViewDTO>();

            foreach (var comment in commentList)
            {
                commentListDto.Add(_mapper.Map<CommentViewDTO>(comment));
            }

            return Ok(commentListDto);
        }

        /// <summary>
        /// Get individual comment
        /// </summary>
        /// <param name="id">The id of comment</param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public  async Task<ActionResult<Employee>> Comment(int id)
        {
            var comment = await _commentRepository.GetById(id);
            if (comment==null)
            {
                return NotFound();
            }
            var commentDto = _mapper.Map<CommentViewIdDTO>(comment);
            return Ok(commentDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CommentCreateDTO commentCreateDTO)
        {

            if (commentCreateDTO==null)
            {
                return BadRequest(ModelState);
            }


            var comment = _mapper.Map<Comment>(commentCreateDTO);

            if (!await _commentRepository.CreateAsync(comment) )
            {
                ModelState.AddModelError("", "Error encountered when saving to database, try again. If problem persists contact your administrator");

                return StatusCode(500, ModelState);
            }

            return CreatedAtAction(nameof(comment), new { id = comment.CommentId }, comment);

        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Comment>> update(int id, [FromBody] CommentUpdateDTO commentUpdateDTO)
        {

            if (id != commentUpdateDTO.CommentId || commentUpdateDTO == null)
            {

                return BadRequest();
            }

            var comment = _mapper.Map<Comment>(commentUpdateDTO);

            if (!await _commentRepository.UpdateAsync(comment))
            {
                ModelState.AddModelError("", "Error encountered when saving to database, try again. If problem persists contact your administrator");
                return StatusCode(500, ModelState);

            }

            return NoContent();

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Employee>> Delete(int id)
        {

            if (!await _commentRepository.CommentExists(id))
            {
                ModelState.AddModelError("", "Employee does not exist!");
                return StatusCode(404, ModelState);
            }

            var comment = await _commentRepository.GetById(id);

            if (!await _commentRepository.DeleteAsync(comment))
            {

                ModelState.AddModelError("", "Error encountered when deleting from database, try again. If problem persists contact your administrator");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }



    }
}