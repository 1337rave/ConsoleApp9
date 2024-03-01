using System;

class Matrix
{
    private int[,] data;

    // Property for getting the rows of the matrix
    public int Rows
    {
        get { return data.GetLength(0); }
    }

    // Property for getting the columns of the matrix
    public int Columns
    {
        get { return data.GetLength(1); }
    }

    // Indexer for accessing the elements of the matrix
    public int this[int row, int col]
    {
        get { return data[row, col]; }
        set { data[row, col] = value; }
    }

    // Constructor for creating a matrix of a specified size
    public Matrix(int rows, int columns)
    {
        data = new int[rows, columns];
    }

    // Overloading the "+" operator for matrix addition
    public static Matrix operator +(Matrix m1, Matrix m2)
    {
        if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
            throw new ArgumentException("Matrices must have the same dimensions for addition.");

        Matrix result = new Matrix(m1.Rows, m1.Columns);
        for (int i = 0; i < m1.Rows; i++)
        {
            for (int j = 0; j < m1.Columns; j++)
            {
                result[i, j] = m1[i, j] + m2[i, j];
            }
        }
        return result;
    }

    // Overloading the "-" operator for matrix subtraction
    public static Matrix operator -(Matrix m1, Matrix m2)
    {
        if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
            throw new ArgumentException("Matrices must have the same dimensions for subtraction.");

        Matrix result = new Matrix(m1.Rows, m1.Columns);
        for (int i = 0; i < m1.Rows; i++)
        {
            for (int j = 0; j < m1.Columns; j++)
            {
                result[i, j] = m1[i, j] - m2[i, j];
            }
        }
        return result;
    }

    // Overloading the "*" operator for matrix multiplication by a scalar
    public static Matrix operator *(Matrix m, int scalar)
    {
        Matrix result = new Matrix(m.Rows, m.Columns);
        for (int i = 0; i < m.Rows; i++)
        {
            for (int j = 0; j < m.Columns; j++)
            {
                result[i, j] = m[i, j] * scalar;
            }
        }
        return result;
    }

    // Main method
    static void Main(string[] args)
    {
        // Create two matrices
        Matrix matrix1 = new Matrix(2, 2);
        matrix1[0, 0] = 1;
        matrix1[0, 1] = 2;
        matrix1[1, 0] = 3;
        matrix1[1, 1] = 4;

        Matrix matrix2 = new Matrix(2, 2);
        matrix2[0, 0] = 5;
        matrix2[0, 1] = 6;
        matrix2[1, 0] = 7;
        matrix2[1, 1] = 8;

        // Perform matrix operations
        Matrix sum = matrix1 + matrix2;
        Matrix difference = matrix1 - matrix2;
        Matrix scaledMatrix = matrix1 * 2;

        // Print results
        Console.WriteLine("Matrix 1:");
        PrintMatrix(matrix1);

        Console.WriteLine("Matrix 2:");
        PrintMatrix(matrix2);

        Console.WriteLine("Matrix Sum:");
        PrintMatrix(sum);

        Console.WriteLine("Matrix Difference:");
        PrintMatrix(difference);

        Console.WriteLine("Matrix 1 scaled by 2:");
        PrintMatrix(scaledMatrix);
    }

    // Helper method to print the matrix
    static void PrintMatrix(Matrix matrix)
    {
        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Columns; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
