namespace Tests
{
    [TestClass]
    [TestCategory("MN")]  // Mettre vos initiales ici
    public class StaticStackTests
    {
        [TestMethod]
        [Timeout(500)]
        [DataRow(1)]
        [DataRow(10)]
        [DataRow(1000)]
        public void T01_TestCréation(int stackSize)
        {
            IStaticStack<int> stack = new StaticStack<int>(stackSize);
            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(stackSize, stack.Capacity);
            Assert.IsTrue(stack.IsEmpty);
            Assert.IsFalse(stack.IsFull);
        }

        [TestMethod]
        [Timeout(500)]
        [DataRow(0)]
        [DataRow(-1)]
        public void T02_TestCréation_Erreur(int stackSize)
        {
            Assert.ThrowsException<ArgumentException>(() => new StaticStack<int>(stackSize));
        }

        [TestMethod]
        [Timeout(500)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(10)]
        public void T03_TestPushPeek(int stackSize)
        {
            IStaticStack<int> stack = new StaticStack<int>(stackSize);
            // Pile vide
            Assert.ThrowsException<InvalidOperationException>(() => stack.Peek());
            for (int i = 1; i <= stackSize; i++)
            {
                stack.Push(i);
                Assert.AreEqual(i, stack.Peek());
                Assert.IsFalse(stack.IsEmpty);
                Assert.AreEqual(i == stackSize, stack.IsFull);
                Assert.AreEqual(i, stack.Count);
            }
            // Pile pleine
            Assert.ThrowsException<InvalidOperationException>(() => stack.Push(0));
        }

        [TestMethod]
        [Timeout(500)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(10)]
        public void T04_TestPop(int stackSize)
        {
            IStaticStack<int> stack = new StaticStack<int>(stackSize);
            for (int i = 1; i <= stackSize; i++)
            {
                stack.Push(i);
            }
            for (int i = stackSize; i > 0; i--)
            {
                Assert.AreEqual(i, stack.Pop());
                Assert.IsFalse(stack.IsFull);
                Assert.AreEqual(i == 1, stack.IsEmpty);
                Assert.AreEqual(i - 1, stack.Count);
            }
            // Pile vide
            Assert.ThrowsException<InvalidOperationException>(() => stack.Pop());
        }

        [TestMethod]
        [Timeout(500)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(10)]
        public void T05_TestEnumerable(int stackSize)
        {
            IStaticStack<int> stack = new StaticStack<int>(stackSize);
            for (int i = 1; i <= stackSize; i++)
            {
                stack.Push(i);
            }
            Assert.IsTrue(Enumerable.Range(1, stackSize).SequenceEqual(stack));
        }
    }
}