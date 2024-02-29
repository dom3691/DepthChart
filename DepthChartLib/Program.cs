using System;
using System.Collections.Generic;
using System.Linq;

namespace DepthChartLib
{
    public enum Sports
    {
        NFL,
        MLB
    }

    public class Player
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }

    public interface IDepthChart
    {
        void AddPlayerToDepthChart(string position, Player player, int? depth = null);
        void RemovePlayerFromDepthChart(string position, Player player);
        IList<Player> GetFullDepthChart();
        IList<Player> GetPlayersUnderPlayerInDepthChart(string position, Player player);
    }
}
