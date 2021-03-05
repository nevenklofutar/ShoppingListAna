using Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var data = await _unitOfWork.Items.GetAllAsync();
        //    return Ok(data);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _unitOfWork.Items.GetByIdAsync(id);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Item item)
        {
            var data = await _unitOfWork.Items.AddAsync(item);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _unitOfWork.Items.DeleteAsync(id);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Item item)
        {
            var data = await _unitOfWork.Items.UpdateAsync(item);
            return Ok(data);
        }
    }
}
