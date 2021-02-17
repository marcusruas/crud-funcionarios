using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Funcionarios.Models
{
    public class DadosFuncionarioViewModel
    {
        public List<Estado> Estados { get; set; }
        public FuncionarioInclusao Funcionario { get; set; }
    }
}