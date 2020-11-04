using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calculator.GlobalE.Logic
{
    public interface IExpression
    {
        float Calculate();
    }
}