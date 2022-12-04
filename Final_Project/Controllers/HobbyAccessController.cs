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

    public class HobbyAccessController : ControllerBase
    {
        private readonly ILogger<HobbyAccessController> _logger;
        private readonly IHobbyAccessInterface _hobbyAccessInterface;

        public HobbyAccessController(ILogger<HobbyAccessController> logger, IHobbyAccessInterface hobbyAccessInterface)
        {
            _logger = logger;
            _hobbyAccessInterface = hobbyAccessInterface;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_hobbyAccessInterface.GetAllHobbyRecords());
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            return Ok(_hobbyAccessInterface.GetHobbyRecordByID(id));
        }

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
