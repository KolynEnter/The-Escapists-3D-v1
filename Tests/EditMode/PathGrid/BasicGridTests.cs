using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Linq;
using System.Collections.Generic;

public class BasicGridTests
{
    [Test]
    public void BasicGridTestsScriptSimplePasses()
    {
        BasicGridGenerator generator = new BasicGridGenerator();
        BasicGrid grid = generator.GenerateSimple4By4Grid();
        TestNodeFromWorldPosition1(grid);
        TestNodeFromWorldPosition2(grid);
        TestGenerateOneWalkablePosition(grid);
        TestGetNeighbours(grid);
    }

    private void TestNodeFromWorldPosition1(BasicGrid grid) {
        Vector3 nodePosition = new Vector3(1.5f, 0, 1.5f);
        BasicNode node = grid.NodeFromWorldPoint(GetCenterPivotedNodePosition(grid, nodePosition));
        Assert.AreEqual(true, node.IsObstacle);
        Assert.AreEqual(nodePosition, node.WorldPosition);
        Assert.AreEqual(1, node.GridX);
        Assert.AreEqual(1, node.GridY);
    }

    private void TestNodeFromWorldPosition2(BasicGrid grid) {
        Vector3 nodePosition = new Vector3(0.5f, 0, 0.5f);
        BasicNode node = grid.NodeFromWorldPoint(GetCenterPivotedNodePosition(grid, nodePosition));
        Assert.AreEqual(false, node.IsObstacle);
        Assert.AreEqual(nodePosition, node.WorldPosition);
        Assert.AreEqual(0, node.GridX);
        Assert.AreEqual(0, node.GridY);
    }

    private void TestGenerateOneWalkablePosition(BasicGrid grid) {
        for (int i = 0; i < 9; i++) {
            Vector3 nodePosition = grid.GenerateOneWalkablePosition();
            BasicNode node = grid.NodeFromWorldPoint(GetCenterPivotedNodePosition(grid, nodePosition));
            Assert.AreEqual(false, node.IsObstacle);
        }
    }

    private void TestGetNeighbours(BasicGrid grid) {
        Vector3 nodePosition = new Vector3(0.5f, 0, 0.5f);
        BasicNode node = grid.NodeFromWorldPoint(GetCenterPivotedNodePosition(grid, nodePosition));
        List<BasicNode> neighboursList = grid.GetNeighbours(node);
        BasicNode[] neighbours = neighboursList.ToArray();
        Assert.AreEqual(neighbours.Length, 2);
        Assert.IsTrue(neighbours.Any(item => item.GridX == 0 && item.GridY == 1));
        Assert.IsTrue(neighbours.Any(item => item.GridX == 1 && item.GridY == 0));
    }

    private Vector3 GetCenterPivotedNodePosition(BasicGrid grid, Vector3 position) {
        return new Vector3(position.x-grid.GridSizeX/2, 0, position.z-grid.GridSizeX/2);
    }
}
