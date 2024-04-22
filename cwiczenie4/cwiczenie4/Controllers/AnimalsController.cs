using Microsoft.AspNetCore.Mvc;
using cwiczenie4.Models;

namespace cwiczenie4.Controllers;
    
[Route("api/[controller]")]
[ApiController] public class AnimalsController : ControllerBase
    {
        private static List<Animal> animals = new List<Animal>
        {
            new Animal { Id = 1, Name = "Burek", Category = "Pies", Mass = 20, Color = "Brązowy" },
            new Animal { Id = 2, Name = "Filemon", Category = "Kot", Mass = 5, Color = "Czarny" }
        };

        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public IActionResult GetAnimal(int id)
        {
            var animal = animals.FirstOrDefault(st => st.Id == id);
            if (animal == null)
            {
                return NotFound($"Animal with id {id} was not found");
            }
        
            return Ok(animals);
        }

        [HttpPost]
        public IActionResult CreateAnimal(Animal animal)
        {
            animals.Add(animal);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateAnimal(int id, Animal animal)
        {
            var animalToEdit= animals.FirstOrDefault(s => s.Id == id);

            if (animalToEdit == null)
            {
                return NotFound($"Animal with id {id} was not found");
            }
        
            animals.Remove(animalToEdit);
            animals.Add(animal);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            var animalToEdit= animals.FirstOrDefault(s => s.Id == id);
            if (animalToEdit == null)
            {
                return NoContent();
            }

            animals.Remove(animalToEdit);
            return NoContent();
        }
    }