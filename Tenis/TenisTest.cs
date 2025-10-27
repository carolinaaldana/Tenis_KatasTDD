namespace Tenis;

public class TenisTest
{
    [Theory]
    [InlineData(4, 0, "Jugador 1 gana")]
    [InlineData(3, 5, "Jugador 2 gana")]
    public void Si_UnJugador_Obtiene4PuntosTotales_Y_2MasQueSuOponente_Gana(int jugador1, int jugador2, string esperado )
    {
        // Act
        var resultado = CalcularPuntaje(jugador1, jugador2);
        
        // Assert
        Assert.Equal(esperado, resultado);

    }

    private string CalcularPuntaje(int jugador1, int jugador2)
    {
        throw new NotImplementedException();
    }
}