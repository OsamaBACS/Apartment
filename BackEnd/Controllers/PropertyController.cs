using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BackEnd.Dtos;
using BackEnd.Interfaces;
using BackEnd.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    public class PropertyController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IPhotoService photoService;

        public PropertyController(IUnitOfWork uow, IMapper mapper, IPhotoService photoService)
        {
            this.photoService = photoService;
            this.uow = uow;
            this.mapper = mapper;
        }

        // property/type/1
        [HttpGet("list/{sellRent}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPropertyList(int sellrent)
        {
            var properties = await uow.propertyRepository.GetPropertiesAsync(sellrent);
            var propertyListDto = mapper.Map<IEnumerable<PropertyListDto>>(properties);
            return Ok(propertyListDto);
        }

        // property/detail/1
        [HttpGet("detail/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPropertyDetail(int id)
        {
            var property = await uow.propertyRepository.GetPropertyDetailAsync(id);
            var propertyDto = mapper.Map<PropertyDetailDto>(property);
            return Ok(propertyDto);
        }

        // property/add
        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddProperty(PropertyDto propertyDto)
        {
            var property = mapper.Map<Property>(propertyDto);
            var userId = GetUserId();
            property.PostedBy = userId;
            property.LastUpdatedBy = userId;
            uow.propertyRepository.AddProperty(property);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        // property/add/photo/1
        [HttpPost("add/photo/{propId}")]
        [Authorize]
        public async Task<IActionResult> AddPropertyPhoto(IFormFile file, int propId)
        {
            var result = await photoService.UploadPhotoAsync(file);
            if(result.Error != null)
                return BadRequest(result.Error.Message);

            var property = await uow.propertyRepository.GetPropertyByIdAsync(propId);
            var photo = new Photo
            {
                ImageUrl = result.SecureUrl.AbsoluteUri,
                publicId = result.PublicId
            };

            if(property.Photos.Count == 0)
            {
                photo.IsPrimary = true;
            }

            property.Photos.Add(photo);
            await uow.SaveAsync();

            return StatusCode(201);
        }
    }
}