using System.Collections;

namespace Udemy_CSharp
{
    public static class Inheritance_Geometric
    {
        public static void PseudoMain()
        {
            Point[] points = { new Point(0, 0), new Point(0, 2), new Point(2, 2), new Point(2, 2) };
            try
            {
                Rectangle example = new(points);
                Console.WriteLine(example.ToString());
                foreach (Point p in example)
                    Console.WriteLine(p.ToString());
                Console.WriteLine(example.GetCircumference());
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

        public float CalculateDistanceBetween(Point other)
        {
            int BiggerX = Math.Max(Math.Abs(this.x), Math.Abs(other.x));
            int BiggerY = Math.Max(Math.Abs(this.y), Math.Abs(other.y));
            int smallerX = Math.Min(Math.Abs(this.x), Math.Abs(other.x));
            int smallerY = Math.Min(Math.Abs(this.y), Math.Abs(other.y));

            if (this.x == other.x)
                return BiggerY - smallerY;
            else if (this.y == other.y)
                return BiggerX - smallerX;
            else
                return (float)Math.Sqrt(Math.Pow(BiggerY - smallerY, 2) + Math.Pow(BiggerX - smallerX, 2));
        }

        public override string ToString() => $"X: {x}, Y: {y}";
    }

    public abstract class Shape : IEnumerable<Point>
    {
        private Point[] points;

        protected Shape(params Point[] input)
        {
            points = input;
            Console.WriteLine("Shape constructor called");
        }

        // GetEnumerator have to return points from inner array
        public IEnumerator<Point> GetEnumerator()
        {
            for (int i = 0; i < points.Length; i++)
                yield return points[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();

        public virtual float GetCircumference()
        {
            float result = 0;
            for (int i = 1; i < points.Length; i++)
                result += points[i - 1].CalculateDistanceBetween(points[i]);
            result += points[points.Length - 1].CalculateDistanceBetween(points[0]);
            return result;
        }

        // Abstract method must be implemented in derived class (similarly to Interface)
        public abstract float GetArea();

        public override string ToString() => $"Shape have {points.Length} edges";
    }

    public class Triangle : Shape
    { 
        public Triangle(params Point[] input) : base(input) 
        {
            if (input.Length != 3)
                throw new Exception("Number of points don't correspond with triangle!");
            Console.WriteLine("Triangle constructor called");
        }

        public override float GetArea()
        {
            throw new NotImplementedException();
        }

        public override float GetCircumference()
        {
            throw new NotImplementedException();
        }
    }

    public class Rectangle : Shape
    {
        //Base class constructor will be called BEFORE input length is checked!
        public Rectangle(params Point[] input) : base(input)
        {
            if (input.Length != 4)
                throw new Exception("Number of points don't correspond with triangle!");
            Console.WriteLine("Rectangle constructor called");
        }

        public override float GetArea()
        {
            throw new NotImplementedException();
        }

        public override float GetCircumference()
        {
            throw new NotImplementedException();
        }
    }
}
