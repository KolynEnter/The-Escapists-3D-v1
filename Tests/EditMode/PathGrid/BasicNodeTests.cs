using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BasicNodeTests
{
    [Test]
    public void BasicNodeTestsSimplePasses()
    {
        BasicNode node1 = new BasicNode(true, new Vector3(0, 0, 0), 0, 0);
        BasicNode node2 = new BasicNode(true, new Vector3(0, 0, 0), 0, 0);
        TestCompareToSuccess(node1, node2);
        node2 = new BasicNode(false, new Vector3(0, 0, 0), 0, 0);
        TestCompareToSuccess(node1, node2);
        node2 = new BasicNode(true, new Vector3(1, 0, 1), 0, 0);
        TestCompareToSuccess(node1, node2);
        node2 = new BasicNode(true, new Vector3(0, 0, 0), 1, 1);
        TestCompareToSuccess(node1, node2);
        node2.gCost = 10;
        TestCompareToFail(node1, node2);
    }

    private void TestCompareToSuccess(BasicNode node1, BasicNode node2)
    {
        Assert.AreEqual(0, node1.CompareTo(node2));
    }

    private void TestCompareToFail(BasicNode node1, BasicNode node2)
    {
        Assert.AreNotEqual(0, node1.CompareTo(node2));
    }
}
