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

        public bool CadastrarFuncionario(FuncionarioInclusao funcionario)
        {
            using (var connection = CriarNovaConexao("Empresa"))
            {
                string comando = ObterConteudoArquivoSQL("insertFuncionario");
                return connection.Execute(comando, funcionario) == 1;
            }
        }

        public bool ExcluirFuncionario(int funcionario)
        {
            using (var connection = CriarNovaConexao("Empresa"))
            {
                string comando = ObterConteudoArquivoSQL("deleteFuncionario");
                return connection.Execute(comando, new { funcionario }) == 1;
            }
        }

        public IEnumerable<Estado> ListarEstados()
        {
            List<Estado> estados;

            using (var connection = CriarNovaConexao("Empresa"))
            {
                string comando = ObterConteudoArquivoSQL("selectEstados");
                estados = connection.Query<Estado>(comando).ToList();
            }

            return estados;
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