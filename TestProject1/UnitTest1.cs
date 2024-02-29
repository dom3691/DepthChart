using Xunit;
using System.Collections.Generic;
using System.Numerics;

public class DepthChartTests
{
    [Fact]
    public void AddPlayerToDepthChart_AddsPlayerSuccessfully()
    {
        // Arrange
        var depthChart = new DepthChart();
        var player = new Player(1, "Test Player");

        // Act
        depthChart.AddPlayerToDepthChart(player, Position.QB);

        // Assert
        Assert.Contains(player, depthChart.GetFullDepthChart()[Position.QB]);
    }

    [Fact]
    public void RemovePlayerFromDepthChart_RemovesPlayerSuccessfully()
    {
        // Arrange
        var depthChart = new DepthChart();
        var player = new Player(1, "Test Player");
        depthChart.AddPlayerToDepthChart(player, Position.QB);

        // Act
        depthChart.RemovePlayerFromDepthChart(player, Position.QB);

        // Assert
        Assert.DoesNotContain(player, depthChart.GetFullDepthChart()[Position.QB]);
    }

    [Fact]
    public void GetPlayersUnderPlayerInDepthChart_ReturnsCorrectPlayers()
    {
        // Arrange
        var depthChart = new DepthChart();
        var player1 = new Player(1, "Test Player 1");
        var player2 = new Player(2, "Test Player 2");
        depthChart.AddPlayerToDepthChart(player1, Position.QB);
        depthChart.AddPlayerToDepthChart(player2, Position.QB);

        // Act
        var result = depthChart.GetPlayersUnderPlayerInDepthChart(player1, Position.QB);

        // Assert
        Assert.Contains(player2, result);
        Assert.DoesNotContain(player1, result);
    }

    [Fact]
    public void GetFullDepthChart_ReturnsAllPositions()
    {
        // Arrange
        var depthChart = new DepthChart();
        var player = new Player(1, "Test Player");
        depthChart.AddPlayerToDepthChart(player, Position.QB);

        // Act
        var result = depthChart.GetFullDepthChart();

        // Assert
        Assert.NotNull(result);
        Assert.Contains(Position.QB, result.Keys);
    }
}
