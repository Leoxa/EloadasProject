using System;

namespace EloadasProject
{
    public class Eloadas
    {
        private bool[,] foglalasok;
        private int sorokSzama;
        private int helyekSzama;

        public Eloadas(int sorokSzama, int helyekSzama)
        {
            if (sorokSzama > 0 && helyekSzama > 0)
            {
                this.sorokSzama = sorokSzama;
                this.helyekSzama = helyekSzama;
                foglalasok = new bool[sorokSzama, helyekSzama];
                for (int i = 0; i < sorokSzama; i++)
                {
                    for (int j = 0; j < helyekSzama; j++)
                    {
                        foglalasok[i, j] = false;
                    }
                }
            }
            else
            {
                throw new ArgumentException("Nem lehet 0");
            }
        }

        public bool Foglal()
        {
            for (int i = 0; i < sorokSzama; i++)
            {
                for (int j = 0; j < helyekSzama; j++)
                {
                    if (foglalasok[i, j] == false)
                    {
                        foglalasok[i, j] = true;
                        return true;
                    }
                }
            }
            return false;
        }

        public int SzabadHelyek
        {
            get
            {
                int osszeg = 0;
                for (int i = 0; i < sorokSzama; i++)
                {
                    for (int j = 0; j < helyekSzama; j++)
                    {
                        if (foglalasok[i, j] == false)
                        {
                            osszeg++;
                        }
                    }
                }
                return osszeg;
            }
        }

        public bool Full()
        {
            return SzabadHelyek == 0;
        }

        public bool Foglalt(int sorSzam, int helySzam)
        {
            if (sorSzam > 0 && helySzam > 0 && sorSzam <= this.sorokSzama && helySzam <= this.helyekSzama)
            {
                return this.foglalasok[sorSzam--, helySzam--];
            }
            else
            {
                throw new ArgumentException("Nem lehet 0");
            }
        }
    }
}
