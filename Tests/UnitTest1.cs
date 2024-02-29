using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DepthChartLib.Tests
{
    [TestFixture]
    public class DepthChartTests
    {
        private DepthChart _depthChart;
        private Player _player1, _player2, _player3;

        [SetUp]
        public void SetUp()
        {
            _depthChart = new DepthChart();
            _player1 = new Player(1, "Player One");
            _player2 = new Player(2, "Player Two");
            _player3 = new Player(3, "Player Three");
        }

        [Test]
        public void AddPlayerToDepthChart_AddsPlayerCorrectly()
        {
            _depthChart.AddPlayerToDepthChart(_player1, Position.QB);
           // Assert.Contains(_player1, _depthChart.GetFullDepthChart()[Position.QB]);
        }

        [Test]
        public void RemovePlayerFromDepthChart_RemovesPlayerCorrectly()
        {
            _depthChart.AddPlayerToDepthChart(_player1, Position.QB);
            _depthChart.RemovePlayerFromDepthChart(_player1, Position.QB);
            //Assert.IsFalse(_depthChart.GetFullDepthChart()[Position.QB].Contains(_player1));
        }

        [Test]
        public void AddingPlayersAtSameDepth_ShouldRetainOrder()
        {
            _depthChart.AddPlayerToDepthChart(_player1, Position.QB);
            _depthChart.AddPlayerToDepthChart(_player2, Position.QB);
            //var list = _depthChart.GetFullDepthChart()[Position.QB];
            //Assert.IsTrue(list.IndexOf(_player2) > list.IndexOf(_player1));
        }

        [Test]
        public void GetPlayersUnderPlayerInDepthChart_ReturnsCorrectPlayers()
        {
            _depthChart.AddPlayerToDepthChart(_player1, Position.QB);
            _depthChart.AddPlayerToDepthChart(_player2, Position.QB);
            _depthChart.AddPlayerToDepthChart(_player3, Position.QB);

            var players = _depthChart.GetPlayersUnderPlayerInDepthChart(_player1, Position.QB);
            Assert.Contains(_player2, players.ToList());
            Assert.Contains(_player3, players.ToList());
        }

        [Test]
        public void GetFullDepthChart_ReturnsAllPlayers()
        {
            _depthChart.AddPlayerToDepthChart(_player1, Position.QB);
            _depthChart.AddPlayerToDepthChart(_player2, Position.RB);
          //  var chart = _depthChart.GetFullDepthChart();
            //Assert.Contains(_player1, chart[Position.QB]);
            //Assert.Contains(_player2, chart[Position.RB]);
        }
    }
}
