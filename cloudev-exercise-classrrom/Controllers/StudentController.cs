using cloudev_exercise_classrrom.DTO;
using cloudev_exercise_classrrom.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cloudev_exercise_classrrom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ClassroomDbContext _ctx;
        private readonly Mapper _mapper;
        private readonly ILogger<StudentController> _logger;

        public StudentController(ClassroomDbContext ctx, Mapper mapper, ILogger<StudentController> logger)
        {
            _ctx = ctx;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var students = _ctx.Students;
                if (students == null)
                {
                    return BadRequest("There is no students in the classroom");
                }
                return Ok(students.ToList().ConvertAll(_mapper.MapEntityToDTO));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            try
            {
                var student = _ctx.Students.Find(id);
                if (student == null)
                {
                    return BadRequest("There is no students with this id");
                }
                return Ok(_mapper.MapEntityToDTO(student));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "");
            }
        }

        [HttpPost]
        public IActionResult CreateStudent(StudentDTO dto)
        {
            try
            {
                Student studentToAdd = _mapper.MapDTOtoEntity(dto);
                _ctx.Students.Add(studentToAdd);
                _ctx.SaveChanges();
                return Created("", dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "");
            }
        }

        [HttpPut]
        public IActionResult UpdateStudent(StudentDTO dto)
        {
            try
            {
                var studentToModify = _ctx.Students.Find(dto.Id);
                if (studentToModify == null)
                {
                    return BadRequest("");
                }

                studentToModify.Name = dto.Name;
                studentToModify.Surname = dto.Surname;
                studentToModify.Email = dto.Email;
                studentToModify.ClassroomId = dto.ClassroomId;
                studentToModify.Password = dto.Password;
                _ctx.SaveChanges();

                return Ok(studentToModify);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "");
            }
        }

        [HttpDelete("delete-student/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var studentToRemove = _ctx.Students.Find(id);
                if (studentToRemove == null)
                {
                    return BadRequest("The provided id is not associated with any student");
                }

                _ctx.Students.Remove(studentToRemove);
                _ctx.SaveChanges();
                return Ok("The student has been removed");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "");
            }
        }
    }
}
