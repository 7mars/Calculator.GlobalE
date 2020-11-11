using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Caching;

namespace Calculator.GlobalE.Logic
{
    public class ExpressionBuilder
    {
        public static IExpression Construct(string s)
        {
            s = OperatorsBuilder.CleanExternalParentheses(s);
            if (float.TryParse(s, out var number))
            {
                return new Number(number);
            }

            var operatorLocation = OperatorsBuilder.FindHighestPriorityOperator(s);
            var lhs = Construct(s.Substring(0, operatorLocation));
            var rhs = Construct(s.Substring(operatorLocation + 1));
            var op = OperatorsBuilder.Construct(s[operatorLocation]);

            return new ComplexExpression(lhs, op, rhs);
        }
    }

    public class ComplexExpression : IExpression
    {
        public ComplexExpression(IExpression lhs, IOperator op, IExpression rhs)
        {
            Lhs = lhs;
            Rhs = rhs;
            Op = op;
        }
        public IExpression Lhs { get; set; }
        public IExpression Rhs { get; set; }
        public IOperator Op { get; set; }
        public float Calculate()
        {
            return Op.Calculate(Lhs.Calculate(), Rhs.Calculate());
        }
    }
}