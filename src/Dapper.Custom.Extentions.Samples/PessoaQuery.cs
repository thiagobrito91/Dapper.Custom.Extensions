using Dapper.Custom.Extentions.Lib;
using System.Collections.Generic;
using System.Data.SqlClient;
using static Dapper.SqlBuilder;

namespace Dapper.Custom.Extentions.Samples
{
    public class PessoaQuery
    {
        private readonly SqlBuilder _sqlBuilder;

        private string SQL_SELECT = @"SELECT * FROM dbo.Pessoa /**where**/";
        private string SQL_UPDATE = @"UPDATE dbo.Pessoa /**set**/ /**where**/";

        public PessoaQuery()
        {
            _sqlBuilder = new SqlBuilder();
        }

        public IEnumerable<Pessoa> ObterPessoas_SemExtension(Pessoa pessoa)
        {
            Template template = _sqlBuilder.AddTemplate(SQL_SELECT);

            //Filters
            if (pessoa.Id > 0)
            {
                _sqlBuilder.Where("Id = @Id", pessoa.Id);
            }

            if (!string.IsNullOrEmpty(pessoa.Nome))
            {
                _sqlBuilder.Where("Nome = @Nome", pessoa.Nome);
            }

            if (!string.IsNullOrEmpty(pessoa.Sobrenome))
            {
                _sqlBuilder.Where("Sobrenome = @Sobrenome", pessoa.Sobrenome);
            }

            if (pessoa.Idade > 0)
            {
                _sqlBuilder.Where("Idade = @Idade", pessoa.Idade);
            }

            if (pessoa.Altura > 0)
            {
                _sqlBuilder.Where("Altura = @Altura", pessoa.Altura);
            }

            //Query
            using (var conn = new SqlConnection("ConnectioString"))
            {
                var results = conn.Query<Pessoa>(template.RawSql, template.Parameters);

                return results;
            }
        }

        public IEnumerable<Pessoa> ObterPessoas_ComExtension(Pessoa pessoa)
        {
            Template template = _sqlBuilder.AddTemplate(SQL_SELECT);

            //Filters

            if (pessoa.IsNull())
                return null;

            _sqlBuilder.Where("Id = @Id", pessoa.Id, pessoa.Id.GreaterThanZero());
            _sqlBuilder.Where("Nome = @Nome", pessoa.Nome, pessoa.Nome.IsNotNullOrEmpty());
            _sqlBuilder.Where("Sobrenome = @Sobrenome", pessoa.Sobrenome, pessoa.Sobrenome.IsNotNullOrEmpty());
            _sqlBuilder.Where("Idade = @Idade", pessoa.Idade, pessoa.Idade.GreaterThanZero());
            _sqlBuilder.Where("Altura = @Altura", pessoa.Altura, pessoa.Altura.GreaterThanZero());

            //Query
            using (var conn = new SqlConnection("ConnectioString"))
            {
                return conn.Query<Pessoa>(template.RawSql, template.Parameters);
            }
        }

        public void UpdatePessoa_SemExtension(Pessoa pessoa)
        {
            Template template = _sqlBuilder.AddTemplate(SQL_UPDATE);

            //Filters

            if (pessoa.IsNull())
                return;

            //Set           
            if (!string.IsNullOrEmpty(pessoa.Nome))
            {
                _sqlBuilder.Set("Nome = @Nome", pessoa.Nome);
            }

            if (!string.IsNullOrEmpty(pessoa.Sobrenome))
            {
                _sqlBuilder.Set("Sobrenome = @Sobrenome", pessoa.Sobrenome);
            }

            if (pessoa.Idade > 0)
            {
                _sqlBuilder.Set("Idade = @Idade", pessoa.Idade);
            }

            if (pessoa.Altura > 0)
            {
                _sqlBuilder.Set("Altura = @Altura", pessoa.Altura);
            }

            //Where
            _sqlBuilder.Where("Id = @Id", pessoa.Id);

            //Query
            using (var conn = new SqlConnection("ConnectioString"))
            {
                conn.Execute(template.RawSql, template.Parameters);
            }
        }

        public void UpdatePessoa_ComExtension(Pessoa pessoa)
        {
            Template template = _sqlBuilder.AddTemplate(SQL_UPDATE);

            //Filters

            if (pessoa.IsNull())
                return;

            //Set
            _sqlBuilder.Set("Nome = @Nome", pessoa.Nome, pessoa.Nome.IsNotNullOrEmpty());
            _sqlBuilder.Set("Sobrenome = @Sobrenome", pessoa.Sobrenome, pessoa.Sobrenome.IsNotNullOrEmpty());
            _sqlBuilder.Set("Idade = @Idade", pessoa.Idade, pessoa.Idade.GreaterThanZero());
            _sqlBuilder.Set("Altura = @Altura", pessoa.Altura, pessoa.Altura.GreaterThanZero());

            //Where
            _sqlBuilder.Where("Id = @Id", pessoa.Id);

            //Query
            using (var conn = new SqlConnection("ConnectioString"))
            {
                conn.Execute(template.RawSql, template.Parameters);
            }
        }
    }
}
