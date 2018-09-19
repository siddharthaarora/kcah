// Implementation of data structures that support spatial data indexing
// and operations such as - containment and near me queries 
// https://bytes.com/topic/c-sharp/insights/880968-generic-quadtree-implementation

using System;
using System.Collections.Generic;

namespace Challenge
{
    public interface IHasRectangle
    {
        Rectangle Rectangle {get; set;}
    }

    public class Rectangle
    {
        public int PosX {get; set;}
        public int PosY {get; set;}
        public int Width {get; set;}
        public int Height {get; set;}
    }

    public class QuadTree<T> where T : IHasRectangle
    {
        private const int MAX_OBJECTS_PER_NODE = 2;
        public List<T> Objects {get; set;}
        public Rectangle Rectangle {get; set;}
        public QuadTree<T> TopLeftChild {get; set;}
        public QuadTree<T> TopRightChild {get; set;}
        public QuadTree<T> BottomLeftChild {get; set;}
        public QuadTree<T> BottomRightChild {get; set;}

        public QuadTree (Rectangle r)
        {
            this.Rectangle = r; 
        }

        public QuadTree (int x, int y, int width, int height)
        {
            this.Rectangle = new Rectangle(){
                PosX = x,
                PosY = y,
                Width = width,
                Height = height
            };
        }


    }
}