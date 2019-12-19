// Implement hashtable as an array of linked list

using System;
using System.Collections;
using System.Collections.Generic;

namespace Kcah
{
    public class hashmap<T1, T2> : System.Collections.Generic.IEnumerable<T1> 
    {
        private int[] hash = null;

        private int GetHashCode(T1 key)
        {
            return key.GetHashCode();
        }

        public hashmap()
        {
            hash = new int[100];
        }

        public void Put(T1 key, T2 value)
        {

        }

        // public T2 Get(T1 key)
        // {
        //     return (T2)null;
        // }

        // public T2 this[T1 key]
        // {
        //     get{ return (T2)null;}
        // }

        public IEnumerator<T1> GetEnumerator()
        {
            return this.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            // Lets call the generic version here
            return this.GetEnumerator();
        }
    }


}

