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
        
        Assert.AreEqual(25, sp.GetSaddlePoints().Count);
    }
    
    [Test]
    public void Une_matrice_avec_une_colonne_incrementielle_a_un_unique_saddle_points()
    {
        SaddlePoints sp = new SaddlePoints();
        
        /*
            {1, 0, 0, 0, 0},
            {2, 0, 0, 0, 0},
            {3, 0, 0, 0, 0},
            {4, 0, 0, 0, 0},
            {5, 0, 0, 0, 0}
        */
        sp.SetPoint(0,0,1);
        sp.SetPoint(0,1,2);
        sp.SetPoint(0,2,3);
        sp.SetPoint(0,3,4);
        sp.SetPoint(0,4,5);
        
        // a simple example to start you off
        Assert.AreEqual(1, sp.GetSaddlePoints().Count);
    }
    
}
