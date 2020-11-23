using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calculator.GlobalE.LogicConv
{
    public class OperatorsImplementation
    {
        public static string[] FirstDegree => new[] { "+", "-","" };
        public static string[] SecondDegree => new[] { "*", "/","" };

        public static float Plus(float a, float b) => a + b;
        public static float Minus(float a, float b) => a - b;
        public static float Multiple(float a, float b) => a * b;
        public static float Divide(float a, float b) => a / b;

    }

}