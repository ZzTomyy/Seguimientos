using Microsoft.AspNetCore.Mvc;
using Seguimientos.Models;
using System.Text;
using System.Security.Cryptography;

namespace Seguimientos.Controllers
{
    public class PasswordController : Controller
    {
        public IActionResult Index()
        {
            
            var model = new Password
            {
                Length = 12,
                IncludeUppercase = true,
                IncludeNumbers = true,
                IncludeSymbols = true
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Generate(Password model)
        {
            
            if (model.Length <= 0) model.Length = 12;
            if (model.Length > 128) model.Length = 128;

           
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            const string symbols = "!@#$%^&*()-_=+[]{};:,.<>?/";

            var poolBuilder = new StringBuilder();
            
            poolBuilder.Append(lower);

            if (model.IncludeUppercase) poolBuilder.Append(upper);
            if (model.IncludeNumbers) poolBuilder.Append(numbers);
            if (model.IncludeSymbols) poolBuilder.Append(symbols);

            var pool = poolBuilder.ToString();

            
            if (string.IsNullOrEmpty(pool))
                pool = lower;

            
            var sb = new StringBuilder(model.Length);
            for (int i = 0; i < model.Length; i++)
            {
                int idx = RandomNumberGenerator.GetInt32(pool.Length); 
                sb.Append(pool[idx]);
            }

            model.GeneratedPassword = sb.ToString();
            return View("Index", model);
        }
    }
}

