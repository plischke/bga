using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using bga_app.models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient.Memcached;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

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
        //POST all player scores to the DB and update necessary tables
        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] object jsonObj)
        {
            DBConnection conn = new DBConnection();
            string connStr = conn.getdbconStr();

            var result = jsonObj.ToString();
            dynamic obj = JsonConvert.DeserializeObject(result);
            int latestRound = getRoundID(); //get the most recent round  from db
            latestRound++; //increment by one to create current roundID

            using (MySqlConnection con = new MySqlConnection(connStr))
            {

                con.Open();
                string query = "INSERT INTO score(strokes, holeID, roundID, playerID) VALUES(@strokes, @holeID, @roundID, @playerID)";
                
                //for each player from request object
                foreach (var o in obj)
                {

                    string courseName = o.course;
                    int courseID = o.courseID;
                    bool nineRound = o.isNineRound;
                    bool eighteenRound = o.isEighteenRound;
                    List<int> hole = getHoleIDS(courseID);
                    int[] holeid = hole.ToArray();

                    if (nineRound)
                    {
                        int playerID = o.player;
                        int hole1 = o.score.Hole1;
                        int hole2 = o.score.Hole2;
                        int hole3 = o.score.Hole3;
                        int hole4 = o.score.Hole4;
                        int hole5 = o.score.Hole5;
                        int hole6 = o.score.Hole6;
                        int hole7 = o.score.Hole7;
                        int hole8 = o.score.Hole8;
                        int hole9 = o.score.Hole9;

                        //insert initial roundID for FK reference in score table
                        insertIntoRoundTable(latestRound, playerID, courseID, nineRound, eighteenRound, con);

                        int[] scores = { hole1, hole2, hole3, hole4, hole5, hole6, hole7, hole8, hole9 };
                        Console.WriteLine(courseName + " " + courseID + " " + playerID);

                        //for every player record the strokes per hole and update DB table
                        for (var i = 0; i < scores.Length; i++)
                        {
                            using (MySqlCommand cmd = new MySqlCommand(query, con))
                            {
                                cmd.Parameters.Add("@strokes", MySqlDbType.Int32);
                                cmd.Parameters["@strokes"].Value = scores[i];

                                cmd.Parameters.Add("@holeID", MySqlDbType.Int32);
                                cmd.Parameters["@holeID"].Value = holeid[i];

                                cmd.Parameters.Add("@roundID", MySqlDbType.Int32);
                                cmd.Parameters["@roundID"].Value = latestRound;

                                cmd.Parameters.Add("@playerID", MySqlDbType.Int32);
                                cmd.Parameters["@playerID"].Value = playerID;

                                cmd.ExecuteNonQuery();
                            }
                            Console.WriteLine("HoleID" + " " + holeid[i] + " " + "Score" + scores[i]);
                        }
                        //get sum of strokes recently inserted in scores table
                        int totalScore = getStrokeTotal(playerID, latestRound, con);

                        //double score to account for averages based on 18 holes
                        totalScore = totalScore * 2;

                        //update round table in db to have total score
                        updateTotalScore(latestRound, playerID, totalScore, con);

                    }
                    if (eighteenRound)
                    {
                        int playerID = o.player;
                        int hole1 = o.score.Hole1;
                        int hole2 = o.score.Hole2;
                        int hole3 = o.score.Hole3;
                        int hole4 = o.score.Hole4;
                        int hole5 = o.score.Hole5;
                        int hole6 = o.score.Hole6;
                        int hole7 = o.score.Hole7;
                        int hole8 = o.score.Hole8;
                        int hole9 = o.score.Hole9;
                        int hole10 = o.score.Hole10;
                        int hole11 = o.score.Hole11;
                        int hole12 = o.score.Hole12;
                        int hole13 = o.score.Hole13;
                        int hole14 = o.score.Hole14;
                        int hole15 = o.score.Hole15;
                        int hole16 = o.score.Hole16;
                        int hole17 = o.score.Hole17;
                        int hole18 = o.score.Hole18;

                        //insert initial roundID for FK reference in score table
                        insertIntoRoundTable(latestRound, playerID, courseID, nineRound, eighteenRound, con);

                        int[] scores = { hole1, hole2, hole3, hole4, hole5, hole6, hole7, hole8, hole9, hole10, hole11, hole12, hole13, hole14, hole15, hole16, hole17, hole18 };
                        Console.WriteLine(courseName + " " + courseID + " " + playerID);

                        //for every player record the strokes per hole and update DB table
                        for (var i = 0; i < scores.Length; i++)
                        {
                            using (MySqlCommand cmd = new MySqlCommand(query, con))
                            {
                                cmd.Parameters.Add("@strokes", MySqlDbType.Int32);
                                cmd.Parameters["@strokes"].Value = scores[i];

                                cmd.Parameters.Add("@holeID", MySqlDbType.Int32);
                                cmd.Parameters["@holeID"].Value = holeid[i];

                                cmd.Parameters.Add("@roundID", MySqlDbType.Int32);
                                cmd.Parameters["@roundID"].Value = latestRound;

                                cmd.Parameters.Add("@playerID", MySqlDbType.Int32);
                                cmd.Parameters["@playerID"].Value = playerID;

                                cmd.ExecuteNonQuery();
                            }
                            Console.WriteLine("HoleID" + " " + holeid[i] + " " + "Score" + scores[i]);
                        }
                        //get sum of strokes recently inserted in scores table
                        int totalScore = getStrokeTotal(playerID, latestRound, con);

                        //update round table in db to have total score
                        updateTotalScore(latestRound, playerID, totalScore, con);

                    }
                }
            
        }

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

        //Retrieves list of Hole Id's from DB based on the course
        public List<int> getHoleIDS(int courseID)
        {
           DBConnection conn = new DBConnection();
           string connStr = conn.getdbconStr();
           List<int> courseInfo = new List<int>();
           using (MySqlConnection con = new MySqlConnection(connStr))
           {
               con.Open();
               string cid = courseID.ToString();
               string query = "SELECT * FROM course as a INNER JOIN (SELECT* FROM hole)as b ON a.courseID = b.courseID WHERE a.courseID = @cid";
               using (MySqlCommand cmd = new MySqlCommand(query, con))
               {
                   cmd.Parameters.Add("@cid", MySqlDbType.Int32);
                   cmd.Parameters["@cid"].Value = courseID;
                   using (MySqlDataReader reader = cmd.ExecuteReader())
                   {
                       if (reader.HasRows)
                       {
                           while (reader.Read())
                           {
                               int holeID = Int32.Parse(reader.GetString(3));
                               courseInfo.Add(holeID);
                           }
                       }
                   }
               }
           }
           return courseInfo;
        }

        //Retrieves the latest Round value from the DB so we can increment when adding a score
        public int getRoundID()
        {
            DBConnection conn = new DBConnection();
            string connStr = conn.getdbconStr();
            int round = 0;
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();
                string query = "SELECT MAX(roundID) from round";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                round = Int32.Parse(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            return round;
        }

        //method for inserting the roundID into the round table, allows insertion to score table in Post method for RI
        public void insertIntoRoundTable(int roundID, int playerID, int courseID, bool isNine, bool isEighteen, MySqlConnection con)
        {
            string query = "INSERT INTO round (roundID, playerID, course, isNineHoleRound, isEighteenHoleRound) VALUES (@roundID, @playerID, @course, @isNine, @isEighteen)";

            using(MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.Add("@roundID", MySqlDbType.Int32);
                cmd.Parameters["@roundID"].Value = roundID;

                cmd.Parameters.Add("@playerID", MySqlDbType.Int32);
                cmd.Parameters["@playerID"].Value = playerID;

                cmd.Parameters.Add("@course", MySqlDbType.Int32);
                cmd.Parameters["@course"].Value = courseID;

                cmd.Parameters.Add("@isNine", MySqlDbType.Bit);
                cmd.Parameters["@isNine"].Value = isNine;

                cmd.Parameters.Add("@isEighteen", MySqlDbType.Bit);
                cmd.Parameters["@isEighteen"].Value = isEighteen;
                cmd.ExecuteNonQuery();
            }
        }

        public int getStrokeTotal(int playerID, int roundID, MySqlConnection con)
        {
            string query = "SELECT SUM(strokes) FROM score WHERE playerID = @playerID AND roundID = @roundID";
            int total = 0;

            using(MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.Add("@playerID", MySqlDbType.Int32);
                cmd.Parameters["@playerID"].Value = playerID;

                cmd.Parameters.Add("@roundID", MySqlDbType.Int32);
                cmd.Parameters["@roundID"].Value = roundID;

                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            total = Int32.Parse(reader.GetString(0));
                        }
                    }
                }
            }
            return total;
        }
        
        public void updateTotalScore(int roundID, int playerID, int total, MySqlConnection con)
        {
            string query = "UPDATE round SET Totalscore = @total WHERE roundID = @roundID AND playerID = @playerID";
            using(MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.Add("@roundID", MySqlDbType.Int32);
                cmd.Parameters["@roundID"].Value = roundID;

                cmd.Parameters.Add("@playerID", MySqlDbType.Int32);
                cmd.Parameters["@playerID"].Value = playerID;

                cmd.Parameters.Add("@total", MySqlDbType.Int32);
                cmd.Parameters["@total"].Value = total;

                cmd.ExecuteNonQuery();
            }
        }
        
    }
}
