using System;
using System.Collections.Generic;

public class SaddlePoints
{
    private int[,] _array;
    
    public SaddlePoints()
    {
        _array = new int[,]
        { 
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0}
        };
    }
    
    public void SetPoint(int x, int y, int value)
    {
        _array[x,y] = value;
    }
    
    // Saddle point :
    // value >= any in its row
    // value <= any in its column
    public List<Tuple<int,int>> GetSaddlePoints()
    {
        List<Tuple<int,int>> result = new List<Tuple<int,int>>();
        
        int[,] minsEtMaxs = new int[,]
        { 
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0}
        };
        
        // Get maxs of rows and set 1 for them in a matrix
        for(int i = 0; i < 5; i++)
        {
            int[] maxs = GetPositionsOfMaximums(GetRow(i));
            foreach(int max in maxs)
            {
                minsEtMaxs[i, max] = 1;
            }
        }
        
        // get mins of columns and add 1 for them in a matrix
        for(int j = 0; j < 5; j++)
        {
           int[] mins = GetPositionsOfMinimums(GetColumn(j));
            foreach(int min in mins)
            {
                minsEtMaxs[min, j] += 1;
            }
        }
        
        // look for values 2 in the resulting matrix
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                if(minsEtMaxs[i,j] == 2) result.Add(new Tuple<int,int>(i,j));
            }
        }
        
        // Debug
        Console.WriteLine("Work Array :");
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                Console.Write(_array[i,j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("MinsMaxs Array :");
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                Console.Write(minsEtMaxs[i,j] + " ");
            }
            Console.WriteLine();
        }
        
        return result;
    }
    
    private int[] GetRow(int i)
    {
        return new int[] { _array[i,0], _array[i,1], _array[i,2], _array[i,3], _array[i,4] };
    }
    
    private int[] GetColumn(int j)
    {
        return new int[] { _array[0,j], _array[1,j], _array[2,j], _array[3,j], _array[4,j] };
    }
                                               
                                               
    private int[] GetPositionsOfMaximums(int[] row)
    {
        int max = Int32.MinValue;
        List<int> maximumsPositions = new List<int>();
        for(int i = 0; i < row.Length; i++)
        {
            if(row[i] > max)
            {
                max = row[i];
                maximumsPositions.Clear();
                maximumsPositions.Add(i);
            }
            else if(row[i] == max)
            {
                maximumsPositions.Add(i);
            }
        }
        
        return maximumsPositions.ToArray();
    }
    
    private int[] GetPositionsOfMinimums(int[] column)
    {
        int min = Int32.MaxValue;
        List<int> minimumsPositions = new List<int>();
        for(int j = 0; j < column.Length; j++)
        {
            if(column[j] < min)
            {
                min = column[j];
                minimumsPositions.Clear();
                minimumsPositions.Add(j);
            }
            else if(column[j] == min)
            {
                minimumsPositions.Add(j);
            }
        }
        
        return minimumsPositions.ToArray();
    }
    
    
}
