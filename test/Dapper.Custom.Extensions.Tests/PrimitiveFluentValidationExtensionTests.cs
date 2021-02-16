using Dapper.Custom.Extensions.Lib;
using Xunit;

namespace Dapper.Custom.Extensions.Tests
{
    public class PrimitiveFluentValidationExtensionTests
    {

        #region INT

        [Fact]
        public void INT_Deve_Retornar_True_Caso_Seja_Maior_Que_Zero()
        {
            //Arrange
            var value = 1;

            //Act
            var result = value.GreaterThanZero();

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void INT_Deve_Retornar_False_Caso_Seja_Menor_Que_Zero()
        {
            //Arrange
            var value = -1;

            //Act
            var result = value.GreaterThanZero();

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void INT_Deve_Retornar_True_Caso_Valor_Seja_Maior_Que_Parametro()
        {
            //Arrange
            var value = 1;

            //Act
            var result = value.GreaterThan(0);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void INT_Deve_Retornar_False_Caso_Valor_Seja_Menor_Que_Parametro()
        {
            //Arrange
            var value = 0;

            //Act
            var result = value.GreaterThan(1);

            //Assert
            Assert.False(result);
        }

        #endregion

        #region DOUBLE

        [Fact]
        public void DOUBLE_Deve_Retornar_True_Caso_Seja_Maior_Que_Zero()
        {
            //Arrange
            double value = 1;

            //Act
            var result = value.GreaterThanZero();

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void DOUBLE_Deve_Retornar_False_Caso_Seja_Menor_Que_Zero()
        {
            //Arrange
            double value = -1;

            //Act
            var result = value.GreaterThanZero();

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void DOUBLE_Deve_Retornar_True_Caso_Valor_Seja_Maior_Que_Parametro()
        {
            //Arrange
            var value = 1;

            //Act
            var result = value.GreaterThan(0);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void DOUBLE_Deve_Retornar_False_Caso_Valor_Seja_Menor_Que_Parametro()
        {
            //Arrange
            var value = 0;

            //Act
            var result = value.GreaterThan(1);

            //Assert
            Assert.False(result);
        }

        #endregion

        #region DECIMAL

        [Fact]
        public void DECIMAL_Deve_Retornar_True_Caso_Seja_Maior_Que_Zero()
        {
            //Arrange
            double value = 1;

            //Act
            var result = value.GreaterThanZero();

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void DECIMAL_Deve_Retornar_False_Caso_Seja_Menor_Que_Zero()
        {
            //Arrange
            double value = -1;

            //Act
            var result = value.GreaterThanZero();

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void DECIMAL_Deve_Retornar_True_Caso_Valor_Seja_Maior_Que_Parametro()
        {
            //Arrange
            var value = 1;

            //Act
            var result = value.GreaterThan(0);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void DECIMAL_Deve_Retornar_False_Caso_Valor_Seja_Menor_Que_Parametro()
        {
            //Arrange
            var value = 0;

            //Act
            var result = value.GreaterThan(1);

            //Assert
            Assert.False(result);
        }

        #endregion

        #region STRING

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void STRING_Deve_Retornar_True_Se_String_For_Nula(string value)
        {
            //Act
            var result = value.IsNullOrEmpty();

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void STRING_Deve_Retornar_False_Se_String_Nao_For_Nula()
        {
            //Arrange
            var value = "value";

            //Act
            var result = value.IsNullOrEmpty();

            //Assert
            Assert.False(result);
        }


        [Fact]
        public void STRING_Deve_Retornar_True_Se_String_Nao_For_Nula()
        {
            //Arrange
            var value = "value";

            //Act
            var result = value.IsNotNullOrEmpty();

            //Assert
            Assert.True(result);
        }

        #endregion

        #region OBJECT

        [Fact]
        public void OBJECT_Deve_Retornar_True_Se_Objeto_Nulo()
        {
            //Arrange
            Objeto objeto = null;

            //Act
            var result = objeto.IsNull();

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void OBJECT_Deve_Retornar_False_Se_Objeto_Nao_For_Nulo()
        {
            //Arrange
            Objeto objeto = new Objeto { };

            //Act
            var result = objeto.IsNull();

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void OBJECT_Deve_Retornar_True_Se_Objeto_Nao_For_Nulo()
        {
            //Arrange
            Objeto objeto = new Objeto { };

            //Act
            var result = objeto.IsNotNull();

            //Assert
            Assert.True(result);
        }
        [Fact]
        public void OBJECT_Deve_Retornar_False_Se_Objeto_For_Nulo()
        {
            //Arrange
            Objeto objeto = null;

            //Act
            var result = objeto.IsNotNull();

            //Assert
            Assert.False(result);
        }

        #endregion

    }

}
