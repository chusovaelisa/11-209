using PokemonAPI.Controllers;
namespace PockemonAPI.IntegrationsTests
{
    [TestClass]
    public class PockemonControllerTests
    {
        private PokemonController _controller;

        public void Initialize()
        {
            _controller = new PokemonController();
        }

        [TestMethod]
        public void GetAll_WhereQueryIsNull_ReturntData()
        {
            //Arrange
            //Act
            //Assert
        }
    }
}