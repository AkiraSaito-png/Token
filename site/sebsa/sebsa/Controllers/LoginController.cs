using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Security.Claims;

namespace sebsa.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Json(new { Msg = "Usuario logado!" });
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logar(string email, string senha)
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection("Host=sebsa.covoattbbrhu.sa-east-1.rds.amazonaws.com;Port=5432;Database=sebsa;User Id=postgres;Password=12345678");
            await sqlConnection.OpenAsync();

            NpgsqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"SELECT * FROM usuario WHERE email = '{email}' AND senha = '{senha}'";

            NpgsqlDataReader reader = sqlCommand.ExecuteReader();

            
                if (await reader.ReadAsync())
                {
                    int id = reader.GetInt32(0);
                    string nome = reader.GetString(1);

                    List<Claim> acessoUsuario = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                        new Claim(ClaimTypes.Name, nome)
                    };

                    var identidade = new ClaimsIdentity(acessoUsuario, "Identity.Login");
                    var userPrincipal = new ClaimsPrincipal(new[] { identidade });

                    await HttpContext.SignInAsync(userPrincipal,
                        new AuthenticationProperties
                        {
                            IsPersistent = false,
                            ExpiresUtc = DateTime.Now.AddMinutes(15)
                        });

                    return RedirectToAction("Index", "ValidationLogin");
                }
                else
                {
                    return Json(new { Msg = "Usuario ou senha incorretos! Verifique suas credenciais!" });
                }
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
            }
            return RedirectToAction("Index","Login");
        }
    }
}
