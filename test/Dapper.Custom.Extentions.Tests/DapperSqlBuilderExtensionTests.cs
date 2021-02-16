using Dapper.Custom.Extentions.Lib;
using FluentAssertions;
using System;
using Xunit;
using static Dapper.SqlBuilder;

namespace Dapper.Custom.Extentions.Tests
{
    public class DapperSqlBuilderExtensionTests
    {
        private readonly SqlBuilder _sqlBuilder;
        private readonly Template _templateSelect;
        private readonly Template _templateUpdate;

        public DapperSqlBuilderExtensionTests()
        {
            var sqlSelect = @"SELECT * FROM #TABLE /**where**/";
            var sqlUpdate = @"UPDATE #TABLE /**set**/ /**where**/";

            _sqlBuilder = new SqlBuilder();

            _templateSelect = _sqlBuilder.AddTemplate(sqlSelect);
            _templateUpdate = _sqlBuilder.AddTemplate(sqlUpdate);
        }

        [Fact]
        public void DapperSqlBuilderExtension_Where_Deve_LancarException_QuandoNaoHouverArroba()
        {
            //Arrange
            var filter = 123;

            //Act
            Action act = () => _sqlBuilder.Where("COLUNA1 = Coluna1", filter, filter.GreaterThanZero());

            //Assert
            act.Should().Throw<Exception>().WithMessage("Must contain @ in the clause!");
        }

        [Fact]
        public void DapperSqlBuilderExtension_Where_Deve_LancarException_QuandoHouverMaisDeUmArroba()
        {
            //Arrange
            var filter = 123;

            //Act
            Action act = () => _sqlBuilder.Where("COLUNA1 = @@Coluna1", filter, filter.GreaterThanZero());

            //Assert
            act.Should().Throw<Exception>().WithMessage("Must contain a single @ in the clause!");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DapperSqlBuilderExtension_Where_Deve_LancarException_QuandoClausulaEstiverNulaOuVazia(string clause)
        {
            //Arrange
            var filter = 123;

            //Act
            Action act = () => _sqlBuilder.Where(clause, filter, filter.GreaterThanZero());

            //Assert
            act.Should().Throw<Exception>().WithMessage("The clause can't be null or empty!");
        }

        [Fact]
        public void DapperSqlBuilderExtension_Where_DeveGerarSqlComSucesso()
        {
            //Arrange
            var filter = 123;
            var where = "COLUNA1 = @Coluna1";

            //Act
            _sqlBuilder.Where(where, filter, filter.GreaterThanZero());

            //Assert
            _templateSelect.RawSql.Should().Contain(where);
        }

        [Fact]
        public void DapperSqlBuilderExtension_Set_Deve_LancarException_QuandoNaoHouverArroba()
        {
            //Arrange
            var filter = 123;

            //Act
            Action act = () => _sqlBuilder.Set("COLUNA1 = Coluna1", filter, filter.GreaterThanZero());

            //Assert
            act.Should().Throw<Exception>().WithMessage("Must contain @ in the clause!");
        }

        [Fact]
        public void DapperSqlBuilderExtension_Set_Deve_LancarException_QuandoHouverMaisDeUmArroba()
        {
            //Arrange
            var filter = 123;

            //Act
            Action act = () => _sqlBuilder.Set("COLUNA1 = @@Coluna1", filter, filter.GreaterThanZero());

            //Assert
            act.Should().Throw<Exception>().WithMessage("Must contain a single @ in the clause!");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DapperSqlBuilderExtension_Set_Deve_LancarException_QuandoClausulaEstiverNulaOuVazia(string clause)
        {
            //Arrange
            var filter = 123;

            //Act
            Action act = () => _sqlBuilder.Set(clause, filter, filter.GreaterThanZero());

            //Assert
            act.Should().Throw<Exception>().WithMessage("The clause can't be null or empty!");
        }

        [Fact]
        public void DapperSqlBuilderExtension_Set_DeveGerarSqlComSucesso()
        {
            //Arrange
            var filter = 123;
            var set = "COLUNA1 = @Coluna1";
            var where = "COLUNA0 = @Coluna0";

            //Act
            _sqlBuilder.Set(set, filter, filter.GreaterThanZero());
            _sqlBuilder.Where(where, filter, filter.GreaterThanZero());

            //Assert
            _templateSelect.RawSql.Should().Contain(where);
        }
    }

}
