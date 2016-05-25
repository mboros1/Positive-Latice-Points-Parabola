using System;
using System.Collections;
using System.IO;
using System.Linq;
class Solution
{
    // In this problem, we're given two integers, N and K, and we need to
    // count the number of positive integers i such that i*(N-i) <= N*K and i<N.
    // As N and K become very large, running a for loop for all values of
    // i < N becomes very computationally demanding. A much more optimized method
    // is to think about the problem geometrically. If we consider the equation;
    // y = i*(N-i), with i as the dependent variable, we can see that this is a downward
    // facing parabola where y is positive when i > 0 and i < N. Since N and K are fixed,
    // we can think of N*K as a horizontal line with the equation y = N*K
    static void Main(String[] args)
    {
        // keyboard input of the number of test cases to run
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            // next input is 2 numbers separated by a ' ' char, N and K
            string[] a = Console.ReadLine().Split(' ');
            double N = double.Parse(a[0]);
            double K = double.Parse(a[1]);
            int count = 0;

            // the first case is when the line y=N*K is above the maximum point of the parabola,
            // so that every point 0 < i < N is contained in the count
            if (K >= N / 4)
            {
                // the count is N-1 and not N since we are only interested in positive i values, so i=0 is thrown out
                count = (int)N - 1;
            }
            else
            {
                // the value quad is one result of the quadratic equation for when we set i*(Ni-i)=N*K, multiply out the i, 
                // and move the N*K to the left hand side and get; i^2-N*i-N*K=0
                // In this case, the quadratic equation gives the 2 points where the parabola and horizontal line intercept.
                // So, for any value 0 < i <= quad, the inequality i*(N-i) <= N*K is true. We then double this number,
                // since the parabola is symetric along its maximum and the inequality is also true for when
                // quad2 <= i < N, where quad2 would be the second answer to the quadratic equation outlined above.
                double quad = ((-N + Math.Sqrt(N * N - 4.0 * N * K)) / -2.0);
                count = 2 * (int)Math.Floor(quad);
            }
            Console.WriteLine(count);
        }
    }
}
