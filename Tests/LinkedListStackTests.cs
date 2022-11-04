namespace Tests
{
    [TestClass]
    [TestCategory("MN")]  // Mettre vos initiales ici
    public class LinkedListStackTests
    {
        [TestMethod]
        [Timeout(500)]
        public void T01_TestCréation()
        {
            IStack<int> stack = new LinkedListStack<int>();
            Assert.AreEqual(0, stack.Count);
            Assert.IsTrue(stack.IsEmpty);
        }

        [TestMethod]
        [Timeout(500)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(10)]
        public void T02_TestPushPeek(int stackSize)
        {
            IStack<int> stack = new LinkedListStack<int>();
            // Pile vide
            Assert.ThrowsException<InvalidOperationException>(() => stack.Peek());
            for (int i = 1; i <= stackSize; i++)
            {
                stack.Push(i);
                Assert.AreEqual(i, stack.Peek());
                Assert.IsFalse(stack.IsEmpty);
                Assert.AreEqual(i, stack.Count);
            }
        }

        [TestMethod]
        [Timeout(500)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(10)]
        [DataRow(1000)]
        [DataRow(100000)]
        [DataRow(1, 3)]
        [DataRow(2, 3)]
        [DataRow(10, 3)]
        public void T03_TestPop(int stackSize, int repeat = 1)
        {
            IStack<int> stack = new LinkedListStack<int>();
            for (int _ = 1; _ <= repeat; _++)
            {
                for (int i = 1; i <= stackSize; i++)
                {
                    stack.Push(i % 2 == 0 ? default : i);
                }
                for (int i = stackSize; i > 0; i--)
                {
                    Assert.AreEqual(i % 2 == 0 ? default : i, stack.Pop());
                    Assert.AreEqual(i == 1, stack.IsEmpty);
                    Assert.AreEqual(i - 1, stack.Count);
                }
            }
            // Pile vide
            Assert.ThrowsException<InvalidOperationException>(() => stack.Pop());
        }

        [TestMethod]
        [Timeout(500)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(10)]
        public void T04_TestEnumerable(int stackSize)
        {
            IStack<int> stack = new LinkedListStack<int>();
            for (int i = 1; i <= stackSize; i++)
            {
                stack.Push(i);
                Assert.AreEqual(
                    string.Join(" ", Enumerable.Range(1, i).Reverse()), 
                    string.Join(" ", stack));
            }
        }

        [TestMethod]
        [Timeout(500)]
        public void T05_TestCount_TempsConstant()
        {
            // Si ce test ne se termine pas en dedans de 500ms,
            // Alors c'est que votre Count n'est pas O(1).
            // Sur ma machine: 24ms. 
            IStack<int> stack = new LinkedListStack<int>();
            for (int i = 1; i <= 200_000; i++)
            {
                stack.Push(i);
                Assert.AreEqual(i, stack.Count);
            }
        }
    }
}