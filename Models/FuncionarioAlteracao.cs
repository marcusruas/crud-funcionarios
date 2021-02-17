using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Funcionarios.Models
{
    public class FuncionarioAlteracao
    {
        public int Codigo { get; set; }
        [Required(ErrorMessage = "Nome obrigatório")]
        [StringLength(100, MinimumLength = 3)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Email obrigatório")]
        [StringLength(100, MinimumLength = 2)]
        public string Email { get; set; }
        [DataType(DataType.Date), Required(ErrorMessage = "Data de Nascimento obrigatória")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }
        public string Salario { get; set; }
        public string Estado { get; set; }

        public string FormatarDataNascimento()
        {
            var retorno = DataNascimento.ToString("yyyy-MM-dd");
            return retorno;
        }

        public string PossuiEstado(int estado)
        {
            return !string.IsNullOrEmpty(Estado) ? Estado == estado.ToString() ? "selected" : "" : "";
        }
    }
}