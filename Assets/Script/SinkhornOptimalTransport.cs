using System;

public class SinkhornOptimalTransport
{
    public int NumPoints { get; private set; }
    public double[,] CostMatrix { get; private set; }
    public double[] Supply { get; private set; }
    public double[] Demand { get; private set; }
    public double[,] TransportMatrix { get; private set; }

    public SinkhornOptimalTransport(double[,] costMatrix, double[] supply, double[] demand)
    {
        CostMatrix = costMatrix;
        Supply = supply;
        Demand = demand;
        NumPoints = supply.Length;
        TransportMatrix = new double[NumPoints, NumPoints];
    }

    public void ComputeSinkhorn(double epsilon = 0.1, int maxIter = 1000, double tol = 1e-9)
    {
        double[] u = new double[NumPoints];
        double[] v = new double[NumPoints];
        for(int i = 0; i < NumPoints; i++)
        {
            u[i] = 1.0;
            v[i] = 1.0;
        }

        double[,] K = new double[NumPoints, NumPoints];
        for(int i = 0; i < NumPoints; i++)
        {
            for(int j = 0; j < NumPoints; j++)
            {
                // Tránh chia cho 0
                if (CostMatrix[i,j] == double.MaxValue / 2)
                {
                    K[i,j] = 0;
                }
                else
                {
                    K[i,j] = Math.Exp(-CostMatrix[i,j] / epsilon);
                }
            }
        }

        for(int iter = 0; iter < maxIter; iter++)
        {
            // Update u
            for(int i = 0; i < NumPoints; i++)
            {
                double sum = 0.0;
                for(int j = 0; j < NumPoints; j++)
                {
                    sum += K[i,j] * v[j];
                }
                if (sum > 0)
                    u[i] = Supply[i] / sum;
                else
                    u[i] = 0;
            }

            // Update v
            for(int j = 0; j < NumPoints; j++)
            {
                double sum = 0.0;
                for(int i = 0; i < NumPoints; i++)
                {
                    sum += K[i,j] * u[i];
                }
                if (sum > 0)
                    v[j] = Demand[j] / sum;
                else
                    v[j] = 0;
            }

            // Tính toán để kiểm tra hội tụ (optional)
            // Bạn có thể thêm điều kiện dừng dựa trên sự thay đổi của u và v
        }

        // Compute Transport Matrix
        for(int i = 0; i < NumPoints; i++)
        {
            for(int j = 0; j < NumPoints; j++)
            {
                TransportMatrix[i,j] = u[i] * K[i,j] * v[j];
            }
        }
    }
}