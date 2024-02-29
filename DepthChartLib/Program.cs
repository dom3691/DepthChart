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

    public class DepthChartManager : IDepthChart
    {
        private readonly Dictionary<string, List<Player>> _depthCharts;

        public DepthChartManager()
        {
            _depthCharts = new Dictionary<string, List<Player>>();
        }

        public void AddPlayerToDepthChart(string position, Player player, int? depth = null)
        {
            if (!_depthCharts.ContainsKey(position))
            {
                _depthCharts[position] = new List<Player>();
            }
            if (depth == null || depth >= _depthCharts[position].Count)
            {
                _depthCharts[position].Add(player);
            }
            else
            {
                _depthCharts[position].Insert((int)depth, player);
            }
        }

        public void RemovePlayerFromDepthChart(string position, Player player)
        {
            if (_depthCharts.ContainsKey(position))
            {
                _depthCharts[position].Remove(player);
            }
        }

        public IList<Player> GetFullDepthChart()
        {
            return _depthCharts.SelectMany(dc => dc.Value).ToList();
        }

        public IList<Player> GetPlayersUnderPlayerInDepthChart(string position, Player player)
        {
            if (_depthCharts.ContainsKey(position))
            {
                var index = _depthCharts[position].FindIndex(p => p.Id == player.Id);
                if (index != -1 && index < _depthCharts[position].Count - 1)
                {
                    return _depthCharts[position].Skip(index + 1).ToList();
                }
            }
            return new List<Player>();
        }
    }

}
