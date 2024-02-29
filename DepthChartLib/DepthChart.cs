using System;
using System.Collections.Generic;
using System.Linq;

public class DepthChart
{
    private readonly Dictionary<Position, SortedList<int, Player>> _charts;

    public DepthChart()
    {
        _charts = new Dictionary<Position, SortedList<int, Player>>();
        foreach (Position position in Enum.GetValues(typeof(Position)))
        {
            _charts[position] = new SortedList<int, Player>();
        }
    }

    public void AddPlayerToDepthChart(Player player, Position position, int? positionDepth = null)
    {
        var depth = positionDepth ?? _charts[position].Count;
        if (!_charts[position].ContainsKey(depth))
        {
            _charts[position].Add(depth, player);
        }
        else
        {
            // Handle logic if position depth is already occupied
            _charts[position].Add(_charts[position].Keys.Max() + 1, player); // Add at the end if specific depth is occupied
        }
    }

    public void RemovePlayerFromDepthChart(Player player, Position position)
    {
        var item = _charts[position].FirstOrDefault(x => x.Value.PlayerId == player.PlayerId);
        if (!item.Equals(default(KeyValuePair<int, Player>)))
        {
            _charts[position].Remove(item.Key);
        }
    }

    public IEnumerable<Player> GetPlayersUnderPlayerInDepthChart(Player player, Position position)
    {
        return _charts[position]
            .Where(p => p.Key > _charts[position].First(x => x.Value.PlayerId == player.PlayerId).Key)
            .Select(p => p.Value);
    }

    public void GetFullDepthChart()
    {
        foreach (var position in _charts.Keys)
        {
            Console.WriteLine($"{position}: {string.Join(", ", _charts[position].Values.Select(player => player.Name))}");
        }
    }
}

public enum Position
{
    QB, WR, RB, TE, K, P, KR, PR
}

public class Player
{
    public int PlayerId { get; set; }
    public string Name { get; set; }

    public Player(int playerId, string name)
    {
        PlayerId = playerId;
        Name = name;
    }
}

