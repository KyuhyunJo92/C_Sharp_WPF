using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceVsAbstractClass
{
    class Program
    {
        static void Main(string[] args)
        {
            ITest1 obj = new ImplementationClass();
            obj.SampleMethod();
            ITest2 obj3 = new ImplementationClass();
            obj.SampleMethod();
            ImplementationClass obj4 = new ImplementationClass();
            (obj4 as ITest2).SampleMethod();

            //Interface can not be Instantiated.
            //ITest1 obj2 = new ITest1();

            //Abstract Class can not be instantiated/
            //ATest1 obj2 = new ATest1();

            ATest1 obj2 = new erweiterungClass();
            obj2.AMethod1();

            obj2.AMethod2();
        }
    }
    public interface ITest1
    {
        void SampleMethod();//body kann nicht implentiert wird
        
    }
    public interface ITest2
    {
        void SampleMethod();//body kann nicht implentiert wird

    }
    class ImplementationClass : ITest1, ITest2
    {
        void ITest1.SampleMethod()
        {
            Console.WriteLine("etwas tun11");
        }
        void ITest2.SampleMethod()
        {
            Console.WriteLine("etwas tun22");
        }
    }
    public abstract class ATest1
    {
        public virtual void AMethod1()
        {
            Console.WriteLine("ATest1.AMethod1()");
        }
        public abstract void AMethod2();

    }

    class erweiterungClass : ATest1
    {
        
        public override void AMethod2()
        {
            Console.WriteLine("Realized Memory.");
        }
    }


}
