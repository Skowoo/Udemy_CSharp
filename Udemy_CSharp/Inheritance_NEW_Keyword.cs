namespace Udemy_CSharp
{
    static class Inheritance_NEW_Keyword
    {
        //Link do tutoriala - https://learn.microsoft.com/pl-pl/dotnet/csharp/programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords
        public static void PseudoMain()
        {
            BaseClass bc = new BaseClass();
            DerivedClass dc = new DerivedClass();
            BaseClass bcdc = new DerivedClass();

            Console.Write("BaseClass as BaseClass:   ");
            bc.Method1();
            Console.Write("BaseClass as BaseClass:   ");
            bc.Method2();

            Console.Write(Environment.NewLine);

            Console.Write("Derived as Derived:       ");
            dc.Method1();
            Console.Write("Derived as Derived:       ");
            dc.Method2();

            Console.Write(Environment.NewLine);

            Console.Write("BaseClass as Derived:     ");
            bcdc.Method1();
            Console.Write("BaseClass as Derived:     ");
            bcdc.Method2();

            Console.Write(Environment.NewLine);
            Console.Write(Environment.NewLine);

            Derived2 d = new Derived2();
            d.Fun();

            Console.Write(Environment.NewLine);
        }
    }

    class BaseClass
    {
        public virtual void Method1()
        {
            Console.WriteLine("Base - Method1");
        }

        public virtual void Method2()
        {
            Console.WriteLine("Base - Method2");
        }
    }

    class DerivedClass : BaseClass
    {
        public override void Method1()
        {
            Console.WriteLine("Derived - Method1");
        }

        public new void Method2()
        {
            Console.WriteLine("Derived - Method2");
        }
    }

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
}
