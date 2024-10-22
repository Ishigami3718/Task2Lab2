using System;
namespace Lab
{
    class MyFrac
    {
        private long nom, denom;

        private long Evklid(long f,long s)
        {
            while (s!=0)
            {
                long temp = s;
                s = f % s;
                f = temp;
            }
            return f;
        }
        public MyFrac(long nom, long denom)
        {
            if (denom == 0) throw new Exception("denom is zero");
            long nsd = Evklid(nom, denom);
            this.nom = nom/nsd;
            this.denom = denom/nsd;
        }

        public long Nom
        {
            get
            {
                return nom;
            }
            set
            {
                    nom = value;
            }
        }

        public long Denom
        {
            get
            {
                return denom;
            }
            set
            {
                if (value != 0)
                {
                    denom = value;
                }
            }
        }
        public override string ToString()
        {
            if (nom == 0) return "0";
            else if(nom<0 || denom < 0)
                return $"-({Math.Abs(nom)}/{Math.Abs(denom)})";
            else if(nom < 0 && denom < 0)
                return $"{Math.Abs(nom)}/{Math.Abs(denom)}";
            else
                return $"{nom}/{denom}";
        }

        public string ToStringWithIntegerPart()
        {
            long newnom = nom % denom;
            string res = "";
            if (newnom == 0)
            {
                res = $"{Math.Abs(nom / denom)}";
            }
            else res = $"{Math.Abs(nom / denom)}+{new MyFrac(Math.Abs(newnom),Math.Abs(denom))}";
            if (this.ToString()[0] == '-')
                return $"-({res})";
            else
                return res;
        }

        public double DoubleValue()
        {
            return (double)nom/denom;
        }

        public static MyFrac operator +(MyFrac f1,MyFrac f2)
        {
            return new MyFrac(f1.nom*f2.denom + f2.nom*f1.denom, f1.denom * f2.denom);
        }

        public static MyFrac operator -(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom - f2.nom * f1.denom, f1.denom * f2.denom);
        }

        public static MyFrac operator *(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.nom, f1.denom * f2.denom);
        }

        public static MyFrac operator /(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom, f1.denom * f2.nom);
        }

        public static MyFrac CalcSum1(int n)
        {
            MyFrac res = new MyFrac(0,1);
            for(int i = 1; i <= n; i++)
            {
                res += new MyFrac(1, i * (i + 1));
            }
            return res;
        }

        public static MyFrac CalcSum2(int n)
        {
            MyFrac res = new MyFrac(1, 1);
            for (int i = 2; i <= n; i++)
            {
                res *= new MyFrac(1,1)-new MyFrac(1,i*i);
            }
            return res;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть дріб");
            string[] inp = Console.ReadLine().Split('/');
                MyFrac mf = new MyFrac(long.Parse(inp[0]), long.Parse(inp[1]));
                Console.WriteLine("Виведення дробу");
                Console.WriteLine(mf);
                Console.WriteLine("Виведення дробу з цілою частиною");
                Console.WriteLine(mf.ToStringWithIntegerPart());
                Console.WriteLine("Десятковий дріб");
                Console.WriteLine(mf.DoubleValue());
                Console.WriteLine("Введіть другий дріб для операцій");
                string[] inp1 = Console.ReadLine().Split('/');
                MyFrac mf1 = new MyFrac(long.Parse(inp1[0]), long.Parse(inp1[1]));
                Console.WriteLine("Додавання");
                Console.WriteLine(mf + mf1);
                Console.WriteLine("Віднімання");
                Console.WriteLine(mf - mf1);
                Console.WriteLine("Множення");
                Console.WriteLine(mf * mf1);
                Console.WriteLine("Ділення");
                Console.WriteLine(mf / mf1);
                Console.WriteLine("Введіть число для обрахуваня сум");
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine("Перша сума");
                Console.WriteLine(MyFrac.CalcSum1(n));
                Console.WriteLine("Друга сума");
                Console.WriteLine(MyFrac.CalcSum2(n));
        }
    }
}