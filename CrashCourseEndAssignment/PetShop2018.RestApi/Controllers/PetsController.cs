using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop2018.Core.ApplicationService;
using PetShop2018.Core.Entities;

namespace PetShop2018.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // GET api/pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetPets();
        }

        // GET api/pets/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            if (id < 1) return BadRequest("Id must be greater then 0");
            return _petService.GetPet(id);
        }

        // POST api/pets
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            try
            {
                return Ok(_petService.CreatePet(pet));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/pets/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id < 1 || id != pet.Id)
            {
                return BadRequest("Parameter Id and customer ID must be the same");
            }
            return Ok(_petService.UpdatePet(pet));
        }

        // DELETE api/pets/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _petService.DeletePet(id);
        }
    }
}
