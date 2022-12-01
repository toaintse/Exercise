using DemoDictionary;

internal class Program
{
    private static void NotifyGPAChange()
    {
        Console.WriteLine("GPA changed.");
    }
    private static void Main(string[] args)
    {
        Student student = new Student();
        student.OnGPAChange += new GPAChangeHandler(NotifyGPAChange); //gan ham xu ly su kien,
                                                                      //khi GPA Change thi goi ham NotifyGPAChange thuc thi
        student.StudentID = 1;
        student.StudentName = "Luong";
        student.AddCourse(new Course(1, "PRN211"), 7);
        student.AddCourse(new Course(2, "PRU211"), 6);
        student.AddCourse(new Course(3, "CSD201"), 6.5);
        Console.WriteLine(student);
        student.RemoveCourse(2);
        Console.WriteLine(student);
    }
}