using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project3.Data;
using Project3.Interface;
using Project3.Model;
using Project3.Services;

namespace Project3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository _repository;
        private readonly IMapper _mapper;

        public MessageController(ApplicationdbContext repository, IMapper mapper)
        {
            _repository = new MessageServices(repository);
            _mapper = mapper;
        }

        [HttpGet("GetAllMessage")]
        public async Task<IActionResult> GetAll()
        {
            var domain = await _repository.GetAllAsync();
            var dto = _mapper.Map<List<MessageDto>>(domain);
            return Ok(dto);
        }

        [HttpPost("CreateMessage")]
        public async Task<IActionResult> Create(MessageDto messagedto)
        {
            if(messagedto != null)
            {
                var domain =_mapper.Map<Message>(messagedto) ;
               await _repository.CreatAsync(domain);
                return Ok(messagedto);
            }
            return BadRequest();
        }

        [HttpDelete("DeleteMessage")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.DeleteAsync(id);
             if(result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
