using StudentManager;
using System;
using System.Runtime.InteropServices;

internal class Program
{
    private static void Main(string[] args)
    {
        StudentList studentList = new StudentList();
        string filename = "..\\..\\Students.txt";
        while (true)
        {
            int k = GetChoose();
            switch (k)
            {
                case 0: return;
                case 1:
                    studentList.ReadFromFile(filename);
                    break;
                case 2:
                    studentList.Display();
                    break;
                case 3:
                    studentList.SortByID();
                    studentList.Display();
                    break;
                case 4:
                    studentList.SortByName();
                    studentList.Display();
                    break;
                case 5:
                    studentList.SortByGPA();
                    studentList.Display();
                    break;
                case 6:
                    Console.WriteLine("Nhap 1 gia tri GPA:");
                    float gpa = Convert.ToSingle(Console.ReadLine());
                    List<Student> result = studentList.SearchByGPA(gpa);
                    result.Display();
                    break;

                case 7:
                    //search theo Major - tu bo sung
                    Console.WriteLine("Nhap 1 gia tri Major:");
                    string major = Console.ReadLine().Trim();
                    studentList.SearchByMajor(major);
                    break;
            }
        }
    }
    

    private static void ShowMenu()
    {
        Console.WriteLine("Choose:");
        Console.WriteLine("1. ReadFromFile");
        Console.WriteLine("2. Display list of student");
        Console.WriteLine("3. Sort by Id");
        Console.WriteLine("4. Sort by Name");
        Console.WriteLine("5. Sort by GPA");
        Console.WriteLine("6. Search by GPA");
        Console.WriteLine("7. Search by Major");        
    }

    private static int GetChoose()
    {
        ShowMenu();
        Console.WriteLine("Select function, 0 to exit:");
        int choose = Convert.ToInt32( Console.ReadLine());
        return choose;
    }
}