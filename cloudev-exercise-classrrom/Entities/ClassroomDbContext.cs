using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace cloudev_exercise_classrrom.Entities
{
    public class ClassroomDbContext : DbContext
    {
        public ClassroomDbContext(DbContextOptions<ClassroomDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
    }
}
