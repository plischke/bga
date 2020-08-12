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
    public class AverageScorePerCourseController : ControllerBase
    {
        // GET: api/<ValuesController>
        private string connStr = string.Format("Server=localhost; database={0}; UID=root; password=tylerp93", "mydb");
        [HttpGet]
        public List<AvgScorePerPlayerPerCourse> Get()
        {
            List<AvgScorePerPlayerPerCourse> score = new List<AvgScorePerPlayerPerCourse>();
            //var dbCon = DBConnection.Instance();
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                string query = "SELECT playerId, firstName, lastName, AVG(totalScore), courseId, courseName FROM playerRounds GROUP BY courseID, playerId";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                AvgScorePerPlayerPerCourse s = new AvgScorePerPlayerPerCourse();
                                s.playerId = reader.GetString(0);
                                s.firstName = reader.GetString(1);
                                s.lastName = reader.GetString(2);
                                s.average = reader.GetString(3);
                                s.courseID = reader.GetString(4);
                                s.courseName = reader.GetString(5);
                                score.Add(s);
                            }

                        }
                    }
                }
            }
            return score;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
