using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Domain.Interfaces;
using Domain.Models;

namespace Service.Controllers
{
    [ApiController]
    [Route("api/owners")]
    public class OwnersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<OwnersController> _logger;

        public OwnersController(
            IUnitOfWork unitOfWork,
            ILogger<OwnersController> logger
        )
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Owner> owners = await _unitOfWork
                    .Owners.Get()
                    .Include(o => o.Accounts)
                    .ToListAsync();

                return Ok(owners);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            Owner owner = await _unitOfWork.Owners
                .Find(owner => owner.Id.Equals(id))
                .Include(o => o.Accounts)
                .FirstOrDefaultAsync();

            if (owner == null)
            {
                _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            return Ok(owner);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Owner entity)
        {
            try
            {
                if (entity == null)
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                //var ownerEntity = _mapper.Map<Owner>(owner);
                _unitOfWork.Owners.Add(entity);
                await _unitOfWork.SaveAsync();

                //var createdOwner = _mapper.Map<OwnerDto>(ownerEntity);
                return CreatedAtRoute("Get", new { id = entity.Id }, entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Owner entity)
        {
            try
            {
                if (entity == null)
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var owner = await _unitOfWork.Owners.GetAsync(id);
                if (owner == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                owner.FirstName = entity.FirstName;
                owner.LastName = entity.LastName;
                owner.Street = entity.Street;
                owner.City= entity.City;
                owner.PostalCode = entity.PostalCode;
                owner.RegionCode = entity.RegionCode;

                //_mapper.Map(owner, ownerEntity);

                _unitOfWork.Owners.Update(owner);

                await _unitOfWork.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var owner = await _unitOfWork.Owners.GetAsync(id);
                if (owner == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                //if (_unitOfWork.Accounts.AccountsByOwner(id).Any())
                //{
                //    _logger.LogError($"Cannot delete owner with id: {id}. It has related accounts. Delete those accounts first");
                //    return BadRequest("Cannot delete owner. It has related accounts. Delete those accounts first");
                //}

                _unitOfWork.Owners.Remove(owner);

                await _unitOfWork.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
