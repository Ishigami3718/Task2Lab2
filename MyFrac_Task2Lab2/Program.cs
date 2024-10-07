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
            long nsd = Evklid(nom, denom);
            this.nom = nom/nsd;
            this.denom = denom/nsd;
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

        /*public string ToStringWithIntegerPart(MyFrac f)
        {

        }*/
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new MyFrac(-15,40));
        }
    }
}