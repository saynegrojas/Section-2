using System;
using System.Collections.Generic;

// LIFO
public class MinStack
{
  private Stack<int> primaryStack; // store actual values
  private Stack<int> minStack; // store min values
  // constructor
  public MinStack()
  {
    minStack = new Stack<int>();
    primaryStack = new Stack<int>();
  }

  public void StackPush(int val)
  {
    primaryStack.Push(val);

    // if min stack empty || val passed in is <= current min value, add to min stack
    if (minStack.Count == 0 || val <= minStack.Peek())
    {
      minStack.Push(val);
    }
  }

  public int StackPop()
  {
    if (primaryStack.Count == 0) throw new InvalidOperationException("Empty stack");

    int result = primaryStack.Pop();

    if (result == minStack.Peek())
    {
      minStack.Pop();
    }
    return result;
  }


  public int StackMin()
  {
    if (primaryStack.Count == 0) throw new InvalidOperationException("Empty stack");
    return minStack.Peek();
  }

  public void PrintMinStack()
  {
    Console.WriteLine($"Stack: {string.Join(", ", minStack)}");
  }
}

class Propgram
{
  static void Main(string[] args)
  {
    MinStack stack = new MinStack();

    stack.StackPush(7);
    stack.StackPush(9);
    stack.StackPush(3);
    stack.PrintMinStack();

    Console.WriteLine($"Min stack: {stack.StackMin()}");

    stack.StackPop();
    Console.WriteLine($"Min stack popped: {stack.StackMin()}");

    stack.StackPush(2);
    Console.WriteLine($"Min: {stack.StackMin()}");
    stack.PrintMinStack();

  }
}