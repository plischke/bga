﻿using System;
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
    public class CourseScorecardController : ControllerBase
    {
        
        // GET: api/<ValuesController>
        [HttpGet]
        public List<CourseScorecard> Get()
        {
            DBConnection conn = new DBConnection();
            string connStr = conn.getdbconStr();
            List<CourseScorecard> scoreCard = new List<CourseScorecard>();
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                string query = "SELECT * FROM course as a INNER JOIN(SELECT* FROM hole)as b ON a.courseID = b.courseID";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                CourseScorecard cs = new CourseScorecard();
                                cs.courseID = reader.GetString(0);
                                cs.courseName = reader.GetString(1);
                                cs.coursePar = reader.GetString(2);
                                cs.holeID = reader.GetString(3);
                                cs.par = reader.GetString(4);
                                cs.yardage = reader.GetString(5);
                                cs.description = reader.GetString(7);
                                scoreCard.Add(cs);
                            }

                        }
                    }
                }
            }
            return scoreCard;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public List<CourseScorecard> Get(int id)
        {
            DBConnection conn = new DBConnection();
            string connStr = conn.getdbconStr();
            List<CourseScorecard> scorecard = new List<CourseScorecard>();
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();
                string cid = id.ToString();
                string query = "SELECT * FROM course as a INNER JOIN(SELECT* FROM hole)as b ON a.courseID = b.courseID  WHERE a.courseID = @cid";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.Add("@cid", MySqlDbType.Int32);
                    cmd.Parameters["@cid"].Value = id;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                CourseScorecard cs = new CourseScorecard();
                                cs.courseID = reader.GetString(0);
                                cs.courseName = reader.GetString(1);
                                cs.coursePar = reader.GetString(2);
                                cs.holeID = reader.GetString(3);
                                cs.par = reader.GetString(4);
                                cs.yardage = reader.GetString(5);
                                cs.description = reader.GetString(7);
                                scorecard.Add(cs);
                            }
                        }
                    }
                }
            }
            return scorecard;
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
