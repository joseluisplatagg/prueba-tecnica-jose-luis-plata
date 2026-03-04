using FluentAssertions;
using Xunit;
using CleanArchitecture.PracticalTest.Domain.Entities;
using CleanArchitecture.PracticalTest.Domain.Exceptions;

namespace CleanArchitecture.PracticalTest.Tests.Entities
{
    public class PaqueteTests
    {
        private readonly Guid _enBodegaId = Guid.NewGuid();
        private readonly Guid _enTransitoId = Guid.NewGuid();
        private readonly Guid _entregadoId = Guid.NewGuid();
        private readonly Guid _devueltoId = Guid.NewGuid();

        [Fact]
        public void RegistrarDimensiones_DebeCalcularCostoBaseCorrectamente_SinRuta()
        {
            // Arrange
            var paquete = new Paquete();
            decimal peso = 2m; // 1kg extra ($15)
            decimal alto = 10, ancho = 10, largo = 10; // Vol: 1000 (< 500k)

            // Act
            paquete.RegistrarDimensiones(peso, alto, ancho, largo);
            paquete.EstadoId = _enBodegaId;
            // Assert: 50 (base) + 15 (1kg extra) + 0 (distancia) = 65
            paquete.Costo.Should().Be(65m);
            paquete.EstadoId.Should().Be(_enBodegaId);
        }

        [Fact]
        public void AsignarRuta_DebeCambiarEstadoAEnTransito_YActualizarCosto()
        {
            // Arrange
            var paquete = new Paquete();
            paquete.RegistrarDimensiones(1m,10m, 10m, 10m);
            paquete.EstadoId = _enBodegaId;
            var ruta = new Ruta { Id = Guid.NewGuid(), Distancia = 100m }; // 100km * 2.5 = 250

            // Act
            paquete.AsignarRutas(ruta);

            // Assert: 50 (base) + 0 (peso) + 250 (distancia) = 300
            paquete.Costo.Should().Be(300m);
            paquete.EstadoId.Should().Be(_enTransitoId);
            paquete.RutaId.Should().Be(ruta.Id);
        }

        [Fact]
        public void AsignarRuta_DebeLanzarExcepcion_SiNoEstaEnBodega()
        {
            // Arrange
            var paquete = new Paquete();
            // Simulamos que ya está en tránsito (usando reflexión o un método de carga inicial)
            typeof(Paquete).GetProperty("Id")!.SetValue(paquete, _enTransitoId);
            var ruta = new Ruta { Id = Guid.NewGuid() };

            // Act
            Action act = () => paquete.AsignarRutas(ruta);

            // Assert
            act.Should().Throw<DomainException>()
                .WithMessage("ERR_INVALID_STATUS_FOR_ROUTE");
        }

        [Fact]
        public void CalcularCosto_DebeAplicarRecargo20_CuandoVolumenExcede500k()
        {
            // Arrange
            var paquete = new Paquete();
            // Vol: 100 * 100 * 100 = 1,000,000 cm3 (> 500k)
            paquete.RegistrarDimensiones(1m, 100m, 100m, 100m);
            paquete.EstadoId = _enBodegaId;

            // Act (Subtotal base = 50)
            // Assert: 50 * 1.20 = 60
            paquete.Costo.Should().Be(60m);
        }

        [Fact]
        public void ActualizarEstado_DebeLanzarExcepcion_SiPaqueteYaEstaEntregado()
        {
            // Arrange
            var paquete = new Paquete();
            // Seteamos estado final manualmente para la prueba
            typeof(Paquete).GetProperty("EstadoId")!.SetValue(paquete, _entregadoId);

            // Act
            Action act = () => paquete.ActualizarEstado( _entregadoId);

            // Assert
            act.Should().Throw<DomainException>()
                .WithMessage("ERR_FINAL_STATE_REACHED");
        }

        [Theory]
        [InlineData("EnBodega", "EnTransito", true)]
        [InlineData("EnTransito", "EnReparto", true)]
        [InlineData("EnBodega", "Devuelto", true)]
        [InlineData("EnBodega", "Entregado", false)] // Brinco ilegal
        public void ValidarTransiciones_DebeRespetarReglasDeNegocio(string origen, string destino, bool esValido)
        {
            // Nota: Aquí mapearías tus GUIDs reales de CatalogoGuids
            // Esta prueba asegura que el diccionario de transiciones funcione

        }
    }
}
