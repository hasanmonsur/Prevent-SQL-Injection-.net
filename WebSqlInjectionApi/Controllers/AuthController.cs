using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSqlInjectionApi.Contacts;
using WebSqlInjectionApi.Helpers;
using WebSqlInjectionApi.Models;

namespace WebSqlInjectionApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<AuthController> _logger;
        private readonly IMaskService _maskService;

        private readonly IUserSqlService _userSqlService;

        private readonly IUserDapperService _userDapperService;

        public AuthController(ILogger<AuthController> logger, IMaskService maskService, IUserSqlService userSqlService, IUserDapperService userDapperService)
        {
            _logger = logger;
            _maskService = maskService;
            _userSqlService = userSqlService;
            _userDapperService= userDapperService;
        }

        [HttpGet]
        public IActionResult GetSqlUserInfo(int id)
        {
            var model = new User();

            model = _userSqlService.GetUserById(id);


            // Log user input exclude sensitive data
            _logger.LogInformationWithoutSensitiveData("Received input from user: {@UserInput}", model);

            // Log user input without sensitive data
            _logger.LogInformation("Received input from user: {@UserInput}", model);

            //// Avoid logging sensitive data
            //if (model.Password != null)
            //{
            //    _logger.LogWarning("Password provided for user: {UserEmail}", model.Email);
            //    // Do not log the actual password
            //}

            // Mask logging sensitive data
            if (model.Email != null)
            {
                var vemail = _maskService.MaskEmail(model.Email);
                _logger.LogWarning("Mask Email provided for user: {UserEmail}", vemail);
                // Do not log the actual Email
            }

            return Ok(model);
        }

        [HttpGet]
        public IActionResult GetDapperUserInfo(int id)
        {
            var model = new User();
            model = _userDapperService.GetUserById(id);



            // Log user input exclude sensitive data
            _logger.LogInformationWithoutSensitiveData("Received input from user: {@UserInput}", model);

            // Log user input without sensitive data
            _logger.LogInformation("Received input from user: {@UserInput}", model);

            //// Avoid logging sensitive data
            //if (model.Password != null)
            //{
            //    _logger.LogWarning("Password provided for user: {UserEmail}", model.Email);
            //    // Do not log the actual password
            //}

            // Mask logging sensitive data
            if (model.Email != null)
            {
                var vemail = _maskService.MaskEmail(model.Email);
                _logger.LogWarning("Mask Email provided for user: {UserEmail}", vemail);
                // Do not log the actual Email
            }

            return Ok(model);
        }

    }
}
