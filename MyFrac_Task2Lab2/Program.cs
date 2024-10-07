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
                if (value!=0) 
                {
                    nom = value;
                }
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

        public string ToStringWithIntegerPart(MyFrac f)
        {
            if (f.ToString()[0] == '-')
                return $"-({f.nom/f.denom}+{f.nom%f.denom/f.denom})";
            else
                return $"{f.nom / f.denom}+{new MyFrac(f.nom % f.denom, f.denom)}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine((new MyFrac(17,7).ToStringWithIntegerPart(new MyFrac(17, 7))));
        }
    }
}