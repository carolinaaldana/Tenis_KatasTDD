namespace Tenis;

public class TenisTest
{
    [Theory]
    [InlineData(4, 0, "Jugador 1 gana")]
    [InlineData(3, 5, "Jugador 2 gana")]
    public void Si_UnJugador_Obtiene4PuntosTotales_Y_2MasQueSuOponente_Gana(int puntosJugador1, int puntosJugador2, string esperado )
    {
        // Act
        var resultado = CalcularPuntaje(puntosJugador1, puntosJugador2);
        
        // Assert
        Assert.Equal(esperado, resultado);
    }
    
    [Theory]
    [InlineData(5, 4, "Ventaja jugador 1")]
    [InlineData(5, 6, "Ventaja jugador 2")]
    public void Si_CadaJugadorTieneAlMenos3_Y_UnoDeLosOponentesTiene1Mas_Ventaja(int puntosJugador1, int puntosJugador2, string esperado )
    {
        // Act
        var resultado = CalcularPuntaje(puntosJugador1, puntosJugador2);
        
        // Assert
        Assert.Equal(esperado, resultado);
    }

    private string CalcularPuntaje(int puntosJugador1, int puntosJugador2)
    {
        if (puntosJugador1 >= 4 || puntosJugador2 >= 4)
        {
            int diferencia = puntosJugador1 - puntosJugador2;
            
            if (diferencia >= 2) return "Jugador 1 gana";
            if (diferencia <= -2) return "Jugador 2 gana";
        }
        
        if (puntosJugador1 >= 3 || puntosJugador2 >= 3)
        {
            int diferencia = puntosJugador1 - puntosJugador2;
            
            if (diferencia == 1) return "Ventaja jugador 1";
            if (diferencia == -1) return "Ventaja jugador 2";
        }
        return "";
    }
}