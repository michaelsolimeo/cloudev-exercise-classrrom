using System.ComponentModel.DataAnnotations.Schema;

namespace cloudev_exercise_classrrom.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int ClassroomId { get; set; }
        [ForeignKey(nameof(ClassroomId))]
        Classroom? Classroom { get; set; }
    }
}
