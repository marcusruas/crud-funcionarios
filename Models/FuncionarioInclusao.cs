using System;
using System.ComponentModel.DataAnnotations;

namespace Funcionarios.Models
{
    public class FuncionarioInclusao
    {
        [Required(ErrorMessage = "Nome obrigatório")]
        [StringLength(100, MinimumLength = 3)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Email obrigatório")]
        [StringLength(100, MinimumLength = 2)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Data de Nascimento obrigatória")]
        public DateTime DataNascimento { get; set; }
        public string Salario { get; set; }
        public string Estado { get; set; }
    }
}