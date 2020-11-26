// Por Yerko Orellana Abello para prueba en Agilesoft

using Agilesoft_test.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Agilesoft_test.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Context BD MySQL
        private agilesoft_testContext context;
        public UserController(agilesoft_testContext _context)
        {
            context = _context;
        }

        // INGRESO
        // GET api/user/login
        [HttpGet("login")]
        public ActionResult<User> Get(User user)
        {
            // Encriptamos la contrasñea para comparar en BD
            user.Pass = MD5Encrypter(user.Pass);
            User userFinded = context.User.Where(u => u.Username == user.Username && u.Pass == user.Pass).FirstOrDefault();

            if (userFinded == null)
                return BadRequest();
            else
            {
                // Borramos la contraseña para devolver los datos del user
                userFinded.Pass = string.Empty;
                return userFinded;
            }                
        }

        // REGISTRO
        // POST api/user/register
        [HttpPost("register")]
        public ActionResult<User> Post(User user)
        {
            // ¿Existe el username?
            User userFinded = context.User.Where(u => u.Username == user.Username).FirstOrDefault();
            if(userFinded != null)
                return BadRequest();

            // Encriptamos la contraseña para guardar el user
            user.Pass = MD5Encrypter(user.Pass);
            context.User.Add(user);
            context.SaveChanges();

            // Borramos la contraseña para devolver los datos del user
            user.Pass = string.Empty;
            return user;
        }

        private string MD5Encrypter(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.UTF8.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }
    }
}