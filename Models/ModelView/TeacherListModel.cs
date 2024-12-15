public class TeacherListModel
{
    public List<string> lessonList{ get; set; }
    public List<Teacher> teacherList { get; set; }
    public string selectedLesson { get; set; }  
}

public class Teacher
{
    public int ID { get; set; } 
    public string Name { get; set; }    
    public string Surname   { get; set; }   
    public string Lesson { get; set; }  
}