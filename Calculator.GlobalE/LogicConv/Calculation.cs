using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Calculator.GlobalE.LogicConv
{
    public class Calculation
    {
        public float Calculate(string s)
        {
            var result = CalculateFirstDegree(s);

            return result;
        }

        private float CalculateFirstDegree(string item)
        {
            var numbers = item.Split(OperatorsImplementation.FirstDegree, StringSplitOptions.None).ToArray();
            var operators = Regex.Split(item, @"\d").Where(x => !OperatorsImplementation.SecondDegree.Contains(x)).ToArray();

            float partialResult = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!float.TryParse(numbers[i], out float number))
                {
                    partialResult += CalculateSecondDegree(numbers[i]);
                }
                else
                {
                    if (i == 0)
                    {
                        partialResult += float.Parse(numbers[0]);
                        continue;
                    }
                    if (operators[i - 1] == "+")
                    {
                        partialResult += float.Parse(numbers[i]);
                    }
                    if (operators[i - 1] == "-")
                    {
                        partialResult -= float.Parse(numbers[i]);
                    }
                }
            }
            return partialResult;
        }

        private float CalculateSecondDegree(string s)
        {
            var numbers = s.Split(OperatorsImplementation.SecondDegree, StringSplitOptions.None).ToArray();
            var operators = Regex.Split(s, @"\d").Where(x => x != "").ToArray();

            float partialResult = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == 0)
                {
                    partialResult += float.Parse(numbers[0]);
                    continue;
                }
                if (operators[i -1] == "*")
                {
                    partialResult *= float.Parse(numbers[i]);
                }
                if (operators[i -1] == "/")
                {
                    partialResult /= float.Parse(numbers[i]);
                }

            }
            return partialResult;
        }
    }
}