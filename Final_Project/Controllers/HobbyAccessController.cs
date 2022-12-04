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

    public class HobbyAccessController : ControllerBase
    {
        //Pratik Chaudhari
        private readonly ILogger<HobbyAccessController> _logger;
        private readonly IHobbyAccessInterface _hobbyAccessInterface;

        //Pratik Chaudhari
        public HobbyAccessController(ILogger<HobbyAccessController> logger, IHobbyAccessInterface hobbyAccessInterface)
        {
            _logger = logger;
            _hobbyAccessInterface = hobbyAccessInterface;
        }

        //Pratik Chaudhari
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_hobbyAccessInterface.GetAllHobbyRecords());
        }

        //Pratik Chaudhari
        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            return Ok(_hobbyAccessInterface.GetHobbyRecordByID(id));
        }

        //Pratik Chaudhari
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _hobbyAccessInterface.RemoveHobbyRecordById(id);

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
        public IActionResult Put(Hobby hobbyRecordToUpdate)
        {
            var result = _hobbyAccessInterface.UpdateHobbyRecord(hobbyRecordToUpdate);

            if (result == null)
            {
                return NotFound(hobbyRecordToUpdate.Id);
            }
            if (result == 0)
            {
                return StatusCode(500, "Error!");
            }

            return Ok();
        }

        //Pratik Chaudhari
        [HttpPost]
        public IActionResult Post(Hobby newHobbyRecord)
        {
            var result = _hobbyAccessInterface.AddHobbyRecord(newHobbyRecord);

            if (result == null)
            {
                return StatusCode(500, "Hobby Record Already Exists!");
            }
            if (result == 0)
            {
                return StatusCode(500, "Error!");
            }

            return Ok();
        }
    }
}
