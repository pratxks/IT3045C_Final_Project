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

    public class FoodAccessController : ControllerBase
    {
        private readonly ILogger<FoodAccessController> _logger;
        private readonly IFoodAccessInterface _foodAccessInterface;

        public FoodAccessController(ILogger<FoodAccessController> logger, IFoodAccessInterface foodAccessInterface)
        {
            _logger = logger;
            _foodAccessInterface = foodAccessInterface;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_foodAccessInterface.GetAllFoodRecords());
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            return Ok(_foodAccessInterface.GetFoodRecordByID(id));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _foodAccessInterface.RemoveFoodRecordById(id);

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
        public IActionResult Put(Food foodRecordToUpdate)
        {
            var result = _foodAccessInterface.UpdateFoodRecord(foodRecordToUpdate);

            if (result == null)
            {
                return NotFound(foodRecordToUpdate.Id);
            }
            if (result == 0)
            {
                return StatusCode(500, "Error!");
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Food newFoodRecord)
        {
            var result = _foodAccessInterface.AddFoodRecord(newFoodRecord);

            if (result == null)
            {
                return StatusCode(500, "Food Record Already Exists!");
            }
            if (result == 0)
            {
                return StatusCode(500, "Error!");
            }

            return Ok();
        }
    }
}
