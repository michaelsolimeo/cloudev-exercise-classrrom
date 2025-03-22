using cloudev_exercise_classrrom.DTO;
using cloudev_exercise_classrrom.Entities;
using Microsoft.AspNetCore.Mvc;

namespace cloudev_exercise_classrrom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly ClassroomDbContext _ctx;
        private readonly Mapper _mapper;
        private readonly ILogger<ClassroomController> _logger;

        public ClassroomController(ClassroomDbContext ctx, Mapper mapper, ILogger<ClassroomController> logger)
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
                if (!_ctx.Classrooms.Any())
                {
                    return NotFound("There is no classrooms yet");
                }

                var students = _ctx.Students
                    .ToList()
                    .ConvertAll(_mapper.MapEntityToDTO);
                return Ok(students);
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
                if (!_ctx.Classrooms.Any())
                {
                    return NotFound("There is no classrooms yet");
                }

                var classroom = _ctx.Students.Find(id);
                if (classroom == null)
                {
                    return NotFound("The provided id is not associated to any classroom");
                }

                return Ok(_mapper.MapEntityToDTO(classroom));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "");
            }
        }

        [HttpGet("students/{id}")]
        public IActionResult GetClassroomWithStudents(int id)
        {
            try
            {
                if (!_ctx.Classrooms.Any())
                {
                    return NotFound("There is no classrooms yet");
                }

                var classroom = _ctx.Classrooms.Find(id);
                if (classroom == null)
                {
                    return NotFound();
                }

                return Ok(new
                {
                    id = classroom.Id,
                    roomName = classroom.RoomName,
                    students = classroom.Students.ConvertAll(_mapper.MapEntityToDTO)
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ClassroomDTO dto)
        {
            try
            {
                _ctx.Classrooms.Add(_mapper.MapDTOToEntity(dto));
                _ctx.SaveChanges();
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] ClassroomDTO dto)
        {
            try
            {
                if (!_ctx.Classrooms.Any())
                {
                    return NotFound("There is no classrooms yet");
                }

                var classroomToUpdate = _ctx.Classrooms.Find(dto.Id);
                if (classroomToUpdate == null)
                {
                    BadRequest();
                }

                classroomToUpdate.RoomName = dto.RoomName;
                _ctx.SaveChanges();

                return Ok(classroomToUpdate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (!_ctx.Classrooms.Any())
                {
                    return NotFound("There is no classrooms yet");
                }

                var classroomToDelete = _ctx.Classrooms.Find(id);
                if (classroomToDelete == null)
                {
                    return NotFound();
                }

                _ctx.Classrooms.Remove(classroomToDelete);
                _ctx.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "");
            }
        }
    }
}
