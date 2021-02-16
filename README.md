
# Dapper.Custom.Extentions ![.NET](https://github.com/thiagobrito91/Dapper.Custom.Extensions/workflows/.NET/badge.svg)



O **Dapper.Custom.Extentions** é um pacote de extensão complementar para o [**Dapper.SqlBuilder**](https://www.nuget.org/packages/Dapper.SqlBuilder/), que visa facilitar na criação de filtros e parâmetros de update dinâmicos diminuindo a quantidade de IFs nos filtros.

Conforme descrito abaixo é possível ver a existência de um terceiro parâmetro boleano, que indica que
caso a condição for verdadeira o filtro em questão será aplicado.

**Where**
_sqlBuilder.Where("Id = @Id", pessoa.Id, **pessoa.Id.GreaterThanZero()**);

**Set**
_sqlBuilder.Set("Nome = @Nome", pessoa.Nome, **pessoa.Nome.IsNotNullOrEmpty()**);

# Exemplo 

    public class PessoaQuery
    {
        private readonly SqlBuilder _sqlBuilder;private string SQL_SELECT = @"SELECT * FROM dbo.Pessoa /**where**/";
        private string SQL_UPDATE = @"UPDATE dbo.Pessoa /**set**/ /**where**/";

        public PessoaQuery()
        {
            _sqlBuilder = new SqlBuilder();
        }
        
        public IEnumerable<Pessoa> Obter(Pessoa pessoa)
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

        public void Update(Pessoa pessoa)
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
