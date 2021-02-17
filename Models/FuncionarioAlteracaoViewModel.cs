using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Funcionarios.Models
{
    public class FuncionarioAlteracaoViewModel
    {
        public List<Estado> Estados { get; set; }
        public FuncionarioAlteracao Funcionario { get; set; }
    }
}