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
    
    [Theory]
    [InlineData(3, 3, "Deuce")]
    [InlineData(6, 6, "Deuce")]
    public void Si_CadaJugadorTieneAlMenos3_Y_AmbosTienenLosMismos_Deuce(int puntosJugador1, int puntosJugador2, string esperado )
    {
        // Act
        var resultado = CalcularPuntaje(puntosJugador1, puntosJugador2);
        
        // Assert
        Assert.Equal(esperado, resultado);
    }
    
    [Theory]
    [InlineData(0, 1, "Love-Fifteen")]
    [InlineData(1, 2, "Fifteen-Thirty")]
    public void SiEsJuegoNormal(int puntosJugador1, int puntosJugador2, string esperado )
    {
        // Act
        var resultado = CalcularPuntaje(puntosJugador1, puntosJugador2);
        
        // Assert
        Assert.Equal(esperado, resultado);
    }
   
    private string CalcularPuntaje(int puntosJugador1, int puntosJugador2)
    {
        // Victoria: cualquier jugador mínimo 4 y diferencia de 2 o más
        if (puntosJugador1 >= 4 || puntosJugador2 >= 4)
        {
            int diferencia = puntosJugador1 - puntosJugador2;
            
            if (diferencia >= 2) return "Jugador 1 gana";
            if (diferencia <= -2) return "Jugador 2 gana";
        }
        
        // Ventaja: cada jugador mínimo 3 y diferencia de 1
        // Deuce: cada jugador mínimo 3 y diferencia de 0
        if (puntosJugador1 >= 3 && puntosJugador2 >= 3)
            return ObtenerVentajaODeuce(puntosJugador1, puntosJugador2);
        
        //Juego normal: ambos tienen menos de 4 puntos
        return ObtenerPuntajeNormal(puntosJugador1, puntosJugador2);
    }
    
    private string ObtenerVentajaODeuce(int puntosJugador1, int puntosJugador2)
    {
        int diferencia = puntosJugador1 - puntosJugador2;
        return diferencia switch
        {
            1 => "Ventaja jugador 1",
            -1 => "Ventaja jugador 2",
            _ => "Deuce"
        };
    }
    
    private string ObtenerPuntajeNormal(int puntosJugador1, int puntosJugador2)
    {
        string[] valores = { "Love", "Fifteen", "Thirty", "Forty" };
        return $"{valores[puntosJugador1]}-{valores[puntosJugador2]}";
    }
    
}