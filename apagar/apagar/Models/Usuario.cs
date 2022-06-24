using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apagar.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Column("id")]
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Column("nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Column("email")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Column("senha")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
        [Column("cpf")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }
    }
}
