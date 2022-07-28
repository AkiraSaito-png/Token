using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using sebsa.Models;

namespace sebsa.Controllers
{
    public class ValidationLoginController : Controller
    {
        // GET: ValidationLoginController
        public ActionResult Index()
        {
            return View();
        }

        public int ValidarId(int id)
        {
            return id = 2;            
        }

        [HttpPost]
        public async Task<IActionResult> Validar(string code, ValidationLogin login, int id)
        {
            int id_usu = ValidarId(id);

            NpgsqlConnection sqlConnection = new NpgsqlConnection("Host=sebsa.covoattbbrhu.sa-east-1.rds.amazonaws.com;Port=5432;Database=sebsa;User Id=postgres;Password=12345678");
            await sqlConnection.OpenAsync();

            var commandText = $@"UPDATE code SET code = @code WHERE id_usuario = @id";
            await using (var cmd = new NpgsqlCommand(commandText, sqlConnection))
            {
                cmd.Parameters.AddWithValue("id", id_usu);
                cmd.Parameters.AddWithValue("code", login.code);

                await cmd.ExecuteNonQueryAsync();
            }

            return View();
        }
    }
}
