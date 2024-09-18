//https://projecteuler.net/problem=15

int size = 10;
int[,] grid = new int[size, size];

int stopRow = 1;
int currRow = 0;
int currCol = size;
int tempCol = 0;

for (int i = size; i > 0; i--)
{
    
    for (int j = 0; j < i; j++)
    {
        //Console.Write(j + " ");
        grid[currRow, j] = 1;

        if (j == currCol-1)
        {
            for (int k = 0; k < size; k++) 
            {
                grid[k, currCol-1] = 1;
                //if (currCol-2 == k)
                //{
                //    currCol++;
                //}
                //Console.WriteLine(stopRow + " J " + j + " K " + k);
                //Console.WriteLine(k);
                if (k == ) 
                {
                    //Console.WriteLine($"k: {k} | j: {j} | currCol {currCol}");
                    stopRow++;
                    tempCol = currCol;
                    currCol++;
                }

            }
            currCol = tempCol;
            currCol--;
        }

    }
    printRowNColumn(); 
    Array.Clear(grid);
}

void printRowNColumn()
{
    //for (int h = 0; h < size; h++)
    //{
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            Console.Write("Row {0} ", i); // Outside of the loop :)
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                Console.Write(string.Format("{0,6} ", grid[i, j]));
            }
            Console.Write("\n" + "\n");
        }
        Console.WriteLine();

    //}
}



