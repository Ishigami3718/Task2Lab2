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
            return $"{nom}/{denom}";
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}