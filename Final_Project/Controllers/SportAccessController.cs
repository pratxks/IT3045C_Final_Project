using Final_Project.Data;
using Final_Project.Interfaces;
using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SportAccessController : ControllerBase
    {
        private readonly ILogger<SportAccessController> _logger;
        private readonly ISportAccessInterface _sportAccessInterface;

        public SportAccessController(ILogger<SportAccessController> logger, ISportAccessInterface sportAccessInterface)
        {
            _logger = logger;
            _sportAccessInterface = sportAccessInterface;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_sportAccessInterface.GetAllSportRecords());
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            return Ok(_sportAccessInterface.GetSportRecordByID(id));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _sportAccessInterface.RemoveSportRecordById(id);

            if (result == null)
            {
                return NotFound(id);
            }
            if (result == 0)
            {
                return StatusCode(500, "Error!");
            }

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Sport sportRecordToUpdate)
        {
            var result = _sportAccessInterface.UpdateSportRecord(sportRecordToUpdate);

            if (result == null)
            {
                return NotFound(sportRecordToUpdate.Id);
            }
            if (result == 0)
            {
                return StatusCode(500, "Error!");
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Sport newSportRecord)
        {
            var result = _sportAccessInterface.AddSportRecord(newSportRecord);

            if (result == null)
            {
                return StatusCode(500, "Sport Record Already Exists!");
            }
            if (result == 0)
            {
                return StatusCode(500, "Error!");
            }

            return Ok();
        }
    }
}
