using System;
using System.Collections.Generic;

public class SaddlePoints
{
    private int[,] _array = new int [5,5];
    
    public void InitFromArray(int[,] initArray)
    {
    }
    
    public List<Tuple<int,int>> GetSaddlePoints()
    {
        List<Tuple<int,int>> result = new List<Tuple<int,int>>();
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                result.Add(new Tuple<int,int>(i,j));
            }
        }
    }
}
