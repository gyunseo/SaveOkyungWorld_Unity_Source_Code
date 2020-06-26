using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue 
{
    public Vertex[] PosQueue = new Vertex[1000];
    public int front,rear;

    public Queue()
    {
        this.front = 0;
        this.rear = 0;
    }

    public bool IsEmpty()
    {
        if (front == rear) return true;
        else return false;
    }

    public bool IsFull()
    {
        if (rear == 999) return true;
        else return false;
    }

    public void Enqueue(Vertex PosData)
    {
        if (IsFull())
        {
            Debug.Log("The queue is full!\n");
        }
        else
        {
            rear++;
            PosQueue[rear] = PosData;
        }

    }

    public Vertex Dequeue()
    {
        if (IsEmpty())
        {
            return null;
        }
        else
        {
            int tmp;
            tmp = front + 1;
            front++;
            return PosQueue[tmp];
        }
    }
    public int size()
    {
        return (rear - front);
    }
    public Vertex Peek()
    {
        if (IsEmpty())
        {
            return null;
        }
        else
        {
            return PosQueue[front+1];
        }
    }
    
}
