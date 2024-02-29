//using DepthChartLib;
//using System.Numerics;

//[TestClass]
//public class DepthChartManagerTests
//{
//    private DepthChartManager _manager;
//    private Player _player1, _player2, _player3;

//    [TestInitialize]
//    public void Setup()
//    {
//        _manager = new DepthChartManager();
//        _player1 = new Player { Name = "John Doe", Id = 1 };
//        _player2 = new Player { Name = "Jane Smith", Id = 2 };
//        _player3 = new Player { Name = "Bob Johnson", Id = 3 };
//    }

//    [TestMethod]
//    public void TestAddPlayerToSpecificDepth()
//    {
//        _manager.AddPlayerToDepthChart("QB", _player1);
//        _manager.AddPlayerToDepthChart("QB", _player2, 0); // Add Jane before John
//        Assert.AreEqual(_player2, _manager.GetPlayersUnderPlayerInDepthChart("QB", _player1).FirstOrDefault());
//    }

//    [TestMethod]
//    public void TestGetPlayersUnderPlayerInDepthChart()
//    {
//        _manager.AddPlayerToDepthChart("QB", _player1);
//        _manager.AddPlayerToDepthChart("QB", _player2);
//        var playersUnder = _manager.GetPlayersUnderPlayerInDepthChart("QB", _player1);
//        Assert.IsTrue(playersUnder.Contains(_player2) && playersUnder.Count == 1);
//    }

//    [TestMethod]
//    public void TestDepthChartForMultiplePositions()
//    {
//        _manager.AddPlayerToDepthChart("QB", _player1);
//        _manager.AddPlayerToDepthChart("RB", _player2);
//        Assert.IsTrue(_manager.GetFullDepthChart().Contains(_player1));
//        Assert.IsTrue(_manager.GetFullDepthChart().Contains(_player2));
//    }

//    [TestMethod]
//    public void TestRemovingNonexistentPlayer()
//    {
//        _manager.RemovePlayerFromDepthChart("QB", _player1); // Player not added yet
//        Assert.IsFalse(_manager.GetFullDepthChart().Contains(_player1));
//    }

//    [TestMethod]
//    public void TestAddingDuplicatePlayer()
//    {
//        _manager.AddPlayerToDepthChart("QB", _player1);
//        _manager.AddPlayerToDepthChart("QB", _player1); // Attempt to add again
//        Assert.AreEqual(1, _manager.GetFullDepthChart().Count(p => p.Id == _player1.Id));
//    }

//    [TestMethod]
//    public void TestPlayerOrderAfterRemoval()
//    {
//        _manager.AddPlayerToDepthChart("QB", _player1);
//        _manager.AddPlayerToDepthChart("QB", _player2);
//        _manager.RemovePlayerFromDepthChart("QB", _player1);
//        Assert.AreEqual(_player2, _manager.GetFullDepthChart().FirstOrDefault());
//    }

//    [TestMethod]
//    public void TestDepthAfterMultipleAdditionsAndRemovals()
//    {
//        _manager.AddPlayerToDepthChart("QB", _player1);
//        _manager.AddPlayerToDepthChart("QB", _player2);
//        _manager.AddPlayerToDepthChart("QB", _player3);
//        _manager.RemovePlayerFromDepthChart("QB", _player2);
//        Assert.AreEqual(2, _manager.GetFullDepthChart().Count);
//        Assert.IsFalse(_manager.GetFullDepthChart().Any(p => p.Id == _player2.Id));
//    }

//    [TestMethod]
//    public void TestEmptyDepthChart()
//    {
//        var chart = _manager.GetFullDepthChart();
//        Assert.AreEqual(0, chart.Count);
//    }
//}
