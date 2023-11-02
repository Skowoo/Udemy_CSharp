using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Udemy_CSharp
{
    public static class Inheritance_Geometric
    {
        public static void PseudoMain()
        {
            Point[] points = { new Point(1, 1), new Point(2, 2), new Point(4, 4) };
            try
            {
                Triangle triangle = new(points);
                Console.WriteLine(triangle.ToString());
                var clone = triangle.Clone();
                Console.WriteLine(clone.ToString());
                Console.WriteLine(triangle.Equals(clone));
                foreach (Point p in triangle)
                    Console.WriteLine(p.ToString());
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.ToString());
            }
        }
    }

    public struct Point
    {
        int x, y;

        public Point(int x = 0, int y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public void Relocate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void RelocateX(int x) => this.x = x;

        public void RelocateY(int y) => this.y = y;

        public override string ToString() => $"X: {x}, Y: {y}";
    }

    public interface ICalculable
    {
        public float GetArea();

        public float GetCircumference();
    }

    public class Shape : ICloneable, IEnumerable<Point>
    {
        private Point[] points;

        protected Shape(params Point[] input)
        {
            points = input;
        }

        public object Clone() => new Shape(points);

        // GetEnumerator have to return points from inner array
        public IEnumerator<Point> GetEnumerator()
        {
            for (int i = 0; i < points.Length; i++)
                yield return points[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();

        public override string ToString() => $"Shape have {points.Length} edges";
    }

    public class Triangle : Shape, ICalculable
    { 
        public Triangle(params Point[] input) : base(input) 
        {
            if (input.Length != 3)
                throw new Exception("Number of points don't correspond with triangle!");
        }

        public float GetArea()
        {
            throw new NotImplementedException();
        }

        public float GetCircumference()
        {
            throw new NotImplementedException();
        }
    }
}
