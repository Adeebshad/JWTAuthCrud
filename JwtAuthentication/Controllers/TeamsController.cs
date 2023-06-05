using JwtAuthentication.Models;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private static List<Team> teams = new List<Team>()
        {
            new Team()
            {
                Country = "Faa",
                Id = 1,
                Name= "Test"
            },
            new Team()
            {
                 Country = "TaD",
                Id = 2,
                Name= "Nhbs"
            },
            new Team()
            {
                 Country = "Philipain",
                Id = 3,
                Name= "Jkkm"
            }
        };

        [HttpGet]

        public IActionResult Get()
        {
            return Ok(teams);
        }

        [HttpGet("{id:int}")]

        public IActionResult Get(int id)
        {
            var team = teams.FirstOrDefault(x => x.Id == id);
            if (team == null) {
                return BadRequest("Invalid requset");
            }
            return Ok(team);

        }
        [HttpPost]
        public IActionResult Post(Team team)
        {
            teams.Add(team);
            return CreatedAtAction("Get", team.Id, team);
        }

        [HttpPatch]
        public IActionResult Patch(int id, string name) {
            var team = teams.FirstOrDefault(x => x.Id == id);
            if (team == null)
                return BadRequest("Invalid");


            team.Name = name;
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id) {
            var team = teams.FirstOrDefault(x => x.Id == id);
            if (team == null)
                return BadRequest("Invalid");

            teams.Remove(team);
            return NoContent();
        }
    }
}
