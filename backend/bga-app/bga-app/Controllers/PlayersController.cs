using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using bga_app.models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Renci.SshNet;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//refactor all connections with "using" rather than from dbconnection object
namespace bga_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        // GET: api/<ValuesController>
        // Retrieve a list of all players with their average scores
        
        [HttpGet]
        public List<Player> Get()
        {
            DBConnection conn = new DBConnection();
            string connStr = conn.getdbconStr();
            List<Player> players = new List<Player>();
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();
                string query = "SELECT * FROM player as a " +
                    "INNER JOIN(SELECT playerID, AVG(totalScore), COUNT(roundID) FROM round GROUP BY playerID) as b " +
                    "ON a.playerId = b.playerID";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
 
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Player p = new Player();
                                p.playerId = reader.GetString(0);
                                p.firstName = reader.GetString(1);
                                p.lastName = reader.GetString(2);
                                p.avg = reader.GetString(4);
                                p.roundsPlayed = reader.GetString(5);
                                players.Add(p);
                            }

                        }

                    }
                }
            }
            

            return players;
        }

        // GET api/<ValuesController>/5
        // Retrieve player by id
        [HttpGet("{id}")]
        public List<Player> Get(int id)
        {
            DBConnection conn = new DBConnection();
            string connStr = conn.getdbconStr();
            List<Player> player = new List<Player>();
            using(MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();
                string pid = id.ToString();
                string query = "SELECT * FROM player WHERE playerId = @pid";
                using(MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    using(MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Player p = new Player();
                                p.firstName = reader.GetString(1);
                                p.lastName = reader.GetString(2);
                                player.Add(p);
                            }
                        }
                    }
                }
            }

            return player;
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
