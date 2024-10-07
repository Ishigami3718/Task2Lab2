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
            if(nom<0 || denom < 0)
                return $"-({Math.Abs(nom)}/{Math.Abs(denom)})";
            else if(nom < 0 && denom < 0)
                return $"{Math.Abs(nom)}/{Math.Abs(denom)}";
            else
                return $"{nom}/{denom}";
        }

        public string ToStringWithIntegerPart()
        {
            if (this.ToString()[0] == '-')
                return $"-({nom/denom}+{nom%denom/denom})";
            else
                return $"{nom / denom}+{new MyFrac(nom % denom, denom)}";
        }

        public double DoubleValue()
        {
            return nom/denom;
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

        static MyFrac CalcSum1(int n)
        {
            MyFrac res = new MyFrac(0,1);
            for(int i = 0; i < n; i++)
            {
                res += new MyFrac(1, i * (i + 1));
            }
            return res;
        }

        static MyFrac CalcSum2(int n)
        {
            MyFrac res = new MyFrac(1, 1);
            for (int i = 0; i < n; i++)
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
            
        }
    }
}