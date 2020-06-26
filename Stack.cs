using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack 
{
    public Vertex[] PosStack = new Vertex[1000];
    public int top;

    public Stack()
    {
        this.top = 0;
    }

    public bool IsEmpty()
    {
        if (top == 0) return true;
        else return false;
    }
    public bool IsFull()
    {
        if (top == 999) return true;
        else return false;
    }
    public void Push(Vertex PosData)
    {
        if (IsFull())
        {
            Debug.Log("The stack is full!\n");
        }
        else
        {
            top++;
            PosStack[top] = PosData;
        }
    }
    public Vertex Pop()
    {
        if (IsEmpty())
        {
            return null;
        }
        else
        {
            Vertex tmp;
            tmp = PosStack[top];
            top--;
            return tmp;
        }
    }

}
