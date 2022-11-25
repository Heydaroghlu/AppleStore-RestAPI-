using Apple.Core.Entities;
using Apple.Core.UnitOfWork;
using Apple.Data;
using Apple.Service.DTOs.CategoryDTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apple.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public CategoriesController(IUnitOfWork unitOfWork,IMapper mapper,DataContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;   
            _context = context; 
        }
        [HttpGet]
        public async Task<List<CategoryGetDTO>> GetAll()
        {
            var result = await _unitOfWork.CategoryRepository.GetAllAsync(x => !x.IsDelete);
            List<CategoryGetDTO> categoryies = _mapper.Map<List<CategoryGetDTO>>(result);
            return  categoryies; 

            
        }
    }
}
