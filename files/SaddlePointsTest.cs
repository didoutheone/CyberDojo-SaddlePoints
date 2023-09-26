using System;
using NUnit.Framework;

[TestFixture]
public class SaddlePointsTest
{
    // Saddle point :
    // value >= any in its row
    // value <= any in its column
    
    [Test]
    public void Une_matrice_de_zeros_n_a_que_des_saddle_points()
    {
        SaddlePoints sp = new SaddlePoints();
        sp.InitFromArray(new int[,]
                         { 
                             {0, 0, 0, 0, 0},
                             {0, 0, 0, 0, 0},
                             {0, 0, 0, 0, 0},
                             {0, 0, 0, 0, 0},
                             {0, 0, 0, 0, 0}
                         });
        
        // a simple example to start you off
        Assert.AreEqual(25, sp.GetSaddlePoints().Count);
    }
    
}
