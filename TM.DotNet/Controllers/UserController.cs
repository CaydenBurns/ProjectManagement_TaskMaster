using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MP.WebApi.Models.Responses;
using TM.DotNet.Entities;
using TM.DotNet.Entities.Tables;
using TM.DotNet.Interfaces;

namespace TM.DotNet.Controllers
{
	[Route("api/users")]
	[ApiController]
	public class UserController : BaseApiController
	{
		private IUserService _userService;
		private readonly TmDbContext _dbContext;

		public UserController(IUserService service, TmDbContext dbContext, ILogger<UserController> logger): base(logger)
		{
			_userService = service;
			_dbContext = dbContext;

			
		}

		[HttpGet]
		public IActionResult GetUsers()
		{
			BaseResponse response = null;
			int code = 201;

			try
			{
				List<User> users = _userService.GetAllUsers();
				response = new ItemsResponse<User> { Items = users };

				if (users == null)
				{
					code = 404;
					response = new ErrorResponse("App resource not found");
				}
				else
				{
					response = new ItemsResponse<User> { Items = users };
				}

			}
			catch (Exception e)
			{
				Logger.LogDebug(e.Message);
				throw;
			}
			return StatusCode(code, response);
		}
		
		
	}
}
