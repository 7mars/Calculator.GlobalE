using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calculator.GlobalE.Logic
{
    public class Number : IExpression
    {
        public Number(float number)
        {
            Value = number;
        }
        public float Value { get; set; }
        public float Calculate()
        {
            return Value;
        }
    }
}