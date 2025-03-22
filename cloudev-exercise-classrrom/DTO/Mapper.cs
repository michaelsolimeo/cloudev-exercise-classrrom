using cloudev_exercise_classrrom.Entities;

namespace cloudev_exercise_classrrom.DTO
{
    public class Mapper
    {
        public StudentDTO MapEntityToDTO(Student student)
        {
            return new StudentDTO
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                Email = student.Email,
                Password = student.Password,
            };
        }
        public Student MapDTOtoEntity(StudentDTO student)
        {
            return new Student
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                Email = student.Email,
                Password = student.Password,
                ClassroomId = student.ClassroomId,
            };
        }
        public ClassroomDTO MapEntityToDTO(Classroom classroom)
        {
            return new ClassroomDTO
            {
                Id = classroom.Id,
                RoomName = classroom.RoomName,
            };
        }
        public Classroom MapDTOToEntity(ClassroomDTO classroom)
        {
            return new Classroom
            {
                Id = classroom.Id,
                RoomName = classroom.RoomName,
            };
        }
    }
}
