﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using MP.WebApi.Models;
using MP.WebApi.Models.Responses;

namespace TM.DotNet.Controllers
{
	
	[ApiController]
	public abstract class BaseApiController : ControllerBase
	{
		protected ILogger Logger { get; set; }
		public BaseApiController(ILogger logger)
		{
			logger.LogInformation($"Controller Firing {this.GetType().Name} ");
			Logger = logger;
		}

		protected OkObjectResult Ok200(BaseResponse response)
		{

			return base.Ok(response);
		}

		protected CreatedResult Created201(IItemResponse response)
		{
			string url = Request.Path + "/" + response.Item.ToString();

			return base.Created(url, response);
		}

		protected NotFoundObjectResult NotFound404(BaseResponse response)
		{
			return base.NotFound(response);
		}

		protected ObjectResult CustomResponse(HttpStatusCode code, BaseResponse response)
		{
			return StatusCode((int)code, response);
		}
	}
}
