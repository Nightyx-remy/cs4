/*
 * Author: FORJANIC Rémy
 * Student Number: 511448
 * Description: Reverse Polish Notation Calculator #2
 * Date: 25-06-2022
 */

using Homework4;
using Homework4.mathjs;
using Homework4.operations;
using Homework4.rpn;

var menu = new TextMenu();

var calculator = new RPNCalculator { 
 new Addition(),
 new Subtraction(),
 new Mutliplication(),
 new Division(),
 new Sqrt(),
 new Logarithm(),
 new Constant("pi", "pi", "pi", Math.PI),
 new Constant("euler", "e", "euler's constant", Math.E),
};

var rpn = new RPNEvaluator(calculator, new Parser());

var mathjs = new MathJSEvaluator();


var controller = new Controller(menu, new List<IExpressionEvaluator>{rpn, mathjs});
controller.Run();