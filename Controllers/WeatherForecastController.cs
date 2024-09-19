using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Domain;
using SchoolManagementSystem.Repositories;
using SchoolManagementSystem.Validators;

namespace SchoolManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private SchoolDbContext _context;
        private IRepository<Student> _studentRepository;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, SchoolDbContext context)
        {
            _logger = logger;
            _context = context;
            _studentRepository = new StudentRepository(context);
        }

        [HttpPost("add_student")]
        public async Task<IActionResult> AddStudent()
        {
            // Create the student object
            var student = new Student
            {
                FirstName = "Muhammad",
                LastName = "Ahmad",
                DateOfBirth = new DateTime(2005, 8, 15),
                Email = "MuhammadAhmad@example.com",
                ClassId = 1
            };
            // Call the repository method to add the student
            var result = await _studentRepository.GetAddAsync(student); // Ensure this method is implemented correctly

            // Check the result and return the appropriate response
            if (result != null) // Assume result contains the newly added student
            {
                return Ok(result); // Return the newly added student or appropriate success response
            }

            return BadRequest("Failed to add the student");
        }

        [HttpPost("get_all_students")]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentRepository.GetAllAsync();
            if (students != null)
            {
                return Ok(students);
            }
            return BadRequest("Failed to fetch students");
        }
        [HttpPost("delete_student")]
        public async Task<IActionResult> DeleteStudent()
        {
            Student student = new Student
            {
                StudentId = 2,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = DateTime.Parse("2005-08-15"),
                Email = "johndoe@example.com",
                ClassId = 1,
                IsDeleted = false
            };
            var studentDeleted = await _studentRepository.GetDeleteAsync(student);
            if(studentDeleted != null)
            {
                return BadRequest(studentDeleted);
            }
            return BadRequest("Failed to delete the student");
        }


    }
}
