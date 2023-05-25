using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using React_Data_Table_webAPI.Data;
using React_Data_Table_webAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace React_Table_Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GettAllStudent()
        {
            var student = _context.students.ToList();
            return Ok(student);

        }

        [HttpPost]
        public IActionResult SaveStudent([FromBody] Student student)
        {
            if (student == null) return BadRequest();
            _context.Add(student);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult UpdateStudent([FromBody] Student student)
        {

            if (student == null) return BadRequest();
            _context.Update(student);
            _context.SaveChanges();
            return Ok();

        }


        [HttpPut("BulkUpdateStudent")]
        public IActionResult BulkUpdateStudent([FromBody] VMmodel vMmodel)
        {

            if (vMmodel == null) return BadRequest();
            for (int i = 0; i < vMmodel.StudentID.Length; i++)
            {
                var StudentFromDB = _context.students.Find(vMmodel.StudentID[i]);

                StudentFromDB.StudentID = vMmodel.StudentID[i];
                StudentFromDB.StudentName = vMmodel.StudentName;
                StudentFromDB.StudentAge = vMmodel.StudentAge;
                StudentFromDB.StudentAddress = vMmodel.StudentAddress;

                _context.Update(StudentFromDB);
            }
           
            _context.SaveChanges();
            return Ok();

        }





        [HttpDelete("{id:int}")]

        public IActionResult DeleteStudent(int id)
        {
            var StudentFromDb = _context.students.Find(id);
            _context.students.Remove(StudentFromDb);
            _context.SaveChanges();
            return Ok();
        }






        [HttpDelete("BulkDelete")]
        

        public IActionResult BulkDelete( List<int> ids)
        {
            //var StudentFromDb = _context.students.Find(id);
            var StudentFromDb = _context.students.Where(s => ids.Contains(s.StudentID));
            _context.students.RemoveRange(StudentFromDb);
            _context.SaveChanges();
            return Ok();
        }





        //[HttpDelete]

        //public IActionResult BatchDelete([FromBody] List<int> ids)
        //{
        //    //var StudentFromDb = _context.students.Find(id);
        //    var StudentFromDb = _context.students.Where(s => ids.Contains(s.StudentID));
        //    _context.students.RemoveRange(StudentFromDb);
        //    _context.SaveChanges();
        //    return Ok();
        //}
    }
}
