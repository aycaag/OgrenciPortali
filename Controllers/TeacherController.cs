using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
public class TeacherController : Controller
{
    private readonly ITeacherService _teacherService;
    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpGet]
    public IActionResult TeacherList()
    {
        List<TeacherListDTO> listDTO = _teacherService.GetTeachers();
        List<Teacher> _teacherList = new List<Teacher>();
        foreach (var item in listDTO)
        {
            _teacherList.Add(new Teacher
            {
                ID = item.ID,
                Name = item.Name,
                Surname = item.Surname,
                Lesson = item.Lesson,
            });
        }

        TeacherListModel returnModel = new TeacherListModel();

        returnModel.teacherList = _teacherList;

        List<string> lessonList = new List<string>();

        foreach (var item in _teacherList)
        {
            if (!lessonList.Exists(x => x == item.Lesson))
            {
                lessonList.Add(item.Lesson);
            }
        }

        returnModel.lessonList = lessonList;

        return View(returnModel);
    }

    [HttpPost]
    public IActionResult TeacherList(TeacherListModel model)
    {


        List<TeacherListDTO> listDTO = _teacherService.GetTeachers();
        List<Teacher> _teacherList = new List<Teacher>();

        foreach (var item in listDTO)
        {
            _teacherList.Add(new Teacher
            {
                ID = item.ID,
                Name = item.Name,
                Surname = item.Surname,
                Lesson = item.Lesson,
            });
        }

        List<string> lessonList = new List<string>();

        foreach (var item in _teacherList)
        {
            if (!lessonList.Exists(x => x == item.Lesson))
            {
                lessonList.Add(item.Lesson);
            }
        }

        model.lessonList = lessonList;

        if (model.selectedLesson!="Ders Seçiniz")
        {
        Expression<Func<Teacher, bool>> teacherExpression = x => x.Lesson == model.selectedLesson;
        Func<Teacher, bool> teacherFunc = teacherExpression.Compile();

        model.teacherList = _teacherList.Where(teacherFunc).ToList();
        
        }
        else 
        {
            model.teacherList=_teacherList;
        }


        return View(model);
    }

}