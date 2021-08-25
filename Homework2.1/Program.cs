using System;


namespace Homework2._1
{
    class Program
    {
        public class TestCaseSimple
        {
            public int X { get; set; }
            public bool Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }
        private static bool Simplenumber(int x, out bool simple) //x - данные подаются на входе
        {
            if (x <= 0)
            {
                throw new ArgumentException("определение простого числа относится только к натуральным числам");
            }
            else if (x == 1)
            {
                throw new ArgumentException("1 - не является ни простым ни сложным числом");
            }

            int d = 0;
            int i = 2;

            while (i < x) //условие i<number
            {
                if (x % i == 0) //условие number%i==0
                {
                    d++;
                }
                i++;
            }
            if (d == 0)         //условие d==0
            {
                //Console.WriteLine("Это простое число.");
                return simple = true;
            }
            else
            {
                //Console.WriteLine("Это не простое число.");
                return simple = false;
            }

        }

        static void TestSimplenumber(TestCaseSimple testcase1)
        {
            try
            {
                var simple1 = Simplenumber(testcase1.X, out bool simple);
                if (simple1 == testcase1.Expected)
                {
                    Console.WriteLine("Valid test");
                }
                else
                {
                    Console.WriteLine("Invalid test");
                }
            }
            catch (Exception ex)
            {
                if (testcase1.ExpectedException != null)
                {
                    Console.WriteLine("Valid test");
                }
                else
                {
                    Console.WriteLine("Invalid test");
                }
            }
        }
        public class TestCaseFibonacci
        {
            public int X { get; set; }
            public int Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }
        static int Fibonacci(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Число должно быть не отрицательным.");
            }
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1 || n == 2)
            {
                return 1;
            }

            return n = Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        static int Fibonacci1(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Число должно быть не отрицательным.");
            }
            if (n == 1 || n == 2)
            {
                return 1;
            }
            else if (n == 0)
            {
                return 0;
            }
            n--;
            int fib3 = 1;
            int fib1 = 0;
            int fib2 = 1;
            for (int i = 0; i < n; n--)
            {
                fib3 = fib1 + fib2;
                fib1 = fib2;
                fib2 = fib3;
            }
            return fib3;
        }

        static void TestFibonacci(TestCaseFibonacci testcaseFibonacci)
        {
            try
            {
                var fib = Fibonacci(testcaseFibonacci.X);
                if (fib == testcaseFibonacci.Expected)
                {
                    Console.WriteLine("Valid test");
                }
                else
                {
                    Console.WriteLine("Invalid test");
                }
            }
            catch
            {
                if (testcaseFibonacci.ExpectedException != null)
                {
                    Console.WriteLine("Valid test");
                }
                else
                {
                    Console.WriteLine("Invalid test");
                }
            }
        }

        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0; //O(1)
            for (int i = 0; i < inputArray.Length; i++)//O(N)
            {
                for (int j = 0; j < inputArray.Length; j++) //O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++) //O(3N)
                    {
                        int y = 0;  //N раз мы приравниваем y к 0

                        if (j != 0) //N раз проходимся по условию
                        {
                            y = k / j;
                        }

                        sum += inputArray[i] + i + k + j + y; //N раз считаем сумму
                    }
                }
            }

            return sum; //O(1)
            // O(StrangerSum) = O(3N^3)  (O(2) можно принебречь)
        }
        static void Main(string[] args)
        {
            var testcaseSimple1 = new TestCaseSimple()
            {
                X = 5,
                Expected = true,
                ExpectedException = null
            };
            var testcaseSimple2 = new TestCaseSimple()
            {
                X = 4,
                Expected = false,
                ExpectedException = new ArgumentException("1 - не является ни простым ни сложным числом")
            };
            var testcaseSimple3 = new TestCaseSimple() //bool simple не присвоено значение. simple != Expected. Invalid
            {
                X = 1,
                Expected = true,
                ExpectedException = null
            };
            var testcaseSimple4 = new TestCaseSimple()
            {
                X = 23,
                Expected = true,
                ExpectedException = null
            };
            var testcaseSimple5 = new TestCaseSimple()// X попадает в исключение, но ExpectedException не null. Valid
            {
                X = 0,
                Expected = true,
                ExpectedException = new ArgumentException("определение простого числа относится только к натуральным числам")
            };
            Console.WriteLine("Test SimpleNumber 1:");
            TestSimplenumber(testcaseSimple1);
            Console.WriteLine("Test SimpleNumber 2:");
            TestSimplenumber(testcaseSimple2);
            Console.WriteLine("Test SimpleNumber 3:");
            TestSimplenumber(testcaseSimple3);
            Console.WriteLine("Test SimpleNumber 4:");
            TestSimplenumber(testcaseSimple4);
            Console.WriteLine("Test SimpleNumber 5:");
            TestSimplenumber(testcaseSimple5);

            var testcaseFibonacci1 = new TestCaseFibonacci()
            {
                X = 10,
                Expected = 55,
                ExpectedException = null
            };
            var testcaseFibonacci2 = new TestCaseFibonacci()
            {
                X = 0,
                Expected = 0,
                ExpectedException = null
            };
            var testcaseFibonacci3 = new TestCaseFibonacci()
            {
                X = -10,
                Expected = 55,
                ExpectedException = new ArgumentException("Число должно быть не отрицательным.")
            };
            var testcaseFibonacci4 = new TestCaseFibonacci()
            {
                X = 1,
                Expected = 1,
                ExpectedException = null
            };
            var testcaseFibonacci5 = new TestCaseFibonacci()
            {
                X = 5,
                Expected = 55,
                ExpectedException = null
            };
            Console.WriteLine("Test Fibbonacci 1:");
            TestFibonacci(testcaseFibonacci1);
            Console.WriteLine("Test Fibbonacci 2:");
            TestFibonacci(testcaseFibonacci2);
            Console.WriteLine("Test Fibbonacci 3:");
            TestFibonacci(testcaseFibonacci3);
            Console.WriteLine("Test Fibbonacci 4:");
            TestFibonacci(testcaseFibonacci4);
            Console.WriteLine("Test Fibbonacci 5:");
            TestFibonacci(testcaseFibonacci5);



            Console.ReadLine();
        }
    }
}
