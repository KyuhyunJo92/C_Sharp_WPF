using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ein_undAusgebe
{
    class Program
    {
        static void Main()
        {
            BinarySearchTree BST = new BinarySearchTree();

            BST.AddNewNumber(57,"Adam");
            BST.AddNewNumber(29,"Benedikt");
            BST.AddNewNumber(51,"Christian");
            BST.AddNewNumber(78,"Dennis");
            BST.AddNewNumber(2,"Eva");
            BST.AddNewNumber(10,"Frank");
            BST.AddNewNumber(56,"Gregor");
            BST.AddNewNumber(57,"Hans");
            BST.AddNewNumber(51,"Iris");
            try
            {
                Console.WriteLine(BST.SearchNodeFromKey(57).GetValue());
                
            }
            catch (Exception e) { Console.WriteLine("{0}", e.Message); }
            try
            {
                Console.WriteLine(BST.SearchNodeFromKey(29).GetValue());

            }
            catch (Exception e) { Console.WriteLine("{0}", e.Message); }
            try
            {
                Console.WriteLine(BST.SearchNodeFromKey(43).GetValue());

            }
            catch (Exception e) { Console.WriteLine("{0}", e.Message); }
            try
            {
                Console.WriteLine(BST.SearchNodeFromKey(10).GetValue());

            }
            catch (Exception e) { Console.WriteLine("{0}", e.Message); }
            try
            {
                Console.WriteLine(BST.SearchNodeFromKey(78).GetValue());

            }
            catch (Exception e) { Console.WriteLine("{0}", e.Message); }
            
        }
    }
    
}

//Jacop, Kyuhyun, Linda, Mathilda, Nina, O,Phillip,Quentin,Ron,Stefan,Theodor,Ulich,Vanessa,Walter,X,Y,Z