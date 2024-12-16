using Microsoft.EntityFrameworkCore;

public class TeacherRepository : ITeacherRepository
{

    private readonly OgrenciPortaliDbContext _context;
    public TeacherRepository(OgrenciPortaliDbContext context)
    {
        _context = context; 
    }
    public List<TeacherListDMO> GetAll()
    {
        List<TeacherListDMO> TeacherListDMOs = _context.Teacher.FromSqlRaw("EXEC sp_TeacherLessons").ToList();

        return TeacherListDMOs;
    }
}


public interface ITeacherRepository
{
    List<TeacherListDMO>  GetAll() ;
}