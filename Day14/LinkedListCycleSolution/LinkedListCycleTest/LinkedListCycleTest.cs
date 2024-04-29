using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System.Threading.Tasks;
using LinkedListCycle;

namespace LinkedListCycle.Tests
{
    public class LinkedListTests
    {
        [Test]
        public async Task HasCycle_MultiNode()
        {
            // Arrange
            ListNode node1 = new ListNode(3);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(0);
            ListNode node4 = new ListNode(-4);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node2;

            Program program = new Program();
           
            // Act
            bool hasCycle = await program.HasCycle(node1, 2);
            
            // Assert
            Assert.IsTrue(hasCycle);
        }

        [Test]
        public async Task HasCycle_SingleNode()
        {
            // Arrange
            ListNode node1 = new ListNode(3);

            Program program = new Program();

            // Act
            bool hasCycle = await program.HasCycle(node1, 2);

            // Assert
            Assert.IsFalse(hasCycle);
        }
    }
}
