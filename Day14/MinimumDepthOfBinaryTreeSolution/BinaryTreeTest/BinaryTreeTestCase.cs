using NUnit.Framework;
using MinimumDepthOfBinaryTree;
using System.Threading.Tasks;

namespace BinaryTreeTest
{
    public class BinaryTreeTestCase
    {
        private Program program;

        [SetUp]
        public void Setup()
        {
            program = new Program();
        }

        [Test]
        public async Task MinimumDepthAsync_Test()
        {
            // Arrange
            int?[] inputArray = { 3, 9, 20, null, null, 15, 7 };
            Node node = program.ArrayToTree(inputArray, 0);

            // Act
            int minimumDepth = await program.MinimumDepthAsync(node);

            // Assert
            Assert.AreEqual(2, minimumDepth);
        }

        [Test]
        public async Task MinimumDepthAsync_Single()
        {
            // Arrange
            int?[] inputArray = { 1 };
            Node node = program.ArrayToTree(inputArray, 0);

            // Act
            int minimumDepth = await program.MinimumDepthAsync(node);

            // Assert
            Assert.AreEqual(1, minimumDepth);
        }
    }
}
