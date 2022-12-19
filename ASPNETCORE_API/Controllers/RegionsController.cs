using ASPNETCORE_API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCORE_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly iRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(iRegionRepository _regionRepository, IMapper _mapper)
        {
            this.mapper = _mapper;
            this.regionRepository = _regionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var regions = await regionRepository.GetAllAsync(); // get from database 

            // Return DTO regions
            // var regionsDTO = new List<Models.DTO.Region>();
            // regions.ToList().ForEach(region => {
            //     var regionDTO = new Models.DTO.Region()
            //     {
            //         Id = region.Id,
            //         Code = region.Code,
            //         Name = region.Name,
            //         Area = region.Area,
            //         Lat = region.Lat,
            //         Long = region.Long,
            //         Population = region.Population
            //     };
            
            //     regionsDTO.Add(regionDTO);
            // });

            var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions); //Mapping obj from database => DTO

            return Ok(regionsDTO); // 200 success response!!!
        }
    }
}