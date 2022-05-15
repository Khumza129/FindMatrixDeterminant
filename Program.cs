// See https://aka.ms/new-console-template for more information
using static System.Console;


//Dimension of the square matrix
int N = 3; //3x3 square matrix

static int findDeterminantOfMatrix(int[, ] mat, int n)
{
    //Initialize result
    int num1, num2, det = 1, index, total = 1;

    //temp array to hold the row
    int[] temp = new int[n + 1];

    //loop to iterate through the diagonal elements
    for(int a = 0; a < n; a++)
    {
        //Initialize index
        index = a;

        //find the index which != 0
        while(mat[index, a] == 0 && index < n)
        {
            index++;
        }
        if(index == n)
        {
            //matrix determinant = 0
            continue;
        }
        if(index != a)
        {
            //swap diagonal elements and index row
            for(int b = 0; b < n; b++)
            {
                sort(mat, index, b, a, b);
            }

            //determinant sign changes when we shift rows go through determinant properties
            det = (int)(det * Math.Pow(-1, index - a));
        }

        //storing the values of diagonal row elements
        for(int c = 0; c < n; c++)
        {
            temp[c] = mat[a, c];
        }

        //iterating rows below the diagonal element
        for(int c = a + 1; c < n; c++)
        {
            num1 = temp[a]; //value of diagonal element
            num2 = mat[c, a]; //value of next row element

            //iterating and multiplating row values
            for(int d = 0; d < n; d++)
            {
                //multiplying to make the diagonal element and next row equal
                mat[c, d] = (num1 * mat[c, d]) - (num2 * temp[d]);
            }
            total = total * num1;
        }        
    }

    /*
    Multiply the diagonal elements
    */
        for(int i = 0; i < n; i++)
        {
            det = det * mat[i, i];
            
        }
        return (det / total);
}
/*Method to perform sorting*/
static int[, ] sort(int[, ] arr, int a, int b, int c, int d)
{
    int temp = arr[a, b];
    arr[a, b] = arr[c, d];
    arr[c, d] = temp;
    return arr;
}

/*Plug in the values to calculate for the 3 x 3 determinant matrix*/
int[, ] mat = {{6, 1, 1},
                {4, -2, 5},
                {2, 8, 7}};


/*Print out the result*/
WriteLine("Determinant of the matrix is : {0}", findDeterminantOfMatrix(mat, N));
