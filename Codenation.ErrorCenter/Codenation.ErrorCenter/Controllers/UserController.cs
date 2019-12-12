using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.ErrorCenter.Models.DTOs;
using Codenation.ErrorCenter.Models.Models;
using Codenation.ErrorCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.ErrorCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserService service;
        private readonly IMapper mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> Get()
        {
            return Ok(service.FindAll().Select(x => mapper.Map<UserDTO>(x)).
                    ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            return Ok(mapper.Map<UserDTO>(service.FindById(id)));
        }

        [HttpPut]
        [Route("save")]
        public ActionResult<UserDTO> Change(UserDTO user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(mapper.Map<UserDTO>(service.Save(mapper.Map<User>(user))));
        }

        [HttpPost]
        [Route("save")]
        public ActionResult<UserDTO> Save(UserDTO user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(mapper.Map<UserDTO>(service.Save(mapper.Map<User>(user))));
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Boolean> Delete(int id)
        {
            if (!service.DeleteUserById(id))
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
