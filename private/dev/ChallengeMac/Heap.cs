using System;

namespace Challenge
{
    public class Heap
    {
        private int[] q;
        public int Size {get; set;}
        public int Index {get; set;}

        private int GetParent(int n)
        {
            if (n == 0)
            {
               return -1; 
            }
            else
            {
                return n/2;
            } 
        }

        private int GetChild(int n, bool leftChild = true)
        {
            if (leftChild)
            {
                return 2 * n;
            }
            else 
            {
                return 2 * n + 1;
            }
        }

        private void Insert(int a)
        {
            if (this.Index+1 > this.Size)
            {
                throw new OutOfMemoryException("Heap cannot hold any more elements!");
            }

            q[this.Index] = a;
            BubbleUp(this.Index);

            if (this.Index+1 < this.Size)
            { 
                this.Index++; 
            }
        }

        private void BubbleUp(int index)
        {
            int parent = GetParent(index);
            if (parent == -1) return;

            if (q[parent] > q[index])
            {
                int t = q[index];
                q[index] = q[parent];
                q[parent] = t;
                BubbleUp(parent);
            }
        }

        private void BubbleDown(int index)
        {
            int child, min, i=0;

            child = GetChild(index);
            min = index;

            while(i <= 1)
            {
                if ((child+i <= this.Index) && (q[min] > q[child+i]))
                {
                    min = child+i;
                }
                i++;
            }

            if (min != index)
            {
                int t = q[index];
                q[index] = q[min];
                q[min] = t;
                BubbleDown(min);
            }
        }

        public Heap(int size = 10)
        {
            this.Size = size;
            q = new int[this.Size];
        }

        public void MakeHeap(int[] a)
        {
            for(int i=0;i<a.Length;i++)
            {
                this.Insert(a[i]);
            }
        }
        public int ExtractMin()
        {
            int min = -1;

            if (this.Index == 0)
            {
                Console.WriteLine("Heap is empty!");
            }
            else
            {
                min = q[0];
                q[0] = q[this.Index];
                this.Index--;
                BubbleDown(0);
            }
            return (min);
        }
    }
}