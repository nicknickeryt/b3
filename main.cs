using System;
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;

namespace B1
 {
    class Program
    {
        static void Main(string[] args) {
            //Wywolania wszystkich funkcji z zadania
            Console.WriteLine("Zadanie B3");
            Console.WriteLine(FourArgsFx(1,2,3,4));
            Console.WriteLine(DoubleFx(1,2));
            Console.WriteLine(BoolFx("a", "b"));
            Console.WriteLine(StringFx("a", "b"));
            Console.WriteLine(DummyFx());
            Console.WriteLine(SphereAreaFx(2));
            Console.WriteLine(SphereVolumeFx(4));
            RecursiveFx("pacman");



            Console.WriteLine(Solution(1,3,-4));

            Console.WriteLine(SumNumbers(40));

            //Console.WriteLine(CountSolutions(25, 5));
            Console.WriteLine(CountSolutions(25, 5));
        }

        //A. (1 pkt) Dowolna funkcja przyjmująca cztery argumenty.
        static int FourArgsFx(int a, int b, int c, int d) {
            return 0;
        }

        //B. (1 pkt) Dowolna funkcja o sygnaturze double NazwaFunkcji(double, double).
        static double DoubleFx(double a, double b) {
            return 0;
        }

        //C. (1 pkt) Dowolna funkcja o sygnaturze bool NazwaFunkcji(string, string).
        static bool BoolFx(string a, string b) {
            return true;
        }

        //C. (1 pkt) Dowolna funkcja o sygnaturze bool NazwaFunkcji(string, string).
        static string StringFx(string a, string b) {
            return "dummy";
        }

        //E. (2 pkt) Dowolne dwie funkcje, z których jedna wywołuje w środku drugą oraz wykorzystuje do czegoś wynik.
        static string DummyFxHelper() {
            return "man";
        }

        static string DummyFx() {
            return "pac" + DummyFxHelper();
        }

        //F. (2 pkt) Zestaw dwóch funkcji obliczających pole powierzchni i objętość dla wybranej bryły geometrycznej.
        static double SphereVolumeFx(double r) {
            return (float) 4/3*Math.PI*r*r*r;
        }

        static double SphereAreaFx(double r) {
            return 4*Math.PI*r*r;
        }

        //G. (3 pkt) Dowolna funkcja wykorzystująca do czegoś rekurencję, inna niż przykład z instrukcji.
        static void RecursiveFx(string s) {
            string write = "";
            foreach(char c in s) {
                write+=c;
                Console.WriteLine(write);
            }
        }

        //H. (3 pkt) Funkcja double Solution(double a, double b, double c), która zwróci dowolne
        //rozwiązanie równania kwadratowego ax2 + bx + c = 0. Jeżeli równanie nie ma
        //rzeczywistych rozwiązań, należy zwrócić wartość Double.NaN (skrót od Not a
        //Number).
        static double Solution(double a, double b, double c) {
            double delta = b*b - 4*a*c;
            if(delta < 0) {
                return Double.NaN;
            }
            
            //Dalej potrzebny jedynie pierwiastek z delty
            delta = Math.Sqrt(delta);

            
            //Na pewno jest co najmniej jedno rozw. Array rozwiazan:
            double[] sol = new double[2];
            sol[0] = (-b - delta)/2*a;
            //Jesli delta wieksza od 0 rozwazamy drugie rozw.
            if (delta > 0) {
                sol[1] = (-b + delta)/2*a;
            }
            foreach(double d in sol) {
                Console.WriteLine("rozw.: " + d);
            }
            //Zwraca dowolne rozwiazanie
            return sol[0];
        }

        //I. (4 pkt) Funkcja sumująca liczby od 1 do 40 podzielne przez 7, używająca rekurencji.
        //Odpowiedź: 105.
        static int SumNumbers(int n) {
            n = n - n%7;
            if(n <= 1) return 0;
            return n + SumNumbers(n-1);
        }

        //J. (6 pkt) Funkcja int CountSolutions(int sum, int n), która zwróci liczbę możliwych
        // rozwiązań równania x1 + x2 + x3 + … + xn = sum , gdzie wszystkie xi są dodatnimi
        // liczbami naturalnymi. Rozwiązanie musi opierać się na rekurencji. Jako przypadku
        // testowego proszę użyć sum = 25, n = 5 (odpowiedź: 10 626).

        // x + y + z = 5
        // x + y = 4
        // x = 3 (1 rozw?)       // x = {0,1,2,3,4,5}
        // 0 = 2 (x)
        // 0 = 1 (x)
        // 0 = 0 (okej)

        // x = 2
        // 0 = 1
        // x + y = 3
        // x + y = 2
        // x + y = 1
        // x + y = 0 (1 rozw)


        // TODO INSPECT THAT XDD
        static int CountSolutions(int sum, int n) {
            //Console.WriteLine("sum: " + sum + " n: " + n);

        if(sum <0 || n <0) return 0;

        if(n == 0 && sum == 0) {
            //Console.WriteLine("found! +1");
            return 1;
        }

        int totalCount = 0;
        for(int i = 1; i<=sum; i++) { 
            totalCount += CountSolutions(sum-i, n-1);
        }

        return totalCount;
        }
    }
 }
