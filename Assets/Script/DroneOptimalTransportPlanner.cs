using UnityEngine;
using System.Collections.Generic;

public class DroneOptimalTransportPlanner : MonoBehaviour
{
    public Transform startPoint; // Điểm xuất phát
    public Transform endPoint; // Điểm đích
    public List<Transform> obstacles; // Danh sách các chướng ngại vật
    public List<Vector3> pathPoints; // Danh sách các điểm đường đi
    public float speed = 5f; // Tốc độ di chuyển của drone

    private DroneMotionPlanner motionPlanner; // Tham chiếu tới DroneMotionPlanner

    void Start()
    {
        motionPlanner = GetComponent<DroneMotionPlanner>();
        if (motionPlanner == null)
        {
            Debug.LogError("DroneMotionPlanner component not found on the Drone GameObject.");
            return;
        }
        ComputeOptimalPath();
    }

    void ComputeOptimalPath()
    {
        // Bước 1: Xác định các điểm trên lưới không gian (ví dụ: lưới 5x5)
        int gridSize = 5;
        List<Vector3> gridPoints = GenerateGridPoints(gridSize);

        // Bước 2: Tạo ma trận chi phí giữa các điểm
        double[,] costMatrix = CreateCostMatrix(gridPoints, startPoint.position, endPoint.position, obstacles);

        // Bước 3: Định nghĩa supply và demand
        double[] supply = new double[gridSize * gridSize];
        double[] demand = new double[gridSize * gridSize];
        // Giả sử supply ở điểm bắt đầu và demand ở điểm kết thúc
        int startIndex = 0; // Chỉ số điểm bắt đầu trong gridPoints
        int endIndex = gridPoints.Count - 1; // Chỉ số điểm kết thúc trong gridPoints
        supply[startIndex] = 1.0;
        demand[endIndex] = 1.0;

        // Bước 4: Tính toán vận tải tối ưu
        SinkhornOptimalTransport sinkhorn = new SinkhornOptimalTransport(costMatrix, supply, demand);
        sinkhorn.ComputeSinkhorn();

        // Bước 5: Xây dựng đường đi từ ma trận vận tải
        pathPoints = ExtractPath(sinkhorn.TransportMatrix, gridPoints);
        motionPlanner.UpdatePath(pathPoints);
    }

    List<Vector3> GenerateGridPoints(int gridSize)
    {
        List<Vector3> points = new List<Vector3>();
        float spacing = 2.0f; // Khoảng cách giữa các điểm
        Vector3 origin = startPoint.position;
        for(int x = 0; x < gridSize; x++)
        {
            for(int y = 0; y < gridSize; y++)
            {
                Vector3 point = origin + new Vector3(x * spacing, 0, y * spacing);
                points.Add(point);
            }
        }
        return points;
    }

    double[,] CreateCostMatrix(List<Vector3> gridPoints, Vector3 start, Vector3 end, List<Transform> obstacles)
    {
        int n = gridPoints.Count;
        double[,] cost = new double[n, n];
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < n; j++)
            {
                if(i == j)
                {
                    cost[i,j] = 0;
                }
                else
                {
                    // Tính khoảng cách Euclidean giữa hai điểm
                    double distance = Vector3.Distance(gridPoints[i], gridPoints[j]);

                    // Thêm chi phí nếu đường đi bị chặn bởi chướng ngại vật
                    bool blocked = false;
                    foreach(var obstacle in obstacles)
                    {
                        // Kiểm tra xem đường thẳng giữa i và j có cắt qua chướng ngại vật hay không
                        if(Physics.Linecast(gridPoints[i], gridPoints[j], out RaycastHit hit))
                        {
                            if(hit.transform == obstacle)
                            {
                                blocked = true;
                                break;
                            }
                        }
                    }

                    cost[i,j] = blocked ? double.MaxValue / 2 : distance; // Sử dụng giá trị lớn để tránh đường bị chặn
                }
            }
        }
        return cost;
    }

    List<Vector3> ExtractPath(double[,] transportMatrix, List<Vector3> gridPoints)
    {
        List<Vector3> path = new List<Vector3>();
        int n = transportMatrix.GetLength(0);
        // Giả sử bạn bắt đầu từ điểm 0 và kết thúc ở điểm n-1
        path.Add(gridPoints[0]);
        int current = 0;
        while(current != n -1)
        {
            double maxTransport = 0;
            int next = current;
            for(int j = 0; j < n; j++)
            {
                if(transportMatrix[current,j] > maxTransport && transportMatrix[current,j] < double.MaxValue / 2)
                {
                    maxTransport = transportMatrix[current,j];
                    next = j;
                }
            }
            if(next == current)
            {
                Debug.LogWarning("Không tìm thấy đường đi tiếp theo. Có thể môi trường quá phức tạp hoặc đường đi bị chặn.");
                break; // Không thể tiếp tục
            }
            path.Add(gridPoints[next]);
            current = next;
        }
        return path;
    }
}