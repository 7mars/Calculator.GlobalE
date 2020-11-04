using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calculator.GlobalE.Logic
{
    public interface IOperator
    {
        float Calculate(float lhs, float rhs);
    }
}