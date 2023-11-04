
namespace Udemy_CSharp
{
    public static class Inheritance
    {
        public static void PseudoMain()
        {
            Console.WriteLine("BMW as BMW:");
            //Object declared and called as BMW call method from derived BMW class!
            BMW bmw = new BMW(300, "blue", "M3");
            bmw.Repair();
            bmw.ShowDetails();

            Console.Write(Environment.NewLine);

            Console.WriteLine("BMW and Audi in foreach from list<Car> (casted):");
            List<Car> cars = new List<Car>() { bmw, new Audi(250, "red", "A5") };
            //List return each object casted as Car class (implicist conversion as items are derived from Car), thus it calls method from CAR class!
            //This can be solved by creating VIRTUAL - OVERRIDE link in the same functions!
            foreach (var car in cars)
            {
                car.Repair();
                car.ShowDetails();
            }

            Console.Write(Environment.NewLine);

            Console.WriteLine("Audi as Audi (no casting):");
            //BMW created as CAR will call car method unless marked as VIRTUAL - OVERRIDEN
            Audi audi = new Audi(300, "gray", "M8");
            audi.ShowDetails();
            audi.Repair();

            Console.Write(Environment.NewLine);

            Console.WriteLine("BMW created as Car:");
            //BMW created as CAR will call car method unless marked as VIRTUAL - OVERRIDEN
            Car bima = new BMW(300, "yellow", "M8");
            bima.ShowDetails();
            bima.Repair();
        }
    }

    #region Cars Example

    class Car
    {
        public string Color { get; set; }

        public int HP { get; set; }

        public Car(int hp, string color)
        {
            HP = hp;
            Color = color;
        }

        public virtual void Repair() => Console.WriteLine("Base virtual: Car was repaired!");

        public void ShowDetails() => Console.WriteLine($"Base        : Power: {HP}, color: {Color}");
    }

    class BMW : Car
    {
        public string Model { get; set; }

        public BMW (int hp, string color, string model) : base (hp, color)
        {
            Model = model;
        }

        public override void Repair() => Console.WriteLine("Deri overrid: BMW {0} was repaired!", Model);

        public void ShowDetails() => Console.WriteLine($"Deri        : Power: {HP}, color: {Color}, Model: {Model}");
    }

    class Audi : Car
    {
        public string Model { get; set; }

        public Audi(int hp, string color, string model) : base(hp, color)
        {
            Model = model;
        }

        public override void Repair() => Console.WriteLine("Deri overrid: Audi {0} was repaired!", Model);

        //NEW keyword sued when you want to mark that method is new,
        //but you don't want to override Base class method when object is called as Base class
        //(f.e. generalized List like in example above)
        public new void ShowDetails() => Console.WriteLine($"Deri new    : Power: {HP}, color: {Color}, Model: {Model}");

    }

    #endregion

    #region Acces Modifiers tricky case

    // ---------------------------------> Default access modifiers at Class level are private. <------------------------------------

    //                  Tricky tricky!!!!
    //Type	                              Default access level
    //class                                      internal
    //struct                                     internal
    //interface                                  internal
    //record                                     internal
    //enum                                       internal
    //interface members                          public
    //class, record, and struct members          private

    //Documentation link - https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers

    //Derived method are not called because they have DEFAULT method modifier - PRIVATE int this case.
    class Baseclass
    {
        public void Fun()
        {
            Console.Write("Base class" + " ");
        }
    }

    class Derived1 : Baseclass
    {
        new void Fun()
        {
            Console.Write("Derived1 class" + " ");
        }
    }

    class Derived2 : Derived1
    {
        new void Fun()
        {
            Console.Write("Derived2 class" + " ");
        }
    }

    //Code for Main:

    //BaseClass bc = new BaseClass();
    //DerivedClass dc = new DerivedClass();
    //BaseClass bcdc = new DerivedClass();

    //Console.Write("BaseClass as BaseClass:   ");
    //        bc.Method1();
    //        Console.Write("BaseClass as BaseClass:   ");
    //        bc.Method2();

    //        Console.Write(Environment.NewLine);

    //        Console.Write("Derived as Derived:       ");
    //        dc.Method1();
    //        Console.Write("Derived as Derived:       ");
    //        dc.Method2();

    //        Console.Write(Environment.NewLine);

    //        Console.Write("BaseClass as Derived:     ");
    //        bcdc.Method1();
    //        Console.Write("BaseClass as Derived:     ");
    //        bcdc.Method2();

    //        Console.Write(Environment.NewLine);
    //        Console.Write(Environment.NewLine);

    //        Derived2 d = new Derived2();
    //d.Fun();

    //        Console.Write(Environment.NewLine);

    #endregion

    #region A B C D example
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword

    //Code for MAIN:
    //var a = new A();
    //var b = new B();
    //var c = new C();
    //var e = new E();
    //Console.WriteLine($"A: {a.Say()}");
    //Console.WriteLine($"B: {b.Say()}");
    //Console.WriteLine($"C: {c.Say()}");
    //Console.WriteLine($"E: {e.Say()}");

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
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    #endregion
}