using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApi.Models;
using System.Data.SqlClient;
namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public userController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("get_all_user")]

        public Response GetAllUser()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetAllUser(connection);
            return response;
        }

        [HttpPost]
        [Route("add_user")]
        public Response AddUser(userModel user) {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.AddUser(connection, user);
            return response;
        }
        [HttpGet]
        [Route("get_user_by_id/{id}")]
        public Response GetUserById(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetUserById(connection,id);
            return response;
        }

        [HttpDelete]
        [Route("user_delete/{id}")]
        public Response UserDelete(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.UserDelete(connection, id);
            return response;
        }

        [HttpPut]
        [Route("user_update")]
        public Response UserUpdate(userModel user)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.UserUpdate(connection, user);
            return response;
        }
        [HttpPost]
        [Route("user_login")]
        public Response UserLogin(userModel user)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.UserLogin(connection, user);
            return response;
        }
    }

}
