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
    //Pratik Chaudhari
    [ApiController]
    [Route("[controller]")]

    public class SportAccessController : ControllerBase
    {
        //Pratik Chaudhari
        private readonly ILogger<SportAccessController> _logger;
        private readonly ISportAccessInterface _sportAccessInterface;

        //Pratik Chaudhari
        public SportAccessController(ILogger<SportAccessController> logger, ISportAccessInterface sportAccessInterface)
        {
            _logger = logger;
            _sportAccessInterface = sportAccessInterface;
        }

        //Pratik Chaudhari
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_sportAccessInterface.GetAllSportRecords());
        }

        //Pratik Chaudhari
        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            return Ok(_sportAccessInterface.GetSportRecordByID(id));
        }

        //Pratik Chaudhari
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

        //Pratik Chaudhari
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

        //Pratik Chaudhari
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
