using System;
using NUnit.Framework;

namespace MySaddlePoints
{
    [TestFixture]
    public class SaddlePointsTest
    {
        // Saddle point :
        // value >= any in its row
        // value <= any in its column

        [Test]
        public void Une_matrice_de_zeros_n_a_que_des_saddle_points()
        {
            Matrix sp = new Matrix();

            Assert.AreEqual(25, sp.GetSaddlePoints().Count);
        }

        [Test]
        public void Une_matrice_avec_une_colonne_incrementielle_a_un_unique_saddle_points()
        {
            Matrix sp = new Matrix();

            /*
                {1, 0, 0, 0, 0},
                {2, 0, 0, 0, 0},
                {3, 0, 0, 0, 0},
                {4, 0, 0, 0, 0},
                {5, 0, 0, 0, 0}
            */
            sp.SetPoint(0, 0, 1);
            sp.SetPoint(1, 0, 2);
            sp.SetPoint(2, 0, 3);
            sp.SetPoint(3, 0, 4);
            sp.SetPoint(4, 0, 5);

            // a simple example to start you off
            Assert.AreEqual(1, sp.GetSaddlePoints().Count);
        }

        [Test]
        public void Une_matrice_diagonale_a_zero_saddle_points()
        {
            Matrix sp = new Matrix();

            /*
                {1, 0, 0, 0, 0},
                {0, 1, 0, 0, 0},
                {0, 0, 1, 0, 0},
                {0, 0, 0, 1, 0},
                {0, 0, 0, 0, 1}
            */
            sp.SetPoint(0, 0, 1);
            sp.SetPoint(1, 1, 1);
            sp.SetPoint(2, 2, 1);
            sp.SetPoint(3, 3, 1);
            sp.SetPoint(4, 4, 1);

            // a simple example to start you off
            Assert.AreEqual(0, sp.GetSaddlePoints().Count);
        }

    }
}