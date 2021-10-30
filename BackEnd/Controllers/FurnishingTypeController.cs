using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BackEnd.Dtos;
using BackEnd.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    public class FurnishingTypeController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public FurnishingTypeController(IUnitOfWork uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        // GET api/furnishingtype/list
        [HttpGet("list")]
        public async Task<IActionResult> GetFurnishingTypes()
        {
            var furnishingTypes = await uow.furnishingTypeRepository.GetFurnishingTypeAsync();
            var furnishingtypeDto = mapper.Map<IEnumerable<KeyValuePairDto>>(furnishingTypes);
            return Ok(furnishingtypeDto);
        }
    }
}