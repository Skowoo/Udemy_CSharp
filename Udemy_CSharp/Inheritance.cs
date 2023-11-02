#pragma warning disable CS0108 // Member hides inherited member; missing new keyword

namespace Udemy_CSharp
{
    public static class Inheritance
    {
        public static void PseudoMain()
        {
            var a = new A();
            var b = new B();
            var c = new C();
            var e = new E();
            Console.WriteLine($"A: {a.Say()}");
            Console.WriteLine($"B: {b.Say()}");
            Console.WriteLine($"C: {c.Say()}");
            Console.WriteLine($"E: {e.Say()}");
        }
    }

    public class A
    {
        // VIRTUAL makes method overrideable, thus itself don't change mechanics
        public virtual string Say() => "A";
    }

    public class B : A
    {
        public override string Say() => "B";
    }

    public class C : B
    {

    }

    public abstract class D
    {
        public abstract string Say();
    }

    public class E : D
    {
        // ABSTRACT method must be OVERRIDE
        public override string Say() => "E";
    }
}

#pragma warning restore CS0108 // Member hides inherited member; missing new keyword