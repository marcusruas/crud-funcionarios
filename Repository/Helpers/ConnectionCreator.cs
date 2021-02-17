using Funcionarios.Repository.Helpers.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Funcionarios.Repository.Helpers
{
    public class ConnectionCreator
    {
        private string RepositoryLocation;
        private string LocalizacaoArquivosSQL;

        public ConnectionCreator(string localizacaoArquivosSQL)
        {
            RepositoryLocation = $"{AppDomain.CurrentDomain.BaseDirectory}Repository\\";
            LocalizacaoArquivosSQL = localizacaoArquivosSQL;
        }

        public SqlConnection CriarNovaConexao(string nomeBanco)
        {
            List<Conexao> conexoes;
            string conexoesLocation = $"{RepositoryLocation}conexoes.json";
            try
            {
                using (StreamReader sr = new StreamReader(conexoesLocation))
                    conexoes = JsonConvert.DeserializeObject<List<Conexao>>(sr.ReadToEnd());
            }
            catch(Exception ex)
            {
                string template = $"Não foi possível localizar/ler o arquivo 'Conexoes.json' no caminho {conexoesLocation}.";
                throw new Exception(template, ex);
            }

            Conexao conexaoSelecionada = conexoes.FirstOrDefault(cn => cn.Nome == nomeBanco);
            if (conexaoSelecionada == null) 
                throw new Exception($"Não foi possível localizar uma connectionString de nome {nomeBanco}");

            string connectionString = conexaoSelecionada.ConnectionString;
            return new SqlConnection(connectionString);
        }

        public string ObterConteudoArquivoSQL(string nomeArquivo)
        {
            string localizacaoArquivo = $"{RepositoryLocation}SQL\\{LocalizacaoArquivosSQL}\\{nomeArquivo}.sql";

            string conteudoArquivo;
            using (StreamReader sr = new StreamReader(localizacaoArquivo))
                conteudoArquivo = sr.ReadToEnd();

            return conteudoArquivo;
        }
    }
}