namespace SimpleCalculator
{
	public interface ICalculatorHelper
	{
		ParsedInput Parse(string expressin);

		long Sum(int firstArgument, int secondArgument);

		long Subtract(int firstArgument, int secondArgument);
	}
}
