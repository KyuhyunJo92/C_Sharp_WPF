using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AusnahmenHandling
{
    class Program
    {
        static void Main()
        {
            //A4Test.NachschlagenKellerStack();
            //A4Test.MustThrowOverFlowException();
            //A4Test.MustThrowUntererFlowException();

            //A6Test.WithTryCatchBlock();
            //A6Test.WithoutTryCatchBlock();

            //Aufgabe5.Test();
        }
    }
    class InvalidArgumentException : ApplicationException
    {
        public object argument;
        public object Argument { get { return argument; } }
        public string Range { get; set; }
        public InvalidArgumentException() { }
        public InvalidArgumentException(string msg, object arg) : base(msg) { argument = arg; }
    }
}
