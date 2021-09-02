using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

using Domain.Interfaces;
using Domain.Models;

namespace Service.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AccountsController> _logger;

        public AccountsController(
            IUnitOfWork unitOfWork,
            ILogger<AccountsController> logger
        )
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var accounts = _unitOfWork.Accounts
                    .Get()
                    .Include(a => a.Owner);

                return Ok(accounts);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Account account = _unitOfWork.Accounts
                .Find(a => a.Id.Equals(id))
                .Include(a => a.Owner)
                .FirstOrDefault();

            return Ok(account);
        }

    }
}
