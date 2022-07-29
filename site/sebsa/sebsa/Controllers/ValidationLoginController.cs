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

            int i = 0;

            while (i == 0)
            {
                string status = $"SELECT * FROM code WHERE code = @code AND status = 'y'";
                await using (var cmd = new NpgsqlCommand(status, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("code", login.code);

                    await using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
                        if (await reader.ReadAsync())
                        {
                            i = 1;
                        }
                        else
                        {
                            i = 0;
                        }
                }
            }
            string travar = $@"UPDATE code SET status = 'n' WHERE code = @code";
            await using (var cmdd = new NpgsqlCommand(travar, sqlConnection))
            {
                cmdd.Parameters.AddWithValue("code", login.code);

                await cmdd.ExecuteNonQueryAsync();
            }

            return RedirectToAction("Index", "Home");

        }
    }
}
