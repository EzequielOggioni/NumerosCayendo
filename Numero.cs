using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumerosCayendo
{
    public class Numero
    {
        public static int maxY;
        public static Random random;

        private int y;

        private int x;

        private int valor;

        public int Valor
        {
            get { return valor; }
        }


        public int X
        {
            get { return x; }

        }


        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        static Numero()
        {
            random = new Random(DateTime.Now.Millisecond);
        }

        public Numero(int x)
        {
            this.x = x;
            this.y = 0;
            this.valor = random.Next(0, 9);

        }

        public void mover()
        {
            if (Numero.maxY > this.y + 1)
                this.y++;
            else
                throw new NumeroPerdidoException();
        }

        public static bool operator ==(Numero num, int valor)
        {
            return num.valor == valor;
        }

        public static bool operator !=(Numero num, int valor)
        {
            return !(num == valor);
        }


        public override bool Equals(object obj)
        {
            if (obj is int)
                return this == (int)obj;
            if (obj is Numero)
                return this == ((Numero)obj).valor;
            else
                return false;
        }
    }
}
