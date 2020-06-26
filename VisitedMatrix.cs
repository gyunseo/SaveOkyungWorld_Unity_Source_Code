using System.Collections;
using System.Collections.Generic;


public class VisitedMatrix
{
    public int[,] Visited = new int[32, 32];//32 by 32

    public VisitedMatrix()
    {
        int i,j;

        for (i = 1; i <= 28; i++)
        {
            for (j = 1; j <= 31; j++)
            {
                Visited[i, j] = 0;//0으로 clear, 방문을 안했으니
            }
        }
    }
        

}
