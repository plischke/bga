using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using bga_app.models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bga_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        // GET: api/<ValuesController>
        //Retrieve a list of all courses
        private string connStr = string.Format("Server=localhost; database={0}; UID=root; password=tylerp93", "mydb");
        [HttpGet]
        public List<Course> Get()
        {
            List<Course> courses = new List<Course>();
            //var dbCon = DBConnection.Instance();
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                    string query = "SELECT * FROM course";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Course c = new Course();
                                    c.courseID = reader.GetString(0);
                                    c.courseName = reader.GetString(1);
                                    c.par = reader.GetString(2);
                                    courses.Add(c);
                                }

                            }
                        }
                    }  
            }
            return courses;
        }

        // GET api/<ValuesController1>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController1>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
