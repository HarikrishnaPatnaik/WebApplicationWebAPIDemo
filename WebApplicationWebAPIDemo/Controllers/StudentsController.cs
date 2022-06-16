using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationWebAPIDemo.Model;

namespace WebApplicationWebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "StudentOpenAPISpec")]
    public class StudentsController : ControllerBase
    {
        private IRepositoryStudent _repoStudent;

        public StudentsController(IRepositoryStudent repositoryStudent)
        {
            _repoStudent = repositoryStudent;
        }

        [HttpGet]
        [ProducesDefaultResponseType]
        public ActionResult GetAllStudents()
        {
            List<Student> listStudents = new List<Student>();
            try
            {
                listStudents = _repoStudent.GetAllStudents().ToList();
                if (listStudents == null || listStudents.Count == 0)
                    return NotFound();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetAllStudents", "Error while fetching the students");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return Ok(listStudents);
        }

        [HttpGet("{id:int}")]
        [ProducesDefaultResponseType]
        public ActionResult GetStudent(int? id)
        {
            if (id == null || id == 0)
                return BadRequest();
            Student student = new Student();
            try
            {
                student = _repoStudent.GetStudent(id);
                if (student == null)
                    return NotFound();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetStudent", "Error while fetching the student");
                return StatusCode(500, ModelState);
            }

            return Ok(student);
        }

        [HttpPost]
        [ProducesDefaultResponseType]
        public ActionResult CreateStudent([FromBody] Student student)
        {
            try
            {
                if (student == null)
                    return BadRequest(ModelState);
               
                bool isExists = _repoStudent.IsStudentExists(student.StdEmail);
                if (isExists)
                {
                    ModelState.AddModelError("CreateStudent", "Student record already exists.");
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }                    

                bool result = _repoStudent.CreateStudent(student);
                if (!result)
                    return BadRequest();

                return StatusCode(StatusCodes.Status201Created);

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("CreateStudent", "Error while creating the student");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }            
        }

        [HttpPut]
        [ProducesDefaultResponseType]
        public ActionResult UpdateStudent([FromBody] Student student)
        {
            try
            {
                if (student == null)
                    return BadRequest(ModelState);

                if (!_repoStudent.IsStudentExists(student.StdId))
                    return NotFound();

                bool result = _repoStudent.UpdateStudent(student);
                if (!result)
                    return StatusCode(StatusCodes.Status500InternalServerError);

                return NoContent();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("UpdateStudent", "Error while updating the student");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            
        }

        [HttpDelete("{id:int}")]
        [ProducesDefaultResponseType]
        public ActionResult DeleteStudent(int? id)
        {
            try
            {
                if (id == null || id == 0)
                    return BadRequest();

                if (!_repoStudent.IsStudentExists(id))
                    return NotFound();

                Student student = _repoStudent.GetStudent(id);
                bool result = _repoStudent.DeleteStudent(student);
                if (!result)
                    return StatusCode(StatusCodes.Status500InternalServerError);

                return NoContent();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("DeleteStudent", "Error while deleting the student");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            
        }
    }
}
