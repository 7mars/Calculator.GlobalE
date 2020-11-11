using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Caching;
using System.Web.UI.WebControls;

namespace Calculator.GlobalE.Logic
{
    public class OperatorsBuilder
    {
        public static Dictionary<char, Tuple<Type, int>> OperatorsRegistry = new Dictionary<char, Tuple<Type, int>>
        {
            {'+', Tuple.Create(typeof(Plus),2) },
            {'-', Tuple.Create(typeof(Minus),2) },
            {'*',  Tuple.Create(typeof(Multiple),1) },
            {'/',  Tuple.Create(typeof(Divide),1) }
        };

        public static Dictionary<char, char> ParenthesesRegistry = new Dictionary<char, char>
        {
            {'(', ')'},
            {'[', ']'},
            {'{', '}'},
        };

        public static Cache RepositoryCache = new Cache();

        public static IOperator Construct(char c) => (IOperator)Activator.CreateInstance(OperatorsRegistry[c].Item1);
        public static string CleanExternalParentheses(string s)
        {
            Stack<char> stack = new Stack<char>();
            while (ParenthesesRegistry.ContainsKey(s[0]))
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (ParenthesesRegistry.ContainsKey(s[i]))
                    {
                        stack.Push(s[i]);
                    }
                    if (ParenthesesRegistry.ContainsValue(s[i]))
                    {
                        if (ParenthesesRegistry[stack.Pop()] != s[i])
                        {
                            throw new Exception("unbalaced brackets");
                        }
                    }
                    if (stack.Count == 0)
                    {
                        if (i == s.Length -1)
                        {
                            s = s.Substring(1, s.Length - 2);
                        }
                        else
                        {
                            return s;
                        }
                    }
                }
            }

            return s;
        }

        public static int FindHighestPriorityOperator(string s)
        {
            int maxPriority = 0;
            int index = -1;
            Tuple<Type, int> currectEntry;
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (ParenthesesRegistry.ContainsKey(s[i]))
                {
                    stack.Push(s[i]);
                }
                if (ParenthesesRegistry.ContainsValue(s[i]))
                {
                    if (ParenthesesRegistry.ContainsValue(s[i]))
                    {
                        if (ParenthesesRegistry[stack.Pop()] != s[i])
                        {
                            throw new Exception("unbalaced brackets");
                        }
                    }
                }
                if (stack.Count == 0 && OperatorsRegistry.TryGetValue(s[i], out currectEntry) && currectEntry.Item2 > maxPriority)
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