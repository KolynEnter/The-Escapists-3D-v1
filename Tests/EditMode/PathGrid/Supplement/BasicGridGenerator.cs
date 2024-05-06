using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGridGenerator
{
    // [0, 0, 1]
    // [0, 1, 0]
    // [0, 0, 0]
    public BasicGrid GenerateSimple3By3Grid()
    {
        BasicNode[,] grid = new BasicNode[3, 3];
        grid[0, 0] = NewNode(false, new Vector3(0.5f, 0, 0.5f), 0, 0);
        grid[0, 1] = NewNode(false, new Vector3(1.5f, 0, 0.5f), 0, 1);
        grid[0, 2] = NewNode(true, new Vector3(2.5f, 0, 0.5f), 0, 2);
        grid[1, 0] = NewNode(false, new Vector3(0.5f, 0, 1.5f), 1, 0);
        grid[1, 1] = NewNode(true, new Vector3(1.5f, 0, 1.5f), 1, 1);
        grid[1, 2] = NewNode(false, new Vector3(2.5f, 0, 1.5f), 1, 2);
        grid[2, 0] = NewNode(false, new Vector3(0.5f, 0, 2.5f), 2, 0);
        grid[2, 1] = NewNode(false, new Vector3(1.5f, 0, 2.5f), 2, 1);
        grid[2, 2] = NewNode(false, new Vector3(2.5f, 0, 2.5f), 2, 2);

        return new BasicGrid(grid, new Vector2(3, 3));
    }

    // [0, 0, 1, 0]
    // [0, 1, 0, 1]
    // [0, 0, 0, 1]
    // [1, 0, 0, 0]
    public BasicGrid GenerateSimple4By4Grid()
    {
        BasicNode[,] grid = new BasicNode[4, 4];
        grid[0, 0] = NewNode(false, new Vector3(0.5f, 0, 0.5f), 0, 0);
        grid[0, 1] = NewNode(false, new Vector3(1.5f, 0, 0.5f), 0, 1);
        grid[0, 2] = NewNode(true, new Vector3(2.5f, 0, 0.5f), 0, 2);
        grid[0, 3] = NewNode(false, new Vector3(3.5f, 0, 0.5f), 0, 3);

        grid[1, 0] = NewNode(false, new Vector3(0.5f, 0, 1.5f), 1, 0);
        grid[1, 1] = NewNode(true, new Vector3(1.5f, 0, 1.5f), 1, 1);
        grid[1, 2] = NewNode(false, new Vector3(2.5f, 0, 1.5f), 1, 2);
        grid[1, 3] = NewNode(true, new Vector3(3.5f, 0, 1.5f), 1, 3);

        grid[2, 0] = NewNode(false, new Vector3(0.5f, 0, 2.5f), 2, 0);
        grid[2, 1] = NewNode(false, new Vector3(1.5f, 0, 2.5f), 2, 1);
        grid[2, 2] = NewNode(false, new Vector3(2.5f, 0, 2.5f), 2, 2);
        grid[2, 3] = NewNode(true, new Vector3(3.5f, 0, 2.5f), 2, 3);

        grid[3, 0] = NewNode(true, new Vector3(0.5f, 0, 3.5f), 3, 0);
        grid[3, 1] = NewNode(false, new Vector3(1.5f, 0, 3.5f), 3, 1);
        grid[3, 2] = NewNode(false, new Vector3(2.5f, 0, 3.5f), 3, 2);
        grid[3, 3] = NewNode(false, new Vector3(3.5f, 0, 3.5f), 3, 3);

        return new BasicGrid(grid, new Vector2(4, 4));
    }

    // [0, 0, 1, 0]
    // [0, 1, 0, 1]
    // [0, 1, 0, 1]
    // [1, 0, 0, 0]
    public BasicGrid GenerateSimple4By4GridWithUnreachable()
    {
        BasicGrid grid = GenerateSimple4By4Grid();
        grid.MyGrid[2, 1] = NewNode(true, new Vector3(1.5f, 0, 2.5f), 2, 1);

        return grid;
    }

    public BasicGrid ReadFromFile() {
        ReadMapNodesFromFile reader = new ReadMapNodesFromFile();
        List<BasicNode> nodeList = reader.Read("CenterPerkMapNode");
        BasicNode[] nodeArray = nodeList.ToArray();
        BasicNode[,] grid = new BasicNode[88, 80];
        for (int i = 0; i < nodeArray.Length; i++) {
            BasicNode node = nodeArray[i];
            grid[node.GridX, node.GridY] = node;
        }
        return new BasicGrid(grid, new Vector2(88, 80));
    }

    private BasicNode NewNode(bool isObstacle, Vector3 worldPosition, int gridX, int gridY)
    {
        return new BasicNode(isObstacle, worldPosition, gridX, gridY);
    }
}
