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
}