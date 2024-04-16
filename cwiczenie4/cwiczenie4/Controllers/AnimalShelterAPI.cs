using Microsoft.AspNetCore.Mvc;
namespace AnimalShelterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private static List<Animal> animals = new List<Animal>
        {
            new Animal { Id = 1, Name = "Burek", Category = "Pies", Mass = 20, Color = "Brązowy" },
            new Animal { Id = 2, Name = "Filemon", Category = "Kot", Mass = 5, Color = "Czarny" }
        };

        [HttpGet]
        public ActionResult<List<Animal>> GetAnimals()
        {
            return animals;
        }

        [HttpGet("{id}")]
        public ActionResult<Animal> GetAnimal(int id)
        {
            var animal = animals.Find(a => a.Id == id);
            if (animal == null)
            {
                return NotFound();
            }
            return animal;
        }

        [HttpPost]
        public IActionResult AddAnimal(Animal animal)
        {
            animals.Add(animal);
            return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, Animal updatedAnimal)
        {
            var index = animals.FindIndex(a => a.Id == id);
            if (index == -1)
            {
                return NotFound();
            }
            animals[index] = updatedAnimal;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            var index = animals.FindIndex(a => a.Id == id);
            if (index == -1)
            {
                return NotFound();
            }
            animals.RemoveAt(index);
            return NoContent();
        }
    }

    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Mass { get; set; }
        public string Color { get; set; }
    }
}