using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calculator.GlobalE.Logic
{
    public class OperatorsBuilder
    {
        public static Dictionary<char, Tuple<Type,int>> OperatorsRegistry = new Dictionary<char, Tuple<Type, int>>
        {
            {'+', Tuple.Create(typeof(Plus),2) },
            {'-', Tuple.Create(typeof(Minus),2) },
            {'*',  Tuple.Create(typeof(Multiple),1) },
            {'/',  Tuple.Create(typeof(Divide),1) }
        };

        public static IOperator Construct(char c) => (IOperator)Activator.CreateInstance(OperatorsRegistry[c].Item1);

        public static int FindHighestPriorityOperator(string s)
        {
            int maxPriority = 0;
            int index = -1;
            Tuple<Type, int> currectEntry;
            for (int i = 0; i < s.Length; i++)
            {
                if (OperatorsRegistry.TryGetValue(s[i], out currectEntry) && currectEntry.Item2 > maxPriority)
                {
                    maxPriority = currectEntry.Item2;
                    index = i;
                }
            }
            if (index == -1)
            {
                throw new Exception("Operator not found.");

            }
            return index;
        }
    }
    public class Plus : IOperator
    {
        public float Calculate(float lhs, float rhs)
        {
            return lhs + rhs;
        }
    }

    public class Minus : IOperator
    {
        public float Calculate(float lhs, float rhs)
        {
            return lhs - rhs;
        }
    }

    public class Multiple : IOperator
    {
        public float Calculate(float lhs, float rhs)
        {
            return lhs * rhs;
        }
    }

    public class Divide : IOperator
    {
        public float Calculate(float lhs, float rhs)
        {
            return lhs / rhs;
        }
    }
}