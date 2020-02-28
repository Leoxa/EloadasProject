using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EloadasProject.Tests
{
    [TestFixture]
    class EloadasTest
    {
        Eloadas eloadas;

        [SetUp]
        public void SetUp()
        {
            eloadas = new Eloadas(10, 10);
        }


        [TestCase]
        public void Helyekszamacsokkenfoglalakor()
        {
            eloadas.Foglal();
            Assert.AreEqual(99, eloadas.SzabadHelyek, "Nem csökkentek a szabad helyek");
        }

        [TestCase]
        public void UjEloadas()
        {
            Assert.AreEqual(100, eloadas.SzabadHelyek, "Hibás a szabad helyek száma");
        }
        [TestCase]
        public void UresEloadas()
        {
            Assert.IsFalse(eloadas.Full(), "Nem üres az előadás");
        }

        [TestCase]
        public void TeliEloadas()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    eloadas.Foglal();
                }
            }
            Assert.IsTrue(eloadas.Full(), "Tele van az előadás");
        }

        [TestCase]
        public void NemLehetNegativ()
        {
            Assert.Throws<ArgumentException>(() =>{var eloadas = new Eloadas(-2, -2);});
        }

        [TestCase]
        public void NemLehetKevesebb()
        {
            Assert.Throws<ArgumentException>(() => {eloadas.Foglalt(0, 0);});
        }

        [TestCase]
        public void NemLehetTobbAMegadottMennyisegnel()
        {
            Assert.Throws<ArgumentException>(() =>{eloadas.Foglalt(11, 11);});
        }
    }
}
