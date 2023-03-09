using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace prj1stAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalTypesController : ControllerBase
    {
        private static readonly string[] GetAll = new[]
        {
        "Dog", "Cat", "Wolf", "Horse", "Lion", "Tiger", "Gorilla", "Bat", "Goat", "Shark"
    };

        private readonly ILogger<AnimalTypesController> _logger;

        public AnimalTypesController(ILogger<AnimalTypesController> logger)
        {
            _logger = logger;
        }

        [HttpGet("All")]
        public IEnumerable<AnimalTypes> Get()
        {
            return Enumerable.Range(1, 10).Select(index => new AnimalTypes
            {
                Date = DateTime.Now.AddDays(index),
                Type = GetAll[Random.Shared.Next(GetAll.Length)]
            })
            .ToArray();
        }
        [HttpGet("Random")]
        public string GetRandomWord()
        {
            Random randGen = new Random();
            int randomIndex = randGen.Next(0, GetAll.Length - 1);
            return GetAll[randomIndex];
        }

        [HttpGet("Alphatical")]
        public IEnumerable<string> GetSortedWords()
        {
            Array.Sort(GetAll);
            return GetAll;
        }

    }
}