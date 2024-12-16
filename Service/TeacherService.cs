public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _teacherRepository;
    public TeacherService(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }
    public List<TeacherListDTO> GetTeachers()
    {
        List<TeacherListDMO> teacherDMOs = _teacherRepository.GetAll(); 
        List<TeacherListDTO> teacherListDTOs = new List<TeacherListDTO>();

        foreach (var item in teacherDMOs)
        {
            teacherListDTOs.Add(new TeacherListDTO
            {
                ID = item.ID,
                Name = item.Name,
                Surname = item.Surname,
                Lesson = item.Lesson,
            });
        }

        return teacherListDTOs;       
    }
}

public interface ITeacherService
{
    List<TeacherListDTO> GetTeachers();
}