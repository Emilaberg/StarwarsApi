using Microsoft.AspNetCore.Mvc;
using StarwarsApi.Models;
using System.Security.Principal;

namespace StarwarsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        public static List<Character> Characters { get; set; } = new()
        {
            new Character { Id = 1, Name = "Luke Skywalker", IsGood = true, Species = "Human", Gender = "Male", Height = 1.72, Role = "Jedi", Image = "luke_skywalker.jpg" },
            new Character { Id = 2, Name = "Leia Organa", IsGood = true, Species = "Human", Gender = "Female", Height = 1.5, Role = "Princess", Image = "leia_organa.jpg" },
            new Character { Id = 3, Name = "Han Solo", IsGood = true, Species = "Human", Gender = "Male", Height = 1.8, Role = "Smuggler", Image = "han_solo.jpg" },
            new Character { Id = 4, Name = "Obi-Wan Kenobi", IsGood = true, Species = "Human", Gender = "Male", Height = 1.82, Role = "Jedi", Image = "obi_wan_kenobi.jpg" },
            new Character { Id = 5, Name = "Yoda", IsGood = true, Species = "Yoda's species", Gender = "Male", Height = 0.66, Role = "Jedi Master", Image = "yoda.jpg" },
            new Character { Id = 6, Name = "Chewbacca", IsGood = true, Species = "Wookiee", Gender = "Male", Height = 2.28, Role = "Co-pilot", Image = "chewbacca.jpg" },
            new Character { Id = 7, Name = "Darth Vader", IsGood = false, Species = "Human", Gender = "Male", Height = 2.03, Role = "Sith Lord", Image = "darth_vader.jpg" },
            new Character { Id = 8, Name = "Emperor Palpatine", IsGood = false, Species = "Human", Gender = "Male", Height = 1.73, Role = "Sith Lord", Image = "emperor_palpatine.jpg" },
            new Character { Id = 9, Name = "Princess Amidala", IsGood = true, Species = "Human", Gender = "Female", Height = 1.65, Role = "Queen", Image = "princess_amidala.jpg" },
            new Character { Id = 10, Name = "C-3PO", IsGood = true, Species = "Droid", Gender = "Protocol Droid", Height = 1.71, Role = "Translator", Image = "c3po.jpg" },
            new Character { Id = 11, Name = "R2-D2", IsGood = true, Species = "Droid", Gender = "Astromech Droid", Height = 0.96, Role = "Astro-mechanic", Image = "r2d2.jpg" },
            new Character { Id = 12, Name = "Lando Calrissian", IsGood = true, Species = "Human", Gender = "Male", Height = 1.77, Role = "Administrator", Image = "lando_calrissian.jpg" },
            new Character { Id = 13, Name = "Rey", IsGood = true, Species = "Human", Gender = "Female", Height = 1.7, Role = "Jedi", Image = "rey.jpg" },
            new Character { Id = 14, Name = "Kylo Ren", IsGood = false, Species = "Human", Gender = "Male", Height = 1.89, Role = "Sith", Image = "kylo_ren.jpg" },
            new Character { Id = 15, Name = "Finn", IsGood = true, Species = "Human", Gender = "Male", Height = 1.78, Role = "Resistance Fighter", Image = "finn.jpg" },
            new Character { Id = 16, Name = "Poe Dameron", IsGood = true, Species = "Human", Gender = "Male", Height = 1.73, Role = "X-wing Pilot", Image = "poe_dameron.jpg" },
            new Character { Id = 17, Name = "Mace Windu", IsGood = true, Species = "Human", Gender = "Male", Height = 1.88, Role = "Jedi Master", Image = "mace_windu.jpg" },
            new Character { Id = 18, Name = "Padmé Amidala", IsGood = true, Species = "Human", Gender = "Female", Height = 1.65, Role = "Senator", Image = "padme_amidala.jpg" },
            new Character { Id = 19, Name = "Qui-Gon Jinn", IsGood = true, Species = "Human", Gender = "Male", Height = 1.93, Role = "Jedi Master", Image = "qui_gon_jinn.jpg" },
            new Character { Id = 20, Name = "Jar Jar Binks", IsGood = true, Species = "Gungan", Gender = "Male", Height = 1.96, Role = "Gungan Representative", Image = "jar_jar_binks.jpg" },
            new Character { Id = 21, Name = "Darth Maul", IsGood = false, Species = "Dathomirian Zabrak", Gender = "Male", Height = 1.75, Role = "Sith Lord", Image = "darth_maul.jpg" },
            new Character { Id = 22, Name = "Anakin Skywalker", IsGood = true, Species = "Human", Gender = "Male", Height = 1.88, Role = "Jedi Knight", Image = "anakin_skywalker.jpg" },
            new Character { Id = 23, Name = "Ahsoka Tano", IsGood = true, Species = "Togruta", Gender = "Female", Height = 1.88, Role = "Jedi Padawan", Image = "ahsoka_tano.jpg" },
            new Character { Id = 24, Name = "Captain Rex", IsGood = true, Species = "Human", Gender = "Male", Height = 1.83, Role = "Clone Captain", Image = "captain_rex.jpg" },
            new Character { Id = 25, Name = "Count Dooku", IsGood = false, Species = "Human", Gender = "Male", Height = 1.93, Role = "Sith Lord", Image = "count_dooku.jpg" },
            new Character { Id = 26, Name = "General Grievous", IsGood = false, Species = "Kaleesh", Gender = "Male", Height = 2.16, Role = "Supreme Commander", Image = "general_grievous.jpg" },
            new Character { Id = 27, Name = "Jango Fett", IsGood = false, Species = "Human", Gender = "Male", Height = 1.83, Role = "Bounty Hunter", Image = "jango_fett.jpg" },
            new Character { Id = 28, Name = "Boba Fett", IsGood = false, Species = "Human", Gender = "Male", Height = 1.83, Role = "Bounty Hunter", Image = "boba_fett.jpg" },
            new Character { Id = 29, Name = "Greedo", IsGood = false, Species = "Rodian", Gender = "Male", Height = 1.74, Role = "Bounty Hunter", Image = "greedo.jpg" },
            new Character { Id = 30, Name = "Wedge Antilles", IsGood = true, Species = "Human", Gender = "Male", Height = 1.7, Role = "X-wing Pilot", Image = "wedge_antilles.jpg" }
        };
        


        [HttpGet] 
        public ActionResult<List<Character>> Get()
        {
            return Ok(Characters);
        }


        [HttpGet]
        [Route("{id}")]
        public ActionResult<Character> Get(int id)
        {
            Character character = Characters.FirstOrDefault(c => c.Id == id);

            if(character == null) {
                return NotFound("no character with that id was found, try a different id");
            }
            return Ok(character);

        }

        [HttpPost]
        public ActionResult Post(Character character) 
        {
            if(character == null || string.IsNullOrEmpty(character.Name)) 
            {
                return BadRequest("Error adding character, check you JSON request.");
            }

            Characters.Add(character);
            return Ok("Character Added");
        }



    }
}
