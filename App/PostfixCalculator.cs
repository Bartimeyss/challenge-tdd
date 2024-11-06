using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    public static class PostfixCalculator
    {
        public static string Calculate(string postfixExpression)
        {
            if (postfixExpression == null) throw new FormatException();
            if (postfixExpression.Length == 0) return "0";
            var postfixExpressionArray = postfixExpression.Split(' ');
            if (postfixExpression.Split(' ').Length == 1)
            {
                if (!(char.IsNumber(postfixExpression[0]) || postfixExpression[0] == '-'))
                {
                    throw new FormatException();
                }
                return postfixExpression;
            }
            
            var stack = new Stack<int>();
            for (var i = 0; i < postfixExpressionArray.Length; i++)
            {
                postfixExpressionArray[i] = postfixExpressionArray[i].Trim();
                if (int.TryParse(postfixExpressionArray[i], out int number))
                {
                    stack.Push(number);
                }
                else
                {
                    if (stack.Count < 2) throw new FormatException();
                    int b = stack.Pop();
                    int a = stack.Pop();
                    switch (postfixExpressionArray[i])
                    {
                        case "+":
                            stack.Push(a + b);
                            break;
                        case "-":
                            stack.Push(a - b);
                            break;
                        case "*":
                            stack.Push(a * b);
                            break;
                        case "/":
                            stack.Push(a / b);
                            break;
                        default:
                            throw new FormatException();
                    }
                }
            }
            if (stack.Count != 1) throw new FormatException();
            return stack.Pop().ToString() ?? "0";
        }
    }
}
