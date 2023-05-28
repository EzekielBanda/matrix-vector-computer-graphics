using System;
namespace Ezekiel_BSC_COM_10_19;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("\nEnter the Z axis rotation angle (in degrees): ");
            //
            float rotationAngle = float.Parse(Console.ReadLine() ?? "0.0");
            // Rotation Matrix
            Matrix rotationMatrix = Matrix.GetRotationMatrix(rotationAngle);
            Console.WriteLine("Rotation Matrix:");
            Console.WriteLine(rotationMatrix);

            Console.WriteLine("\nEnter the vector to be rotated (format: x y z):");
            /*
            The null-conditional operator (?.) is used to invoke the Split().
            the null-coalescing operator (??) is used to provide an alternative value of Array.Empty<string>()
            if the result of the Split() operation is nul
            */
            string[] vectorComponents = (Console.ReadLine()?.Split(' ')) ?? Array.Empty<string>();

            float vectorX = float.Parse(vectorComponents[0]);
            float vectorY = float.Parse(vectorComponents[1]);
            float vectorZ = float.Parse(vectorComponents[2]);

            //Create the Vector
            Vector vector = new Vector(vectorX, vectorY, vectorZ);
            Console.WriteLine("\nOriginal Vector:");
            Console.WriteLine(vector);

            // Vector rotatedVector = rotationMatrix * vector;
            Vector rotatedVector = Matrix.MultiplyMatrixAndVector(rotationMatrix, vector);
            Console.WriteLine("Rotated Vector:");
            Console.WriteLine(rotatedVector);

            Console.WriteLine("Enter the scaling factors (format: Sx Sy Sz):");
            /*
            The null-conditional operator (?.) is used to invoke the Split().
            the null-coalescing operator (??) is used to provide an alternative value of Array.Empty<string>()
            if the result of the Split() operation is nul
            */
            string[] scalingFactors = (Console.ReadLine()?.Split(' ')) ?? Array.Empty<string>();
            float xUnits = float.Parse(scalingFactors[0]);
            float yUnits = float.Parse(scalingFactors[1]);
            float zUnits = float.Parse(scalingFactors[2]);

            // Scaling Matrix
            Matrix scalingMatrix = Matrix.GetScalingMatrix(xUnits, yUnits, zUnits);
            Console.WriteLine("Scaling Matrix:");
            Console.WriteLine(scalingMatrix);

            // Matrix combinedMatrix = scalingMatrix * rotationMatrix;
            Matrix combinedMatrix = Matrix.MultiplyMatrix(scalingMatrix, rotationMatrix);
            Console.WriteLine("Combined Transformation Matrix:");
            Console.WriteLine(combinedMatrix);
    }
}
