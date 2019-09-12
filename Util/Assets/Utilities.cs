    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static string ProcessText(string input)
    {
        //determine if input is num or string, return word if string return number if num.


        //  float number;
        // int counter = 0;
        // int SIZE = input.Length;

        //char[] characters = new char[SIZE]; 

            
        foreach (char c in input)
        {
            //   characters = input[counter];

            if (char.IsLetter(c))
            {
                // float numbers[] = 
                //  foreach (float)

                // counter++;
                return ($"{c} is a string");
            }
            else
            {

                return ($"{c} is a number");
            }

        }
        return "d";


    }

    public static string AverageChars(string input)
    {
        int len = 0;
        int count = 0;
        string[] words = input.Split();

        foreach (var word in words)
        {
            len += word.Length;


            count++;
            Debug.Log("Num of words: "+count+ " Length: " + len);     
                
          }

        return (len/count).ToString();

    }
}
//---------------------------------------------------------------------------------------------------------------
//SECTION 6 SECTION 6 SECTION 6 SECTION 6 SECTION 6 SECTION 6 SECTION 6 SECTION 6 SECTION 6 SECTION 6 SECTION 6 
//Chapter 22 C# Crash Course
//---------------------------------------------------------------------------------------------------------------
//Structures are like templates.
struct Point2D
{
    public int X;
    public int Y;

}
//Declaring a new point using the Point2D structure (template)
Point2D myPoint = new Point2D();
myPoint.X = 10;
    myPoint.Y = 20;
}
//Difference between classes and structures show up in how memory is collected, 
//structures (memory is reclaimed when variable a variable goes out of scope)
//classes (class objects are collected when there are no more references to them)

//Inheritance allows objects to use the same base class with separate object based properties/methods

class Person
{
    public string Name;
    //virtual allows the method to be overridden
    public virtual void SayHello()
    {
        Console.WriteLine("Hello");
    }
}

//class RenFairePerson extends/inherits the Person's class methods and overrides the SayHello() method with its own logic
class RenFairePerson : Person
{
    public override void SayHello()
    {
        Console.Write("Huzzah!");
        //Allows the calling of the superclass's original method
        base.SayHello();
    }
}
//-----------------------------------------------------------------
//Chapter 23 Unity API
//-----------------------------------------------------------------