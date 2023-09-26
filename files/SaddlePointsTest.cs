using System;
using NUnit.Framework;

[TestFixture]
public class SaddlePointsTest
{
    [Test]
    public void Une_matrice_de_zeros_n_a_pas_de_saddle_points()
    {
        SaddlePoints sp = new SaddlePoints();
        sp.InitFromArray(new Array() 
                         { 
                             {0, 0, 0, 0, 0},
                             {0, 0, 0, 0, 0},
                             {0, 0, 0, 0, 0},
                             {0, 0, 0, 0, 0},
                             {0, 0, 0, 0, 0}
                         });
        
        // a simple example to start you off
        Assert.AreEqual(0, sp.GetSaddlePoints().Count);
    }
}
