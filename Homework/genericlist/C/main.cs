using System;
using static System.Console;
public class main{
        public static void Main(){
                WriteLine("---------------------------------------------------");
                WriteLine("Demonstating the functionality of the \"chain of node\" implementation:");
                WriteLine("Three integers (1,2,3) are added to the list.");
                WriteLine("Next, they are printed again.\n");
                list<int> a = new list<int>();
                a.push(1);
                a.push(2);
                a.push(3);
                for(a.start(); a.current != null; a.next()){
                        WriteLine(a.current.item);
                } 
                WriteLine("---------------------------------------------------");
        } 
}
