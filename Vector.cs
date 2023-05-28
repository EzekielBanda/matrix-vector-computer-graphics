using System;
public class Vector
{
    private float x;
    private float y;
    private float z;
    
    //2D Vectors
    public Vector(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    // 3D Vectors
    public Vector(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    //X Component property
    public float XComponent {
        get { return x; }
        set { x = value; }
    }

    //Y Component property
    public float YComponent
    {
        get { return y; }
        set { y = value; }
    }

    // Z Component property
    public float ZComponent
    {
        get {return z;}
        set { z = value; }
    }

    //Vector Addition
    public Vector AddVectors (Vector vector)
    {
        return new Vector (
           XComponent + vector.XComponent,
           YComponent + vector.YComponent,
           ZComponent + vector.ZComponent
        );
    }

    //Vector Subtraction
    public Vector SubtractVectors (Vector vector)
    {
        return new Vector (
            XComponent - vector.XComponent,
            YComponent - vector.YComponent,
            ZComponent - vector.ZComponent
        );
    }

    //Dot Product
    public double DotProduct(Vector vector)
    {
        return XComponent * vector.XComponent +
            YComponent * vector.YComponent +
            ZComponent * vector.ZComponent;
    }

    //Cross Product
    public Vector CrossProduct (Vector vector)
    {
        return new Vector (
            // x = Uy * Vz - Uz * Vy
            YComponent * vector.ZComponent - ZComponent * vector.YComponent,
            // y = Uz * Vx - Ux * Vz
            ZComponent * vector.XComponent - XComponent * vector.ZComponent,
            // z = Ux * Vy - Uy * Vx
            XComponent * vector.YComponent - YComponent * vector.XComponent
            
        );
    }

    //Scalar Multiplication
    public  Vector ScalarMultiplication (Vector vector, float scalarValue)
    {
        return new Vector (
            scalarValue * vector.XComponent,
            scalarValue * vector.YComponent,
            scalarValue * vector.ZComponent
        );
    }

    //Override ToString method
    public override string ToString()
    {
        return $"({XComponent}, {YComponent}, {ZComponent})";
    }

    

    

}