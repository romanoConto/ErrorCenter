using AutoMapper;
using Codenation.ErrorCenter.Models.DTOs;
using Codenation.ErrorCenter.Models.Models;
using Codenation.ErrorCenter.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Codenation.ErrorCenter.Controllers
{
    [Route("api/[controller]")]
    public class LogController : ControllerBase
    {
        private ILogService service;
        private readonly IMapper mapper;

        public LogController(ILogService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LogDTO>> Get()
        {
            try
            {
                return Ok(service.FindAllLogs().Select(x => mapper.Map<LogDTO>(x)));
            }
            catch
            {
                return NotFound();
            }
        }


        [HttpGet]
        [Route("{id}")]
        public ActionResult<LogDTO> Get(int id)
        {
            try
            {

                return Ok(mapper.Map<LogDTO>(service.FindById(id)));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<List<LogDTO>> FindByFilter([FromBody]ErrorFilterDTO filter)
        {
            try
            {

                if (!ModelState.IsValid)
                    return BadRequest();

                return Ok(service.FindByFilter(filter).Select(x => mapper.Map<LogDTO>(x)));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("save")]
        public ActionResult<LogDTO> Save([FromBody]LogDTO log)
        {
            try
            {

                if (!ModelState.IsValid)
                    return BadRequest();

                return Ok(mapper.Map<LogDTO>(service.Save(mapper.Map<Log>(log))));
            }
            catch
            {
                return NotFound();
            }
        }

        //Method used to change archived status
        [HttpPut]
        [Route("save")]
        public ActionResult<LogDTO> Put([FromBody]LogDTO log)
        {
            try
            {

                if (!ModelState.IsValid)
                    return BadRequest();
                log.IsArchived = !log.IsArchived;
                return Ok(mapper.Map<LogDTO>(service.Save(mapper.Map<Log>(log))));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                bool sucess = service.Delete(id);
                if (!sucess)
                    return BadRequest();

                return Ok(sucess);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
