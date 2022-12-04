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

    public class StudentAccessController : ControllerBase
    {
        //Pratik Chaudhari
        private readonly ILogger<StudentAccessController> _logger;
        private readonly IStudentAccessInterface _studentAccessInterface;

        //Pratik Chaudhari
        public StudentAccessController(ILogger<StudentAccessController> logger, IStudentAccessInterface studentAccessInterface)
        {
            _logger = logger;
            _studentAccessInterface = studentAccessInterface;
        }

        //Pratik Chaudhari
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_studentAccessInterface.GetAllStudents());
        }

        //Pratik Chaudhari
        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            return Ok(_studentAccessInterface.GetStudentByID(id));
        }

        //Pratik Chaudhari
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _studentAccessInterface.RemoveStudentById(id);

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
        public IActionResult Put(Student studentToUpdate)
        {
            var result = _studentAccessInterface.UpdateStudent(studentToUpdate);

            if (result == null)
            {
                return NotFound(studentToUpdate.Id);
            }
            if (result == 0)
            {
                return StatusCode(500, "Error!");
            }

            return Ok();

        }

        //Pratik Chaudhari
        [HttpPost]
        public IActionResult Post(Student newStudent)
        {
            var result = _studentAccessInterface.AddStudent(newStudent);

            if (result == null)
            {
                return StatusCode(500, "Student Already Exists!");
            }
            if (result == 0)
            {
                return StatusCode(500, "Error!");
            }

            return Ok();
        }
    }
}
