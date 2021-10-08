using AngularAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AngularAPI.models;
using AngularAPI.Data.Repo;

namespace AngularAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository reop;

        public CityController(ICityRepository reop)
        {
            this.reop = reop;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await reop.GetCitiesAsync();
            return Ok(cities);
        }

        // Post api/city/add?cityname=Miami
        // Post api/city/add/Los Angeles
        // [HttpPost("add")]
        // [HttpPost("add/{cityName}")]
        // public async Task<IActionResult> AddCity(string cityName)
        // {
        //     var newCity = new City();
        //     newCity.Name = cityName;
        //     await dc.Cities.AddAsync(newCity);
        //     await dc.SaveChangesAsync();
        //     return Ok(newCity);
        // }
        
        // Post api/city/post   --- Post data in JSON Format
        [HttpPost("post")]
        public async Task<IActionResult> AddCity(City city)
        {
            reop.AddCity(city);
            await reop.SaveAsync();
            return StatusCode(201);
        }

        // Post api/city/id
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            reop.DeleteCity(id);
            await reop.SaveAsync();
            return Ok(id);
        }
        
        
    }
}
