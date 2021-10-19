using Animal_Care_WebAPI.Resources.UserResources;
using AutoMapper;
using DAO.Services;
using Domains;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Animal_Care_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMapper mapperService;
        private IUser userService;

        public UserController(IMapper mapperService, IUser userService)
        {
            this.mapperService = mapperService;
            this.userService = userService;
        }
        
        // GET: api/<UserController>
        [HttpGet("UsersEvents")]
         public async Task<ActionResult<IEnumerable<UserResource>>> GetUsersEvents()
        {
            try
            {
                var users = await userService.GetAllUsersWithEventsAsync();
                var usersResource = mapperService.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
                return Ok(usersResource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
         
       
        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResource>>> GetUsers()
        {
            try
            {
                var users = await userService.GetAllUsersAsync();
                var usersResource = mapperService.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
                return Ok(usersResource);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResource>> GetUserById(int id)
        {
            try
            {
                //recup user id 
                var userId = await userService.GetUserByIdAsync(id);
                //mapp bdd to view
                var userMap = mapperService.Map<User, UserResource>(userId);
                return Ok(userMap);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("Specialiste/{id}")]
        public async Task<ActionResult<UserResource>> GetUserWithEvents(int id)
        {
            try
            {
                //recup user id 
                var userId = await userService.GetUserWithEventsAsync(id);
                //mapp bdd to view
                var userMap = mapperService.Map<User, UserResource>(userId);
                return Ok(userMap);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
