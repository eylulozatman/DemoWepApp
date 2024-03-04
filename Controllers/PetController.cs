using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoWepApp.Models;
using DemoWepApp.Services;

namespace DemoWepApp.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PetController : Controller
{
   
        public static List<Pet> PetsList = new List<Pet>();
        private readonly PetService _petService;

        public PetController(PetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public IActionResult Get()
        {
        
            return Ok(PetsList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var energy = _petService.GetPetEnergyById(id,PetsList);
            if (energy == -1)
            {
                return NotFound(); // Pet bulunamadıysa 404 NotFound dön
            }
            return Ok(energy);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Pet pet)
        {
            _petService.CreateNewPet(pet,PetsList);
            return Ok();
        }

}
