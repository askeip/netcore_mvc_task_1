using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Extrem_MVC_1.Models;

namespace Extrem_MVC_1.Controllers
{
    public class StudentController : Controller
    {
        static List<StudentModel> Students = new List<StudentModel>
        {
            new StudentModel{StudentID = 1, Name = "Evgeny", Surname = "Petrosyan", Course = 4, Group = "FIIT"}
        };

        public void CreateStudent([FromBody]StudentModel student)
        {
            Students.Add(student);
        }

        public IActionResult GetStudent(int studentID)
        {
            var student = Students.FirstOrDefault(x =>
                    x.StudentID == studentID);
            if (student != null)
                return Json(student);
            return BadRequest();
        }

        public void UpdateStudent([FromBody]StudentModel student)
        {
            Students[Students.FindIndex(x => x.StudentID == student.StudentID)] = student;
        }

        public void DeleteStudent(int studentID)
        {
            Students.RemoveAt(Students.FindIndex(x => x.StudentID == studentID));
        }
    }
}
