using System;
using Castle.DynamicProxy;
using Logger;

namespace SimpleCalculator
{
	class Program
	{
		static void Main(string[] args)
		{
			var generator = new ProxyGenerator();
			ICalculatorHelper calculatorHelper = generator.CreateInterfaceProxyWithTarget<ICalculatorHelper>(
				new CalculatorHelper(), new LoggerInterceptor());
			ICalculator calculator = generator.CreateInterfaceProxyWithTarget<ICalculator>(
				new Caluclator(calculatorHelper), new LoggerInterceptor());

			while (true)
			{
				Console.WriteLine("Enter expression (e.g. 1 + 4; 5 - 2):");
				string input = Console.ReadLine();
				var output = calculator.Process(input);
				if (output.Success)
				{
					Console.WriteLine("Result: {0}", output.Result);
				}
				else
				{
					Console.WriteLine("Incorrect arguments");
				}
			}
		}
	}
}
