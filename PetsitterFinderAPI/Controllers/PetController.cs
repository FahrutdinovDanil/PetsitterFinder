using Core;
using Core.DB;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace PetsitterFinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : Controller
    {

        [HttpGet]
        public IEnumerable<PetModel> GetPets()
        {
            var pets = DataAccess.GetPets().Select(x => new PetModel(x));
            return pets;
        }

        [HttpGet("{id}")]
        public ActionResult<PetModel> GetPet(int id)
        {
            var pet = new PetModel(DataAccess.GetPet(id));

            if (pet == null)
                return NotFound();

            return pet;
        }

        [HttpPost]
        public ActionResult Post(Pet pet)
        {
            DataAccess.SavePet(pet);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            pet.Id = id;
            if (DataAccess.GetPet(id) == null)
                return BadRequest();

            DataAccess.SavePet(pet);
            return Ok(new PetModel(DataAccess.GetPet(id)));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pet = new PetModel(DataAccess.GetPet(id));

            if (pet is null)
                return NotFound();

            DataAccess.RemovePet(id);

            return NoContent();
        }

    }
}
