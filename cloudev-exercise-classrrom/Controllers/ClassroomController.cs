using cloudev_exercise_classrrom.DTO;
using cloudev_exercise_classrrom.Entities;
using Microsoft.AspNetCore.Http;
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
    }
}
