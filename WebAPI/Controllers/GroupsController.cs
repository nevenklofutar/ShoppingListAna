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
    [Route("api/groups")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _unitOfWork.Groups.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _unitOfWork.Groups.GetByIdAsync(id);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpGet("{id}/items")]
        public async Task<IActionResult> GetItemsByGroupId(int id)
        {
            var data = await _unitOfWork.Items.GetItemsByGroupIdAsync(id);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Group group)
        {
            var data = await _unitOfWork.Groups.AddAsync(group);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _unitOfWork.Groups.DeleteAsync(id);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Group group)
        {
            var data = await _unitOfWork.Groups.UpdateAsync(group);
            return Ok(data);
        }
    }
}
