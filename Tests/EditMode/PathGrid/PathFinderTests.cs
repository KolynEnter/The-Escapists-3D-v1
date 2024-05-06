using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PathFinderTests
{
    [Test]
    public void PathFinderTestsSimplePasses()
    {
        BasicGridGenerator generator = new BasicGridGenerator();
        BasicGrid grid = generator.ReadFromFile();

        TestFewestTurningPointsPath(
            true,
            grid,
            grid.NodeFromWorldPoint(new Vector3(-20.5f, 0, 11.5f)),
            grid.NodeFromWorldPoint(new Vector3(4.5f, 0, -12.5f))
        );
        TestPathRetracing(
            grid,
            grid.NodeFromWorldPoint(new Vector3(-20.5f, 0, 11.5f)),
            grid.NodeFromWorldPoint(new Vector3(4.5f, 0, -12.5f))
        );
        grid = generator.ReadFromFile();
        TestShortestDistancePath(
            true,
            grid,
            grid.NodeFromWorldPoint(new Vector3(-20.5f, 0, 11.5f)),
            grid.NodeFromWorldPoint(new Vector3(4.5f, 0, -12.5f))
        );
        TestPathRetracing(
            grid,
            grid.NodeFromWorldPoint(new Vector3(-20.5f, 0, 11.5f)),
            grid.NodeFromWorldPoint(new Vector3(4.5f, 0, -12.5f))
        );
    }

    private void TestShortestDistancePath(
        bool expecting,
        BasicGrid grid,
        BasicNode startingNode,
        BasicNode endingNode
    )
    {
        PathFindingLogic logic = new PathFindingLogic();
        Assert.AreEqual(
            expecting,
            logic.StartFindPath(grid, startingNode, endingNode, FindingWayMode.ShortestDistance)
        );
    }

    private void TestFewestTurningPointsPath(
        bool expecting,
        BasicGrid grid,
        BasicNode startingNode,
        BasicNode endingNode
    )
    {
        PathFindingLogic logic = new PathFindingLogic();
        Assert.AreEqual(
            expecting,
            logic.StartFindPath(grid, startingNode, endingNode, FindingWayMode.FewestTurningPoints)
        );
    }

    private void TestPathRetracing(BasicGrid grid, BasicNode startingNode, BasicNode endingNode)
    {
        PathRetracer retracer = new PathRetracer();
        // the character moves in one of the four directions
        Vector3[] path = retracer.RetracePathSimplified(startingNode, endingNode);
        for (int i = 0; i < path.Length - 1; i++)
        {
            Assert.AreEqual(
                true,
                path[i].x == path[i + 1].x || path[i].z == path[i + 1].z
            );
        }
    }
}
