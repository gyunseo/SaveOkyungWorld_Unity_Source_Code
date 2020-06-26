using System.Collections;
using System.Collections.Generic;


public class MapMatrix
{
    public static int[,] Map = new int[32, 32];//32 by 32
    
    public void ClearMatrix()
    {
        int i, j;

        for (i = 1; i <= 28; i++)
        {
            for (j = 1; j <= 31; j++)
            {
                Map[i, j] = 0;//0으로 clear
            }
        }
    }

 
    
}
