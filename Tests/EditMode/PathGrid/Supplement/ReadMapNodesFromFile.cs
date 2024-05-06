using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class ReadMapNodesFromFile
{
    public List<BasicNode> Read(string fileName)
    {
        List<BasicNode> nodeList = new List<BasicNode>();
        string filePath = "Assets/StreamingAssets/" + fileName + ".txt";
        if (File.Exists(filePath))
        {
            StreamReader reader = new StreamReader(filePath);
            string fileContent = reader.ReadToEnd();
            string[] lines = fileContent.Split('\n');
            //string total = "";
            for (int i = 0; i < lines.Length; i++)
            {
                string[] nodes = lines[i].Split(' ');

                //string m = "";

                for (int j = 0; j < nodes.Length-1; j++)
                {
                    string[] tuple = nodes[j].Split(';');
                    string[] coordinateString = RemoveCharFromString(
                            RemoveCharFromString(tuple[0], '('),
                            ')'
                        )
                        .Split(',');
                    string[] positionString = RemoveCharFromString(
                            RemoveCharFromString(tuple[1], '('),
                            ')'
                        )
                        .Split(',');
                    bool isObstacle = tuple[2] == "False";
                    BasicNode node = new BasicNode(
                        isObstacle,
                        new Vector3(
                            float.Parse(positionString[0]),
                            float.Parse(positionString[1]),
                            float.Parse(positionString[2])
                        ),
                        int.Parse(coordinateString[0]),
                        int.Parse(coordinateString[1])
                    );
                    nodeList.Add(node);
                    //m += node.isObstacle ? "1" : "0";
                }
                //total += m;
                //total += "\n";
                //m = "";
            }
            //Debug.Log(total);
            reader.Close();
        }
        else
        {
            Debug.LogError("File not found");
        }
        return nodeList;
    }

    string RemoveCharFromString(string originalString, char charToRemove)
    {
        string replacedString = string.Empty;

        foreach (char c in originalString)
        {
            if (c != charToRemove)
            {
                replacedString += c;
            }
        }

        return replacedString;
    }
}
