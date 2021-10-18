using BackEnd.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEnd.models;
using BackEnd.Interfaces;
using BackEnd.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

namespace BackEnd.Controllers
{
    [Authorize]
    //                      This is Custom Controller
    public class CityController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CityController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet ("cities")]
        public async Task<IActionResult> GetCities()
        {
            var cities = await uow.cityRepository.GetCitiesAsync();

            var citiesDto = mapper.Map<IEnumerable<CityDto>>(cities);
            // var citiesDto = from c in cities
            //                 select new CityDto(){
            //                     Id = c.Id,
            //                     Name = c.Name
            //                 };

            return Ok(citiesDto);
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
        public async Task<IActionResult> AddCity(CityDto cityDto)
        {
            // var city = new City {
            //     Name = cityDto.Name,
            //     LastUpdatedBy = 1,
            //     LastUpdatedOn = DateTime.Now
            // };

            var city = mapper.Map<City>(cityDto);
            city.LastUpdatedBy = 1;
            city.LastUpdatedOn = DateTime.Now;

            uow.cityRepository.AddCity(city);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCity(int id, CityDto cityDto)
        {
            try
            {
                if (id != cityDto.Id)
                    return BadRequest("Update are not allowed!");

                var cityFromDb = await uow.cityRepository.FindCity(id);

                if (cityFromDb == null)
                    return BadRequest("Update are not allowed!");

                cityFromDb.LastUpdatedBy = 1;
                cityFromDb.LastUpdatedOn = DateTime.Now;
                mapper.Map(cityDto, cityFromDb);

                await uow.SaveAsync();

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Unknown error occured!");
            }
        }

        [HttpPatch("updateCityName/{id}")]
        public async Task<IActionResult> UpdateCityPatch(int id, JsonPatchDocument<City> cityTpPatch)
        {
            var cityFromDb = await uow.cityRepository.FindCity(id);
            cityFromDb.LastUpdatedBy = 1;
            cityFromDb.LastUpdatedOn = DateTime.Now;

            cityTpPatch.ApplyTo(cityFromDb, ModelState);

            await uow.SaveAsync();

            return StatusCode(200);
        }

        // Post api/city/id
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.cityRepository.DeleteCity(id);
            await uow.SaveAsync();
            return Ok(id);
        }


    }
}
