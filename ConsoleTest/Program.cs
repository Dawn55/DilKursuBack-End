using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

LessonManager lessonManager = new LessonManager(new EfLessonDal());
var getAll = lessonManager.GetAll();
if(getAll.Success == true)
{
    foreach (var lesson in getAll.Data)
    {
        Console.WriteLine(lesson.Name);
    }
}

Console.WriteLine(getAll.Message);


