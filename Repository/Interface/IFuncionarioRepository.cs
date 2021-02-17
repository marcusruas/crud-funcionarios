using Funcionarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionarios.Repository.Interface
{
    public interface IFuncionarioRepository
    {
        bool CadastrarFuncionario(FuncionarioInclusao funcionario);
        IEnumerable<FuncionarioSimplificado> ListarFuncionarios();
        IEnumerable<Estado> ListarEstados();
    }
}
