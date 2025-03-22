using System.ComponentModel.DataAnnotations.Schema;

namespace cloudev_exercise_classrrom.Entities
{
    public class Classroom
    {
        public int Id { get; set; }
        public required string RoomName { get; set; }
        public List<Student>? Students { get; set; }
    }
}
