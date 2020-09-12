using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarProject.Models;

namespace CarProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private List<CarModels> cars;

        public CarController()
        {
            cars = new List<CarModels>()
            {
                new CarModels() { Id = 1, BornPlace = "Almaty", CarName = "Mercedes", Cost = "12 000 000"},
                new CarModels() { Id = 2, BornPlace = "Nur-Sultan", CarName = "Camry", Cost = "9 000 000"},
                new CarModels() { Id = 3, BornPlace = "Seoul", CarName = "Lamborgini", Cost = "15 000 000"},
                new CarModels() { Id = 4, BornPlace = "Almaty", CarName = "Solano Lifan", Cost = "4 000 000"},
                new CarModels() { Id = 5, BornPlace = "Nur-Sultan", CarName = "Jeap", Cost = "8 000 000"},
            };

        }

        [HttpGet]
        public List<CarModels> GetCars()
        {
            return cars;
        }

        [HttpGet("bornplace/{bornplace}")]

        public List<CarModels> GetCarsByBirthPlace(string bornplace)
        {
            return cars.Where(c => c.BornPlace.ToLower() == bornplace.ToLower()).ToList();
        }

        [HttpGet("carName/{carName}")]
        public CarModels GetCar(string carName)
        {
            return cars.Where(c => c.CarName.ToLower() == carName.ToLower()).FirstOrDefault();
        }
    }
}