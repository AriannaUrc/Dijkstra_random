using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_random
{
    internal class MyPriorityQueue
    {
        
        struct Node
        {
            public string task;
            public int priority;
            public Node(string task, int priority)
            {
                this.task = task;
                this.priority = priority;
            }
        };

        ArrayList heap = new ArrayList();
        void insert(string task, int priority)
        {
            Node temp = new Node(task, priority);
            heap.Add(temp);
            int idx = heap.Count - 1;

            while (idx != 0)
            {
                int parentIdx = (idx - 1) / 2;
                Node parent = (Node)heap[parentIdx];
                Node son = (Node)heap[idx];

                if (parent.priority < son.priority)
                {
                    var temp1 = heap[parentIdx];
                    heap[parentIdx] = heap[idx];
                    heap[idx] = temp1;

                    idx = parentIdx;
                }
                else
                {
                    break;
                }
            }
        }

        Node RemoveLast()
        {
            Node temp = (Node)heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            return temp;
        }

        Node RemoveFirst()
        {
            Node temp = (Node)heap[0];
            heap.RemoveAt(0);
            return temp;
        }

        Node Peek()
        {
            return (Node)heap[0];
        }

        bool IsEmpty()
        {
            return heap.Count == 0;
        }

        int research(string task)
        {
            int found = -1;
            Node temp = (Node)heap[0];

            for (int i = 0; i < heap.Count; i++)
            {
                temp = (Node)heap[0];
                if (task == temp.task)
                {
                    found = i;
                    break;
                }
            }

            return found;
        }
    };
}
