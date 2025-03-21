using System.ComponentModel.DataAnnotations;

namespace cloudev_exercise_classrrom.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int ClassroomId { get; set; }
    }
}
