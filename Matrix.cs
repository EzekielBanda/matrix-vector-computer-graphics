using System;
public class Matrix
{
    private float[,] entries;

    // 4 x 4 matrix
    public Matrix()
    {
        entries = new float[4, 4];
    }

    public float this[int rows, int columns]
    {
        get { return entries[rows, columns]; }
        set { entries[rows, columns] = value; }
    }

    //Identity Matrix
    public static Matrix GetIdentityMatrix()
    {
        Matrix identityMatrix = new Matrix();
        for (int i = 0; i < 4; i++)
        {
            identityMatrix[i, i] = 1;
        }
        return identityMatrix;
    }

    //Matrix Multiplication
    public static Matrix MultiplyMatrix(Matrix matrixA, Matrix matrixB)
    {
        Matrix multiplicationResult = new Matrix();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int k = 0; k < 4; k++)
                {
                    multiplicationResult[i, j] += matrixA[i, k] * matrixB[k, j];
                }
            }
        }
        return multiplicationResult;
    }

    //Multiplies a matrix and a vector and returns the resulting vector.
    public static Vector MultiplyMatrixAndVector(Matrix matrix, Vector vector)
    {
        // Perform the matrix-vector multiplication.
        float x = matrix[0, 0] * vector.XComponent + 
        matrix[0, 1] * vector.YComponent + 
        matrix[0, 2] * vector.ZComponent + matrix[0, 3];

        float y = matrix[1, 0] * vector.XComponent +
         matrix[1, 1] * vector.YComponent + 
         matrix[1, 2] * vector.ZComponent + matrix[1, 3];

        float z = matrix[2, 0] * vector.XComponent + 
        matrix[2, 1] * vector.YComponent + 
        matrix[2, 2] * vector.ZComponent + matrix[2, 3];

        float w = matrix[3, 0] * vector.XComponent + 
        matrix[3, 1] * vector.YComponent + 
        matrix[3, 2] * vector.ZComponent + matrix[3, 3];

         if (w != 0)
        {
            // Calculate the resulting vector by dividing each component by w.
            return new Vector(x / w, y / w, z / w);
        }
        else
        {
            // Handle the case where w is zero to avoid division by zero.
            throw new InvalidOperationException("Cannot divide by zero.");
        }

    }

    // Returns a rotation matrix for rotating around the Z-axis by the specified angle.
    public static Matrix GetRotationMatrix(float angleAtZ)
    {
        // Convert the angle from degrees to radians.
        float radAngle = (float)(angleAtZ * Math.PI / 180);
        // Create a new matrix and initialize it as an identity matrix.
        Matrix rotationMatrix = GetIdentityMatrix();
        
        // Update the elements in the rotation matrix based on the angle of rotation.
        rotationMatrix[0, 0] = (float)Math.Cos(radAngle);
        rotationMatrix[0, 1] = -(float)Math.Sin(radAngle);
        rotationMatrix[1, 0] = (float)Math.Sin(radAngle);
        rotationMatrix[1, 1] = (float)Math.Cos(radAngle);
          // Return the Rotaion Matrix.
        return rotationMatrix;
    }

    //Scaling Matrix
    public static Matrix GetScalingMatrix(float scaleX, float scaleY, float scaleZ)
    {
        // Create a new matrix and initialize it as an identity matrix.
        Matrix scalingMatrix = GetIdentityMatrix();
        // Update the scaling factors in the matrix.
        scalingMatrix[0, 0] = scaleX;
        scalingMatrix[1, 1] = scaleY;
        scalingMatrix[2, 2] = scaleZ;
          // Return the scaling matrix.
        return scalingMatrix;
    }

    //Translation Matrix
    public static Matrix TranslationMatrix(float xTranslation, float yTranslation, float zTranslation)
    {
        Matrix translationMatrix = GetIdentityMatrix();
        translationMatrix[0, 3] = xTranslation;
        translationMatrix[1, 3] = yTranslation;
        translationMatrix[2, 3] = zTranslation;
        return translationMatrix;
    }

    //Calculate Matrix Inverse
    public static Matrix GetMatrixInverse(Matrix matrix)
    {
        float determinant = GetDeterminant(matrix);
        if (determinant == 0)
            throw new InvalidOperationException("Matrix is not invertible.");

        Matrix inverseMatrix = new Matrix();
        for (int row = 0; row < 4; row++)
        {
            for (int column = 0; column < 4; column++)
            {
                float cofactor = GetCofactor(matrix, row, column);
                inverseMatrix[column, row] = cofactor / determinant;
            }
        }

        return inverseMatrix;
    }

    //Calculate Determinat
    private static float GetDeterminant(Matrix matrix)
    {
        float determinant = 0;
        for (int column = 0; column < 4; column++)
        {
            float cofactor = GetCofactor(matrix, 0, column);
            determinant += matrix[0, column] * cofactor;
        }
        return determinant;
    }

    //Calculate Cofactor
    private static float GetCofactor(Matrix matrix, int row, int column)
    {
        int resutSign = (row + column) % 2 == 0 ? 1 : -1;
        float matrxMinor = GetMatrixMinor(matrix, row, column);
        return resutSign * matrxMinor;
    }

    //Calculate Matrix Minor
    private static float GetMatrixMinor(Matrix matrix, int row, int column)
    {
        float[,] newMatrix = new float[3, 3];
        int subRow = 0;
        for (int i = 0; i < 4; i++)
        {
            if (i == row)
                continue;

            int subCol = 0;
            for (int j = 0; j < 4; j++)
            {
                if (j == column)
                    continue;

                newMatrix[subRow, subCol] = matrix[i, j];
                subCol++;
            }
            subRow++;
        }

        return newMatrix[0, 0] * (newMatrix[1, 1] * newMatrix[2, 2] - 
            newMatrix[1, 2] * newMatrix[2, 1]) -
            newMatrix[0, 1] * (newMatrix[1, 0] * newMatrix[2, 2] - 
            newMatrix[1, 2] * newMatrix[2, 0]) +
            newMatrix[0, 2] * (newMatrix[1, 0] * newMatrix[2, 1] - 
            newMatrix[1, 1] * newMatrix[2, 0]);
    }

    public override string ToString()
    {
        string matrixString = "";
        for (int row = 0; row < 4; row++)
        {
            for (int column = 0; column < 4; column++)
            {
                matrixString += entries[row, column] + "\t";
            }
            matrixString += "\n";
        }
        return matrixString;
    }
}