using Apple.Core.Entities;
using Apple.Core.UnitOfWork;
using Apple.Data;
using Apple.Service.DTOs.CategoryDTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Apple.API.Admin.Controllers
{
    [Route("admin/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public CategoriesController(IUnitOfWork unitOfWork, IMapper mapper, DataContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryPostDTO postDTO)
        {
            Category category = new Category
            {
                Name = postDTO.Name,
                IsDelete = false
            };
           var result = await _unitOfWork.CategoryRepository.InsertAsync(category);
           await _unitOfWork.Commit();
            CategoryGetDTO getDTO=_mapper.Map<CategoryGetDTO>(category);
            return Ok(getDTO);
        }
    }
}
