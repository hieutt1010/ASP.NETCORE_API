using ASPNETCORE_API.Models.DTO;
using ASPNETCORE_API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCORE_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkController : Controller
    {
        private readonly iWalkRepository iWalkRepository;
        private readonly IMapper mapper;
        public WalkController(iWalkRepository _iWalkRepository, IMapper _mapper)
        {
            iWalkRepository = _iWalkRepository;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalksAsync()
        {
            // Fetch data from database - Domain walks
            var walkDomain = await iWalkRepository.GetAllAsync();
            // Convert domain walks to DTO Walk
            var walkDTO = mapper.Map<List<Models.DTO.Walk>>(walkDomain);
            // Return resopnse
            return Ok(walkDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkAsync")]
        public async Task<IActionResult> GetWalkAsync(Guid id)
        {
            var walkDomain = await iWalkRepository.GetWalkByIdAsync(id);
            var walkDTO = mapper.Map<Models.DTO.Walk>(walkDomain);
            return Ok(walkDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkAsync([FromBody] AddWalkRequest addWalkRequest)
        {
            // Convert DTO to Domain obj
            var walkDomain = new Models.Domain.Walk()
            {
                Length = addWalkRequest.Length,
                Name = addWalkRequest.Name,
                RegionId = addWalkRequest.RegionId,
                WalkDifficultyId = addWalkRequest.WalkDifficultyId
            };
            // Pass Domain obj to repository to persist this
            walkDomain = await iWalkRepository.AddAsync(walkDomain);
            // convert Domain obj to DTO
            var walkDTO = new Models.DTO.Walk()
            {
                Id = walkDomain.Id,
                Length = walkDomain.Length,
                Name = walkDomain.Name,
                RegionId = walkDomain.RegionId,
                WalkDifficultyId = walkDomain.WalkDifficultyId
            };
            // Send DTO back to client
            return CreatedAtAction(nameof(GetWalkAsync), new { id = walkDTO.Id }, walkDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkAsync([FromRoute] Guid id,
            [FromBody] UpdateWalkRequest updateWalkRequest)
        {
            // Convert DTO to Domain
            var walkDomain = new Models.Domain.Walk()
            {
                Length = updateWalkRequest.Length,
                Name = updateWalkRequest.Name,
                RegionId = updateWalkRequest.RegionId,
                WalkDifficultyId = updateWalkRequest.WalkDifficultyId
            };

            // Save to Repository - Get Domain object in response (or Null)
            walkDomain = await iWalkRepository.UpdateAsync(id, walkDomain);

            // Handle null (not null)
            if (walkDomain == null)
            {
                return NotFound();
            }

            // Convert Domain to DTO
            var walkDTO = new Models.DTO.Walk()
            {
                Id = walkDomain.Id,
                Length = walkDomain.Length,
                Name = walkDomain.Name,
                RegionId = walkDomain.RegionId,
                WalkDifficultyId = walkDomain.WalkDifficultyId
            };

            // Return response
            return Ok(walkDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            //Call Repository
            var existingWalk = await iWalkRepository.DeleteAsync(id);

            if (existingWalk == null)
            {
                return NotFound();
            }

            var walkDTO = mapper.Map<Models.DTO.Walk>(existingWalk);
            return Ok(walkDTO);
        }
    }
}