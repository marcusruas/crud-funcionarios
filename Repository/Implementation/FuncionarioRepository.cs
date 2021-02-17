using Dapper;
using Funcionarios.Models;
using Funcionarios.Repository.Helpers;
using Funcionarios.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Funcionarios.Repository.Implementation
{
    public class FuncionarioRepository : ConnectionCreator, IFuncionarioRepository
    {
        public FuncionarioRepository() : base("Funcionario")
        {
        }

        public IEnumerable<FuncionarioSimplificado> ListarFuncionarios()
        {
            List<FuncionarioSimplificado> funcionarios;
            
            using (var connection = CriarNovaConexao("Empresa"))
            {
                string comando = ObterConteudoArquivoSQL("selectFuncionariosSimplificado");
                funcionarios = connection.Query<FuncionarioSimplificado>(comando).ToList();
            }

            return funcionarios;
        }
    }
}