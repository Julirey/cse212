using Microsoft.VisualStudio.TestTools.UnitTesting;

// Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following items and priority: A(1), B(3), C(2)
    // run until the queue is empty
    // Expected Result: B, C, A
    // Defect(s) Found: Assert.AreEqual failed. Expected:<C>. Actual:<B>.
    // Items where not being removed from the queue.
    // For loop couldn't access the last index.
    public void TestPriorityQueue_DifferentPriority()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Create a queue with multiple items of the same priority: A(2), B(2), C(2)
    // run until the queue is empty
    // Expected Result: A, B, C
    // Defect(s) Found: Expected:<A>. Actual:<B>.
    // Items where not being removed from the queue.
    // For loop couldn't access the last index.
    // The last item with the same priority would be picked first.
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 2);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Create a queue with multiple items of the same priority mixed with 
    // items of different priorities: A(1), B(2), C(2), D(3), E(1)
    // run until the queue is empty
    // Expected Result: D, B, C, A, E
    // Defect(s) Found: Assert.AreEqual failed. Expected:<B>. Actual:<D>.
    // Items where not being removed from the queue.
    // For loop couldn't access the last index.
    // The last item with the same priority would be picked first.

    public void TestPriorityQueue_MixedPriority()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 2);
        priorityQueue.Enqueue("D", 3);
        priorityQueue.Enqueue("E", 1);

        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("E", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to get the next item from an empty queue
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: None.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}