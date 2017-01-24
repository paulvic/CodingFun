namespace CommonProblems
{
    public class Math
    {
        // 3^0=1
        // 3^1=(3^0)*3=3
        // 3^2=((3^0)*3)*((3^0)*3)=9
        // 3^3=((3^0)*3)*((3^0)*3)*3=27
        // 3^4=((3^0)*3)*((3^0)*3)*((3^0)*3)*((3^0)*3)=81
        // 3^-2(3^-1)*(3^-1)=(((3^0)*(3^0)/3)*((3^0)*(3^0))/3)=0.11111111111

        // Time complexity: O(log n) where n is the exponent
        // Space: O(log n) for the storing the result of each recursive call
        public static double Power(double baseNumber, int exponent)
        {
            if (exponent == 0)
            {
                return 1;
            }

            double temp = Power(baseNumber, exponent / 2);
            if (exponent % 2 == 0)
            {
                return temp * temp;
            }
            else
            {
                if (exponent > 0)
                {
                    return baseNumber * temp * temp;
                }
                else
                {
                    return (temp * temp) / baseNumber;
                }
            }
        }

        // n! = n*(n-1)*(n-2)*(n-3)...
        // 0! = 1
        // 1! = 1
        // 2! = 2
        // 3! = 6
        // 4! = 24
        public static int Factorial(int n)
        {
            if (n < 0)
            {
                return -1;
            }

            if (n == 0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}
