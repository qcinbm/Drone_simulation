using UnityEngine;
using System.Collections.Generic;

public class DroneMotionPlanner : MonoBehaviour
{
    public List<Vector3> pathPoints = new List<Vector3>(); // Danh sách các điểm đường đi
    public float speed = 5f; // Tốc độ di chuyển của drone
    private int currentPoint = 0; // Chỉ số điểm hiện tại trên đường đi

    void Update()
    {
        MoveAlongPath();
    }

    // Hàm để di chuyển drone theo đường đi
    private void MoveAlongPath()
    {
        if (currentPoint >= pathPoints.Count)
            return; // Đã đến điểm cuối

        Vector3 target = pathPoints[currentPoint];
        Vector3 direction = target - transform.position;
        float step = speed * Time.deltaTime;

        if (direction.magnitude < step)
        {
            transform.position = target;
            currentPoint++;
        }
        else
        {
            transform.Translate(direction.normalized * step, Space.World);
        }
    }

    // Hàm để cập nhật đường đi từ kết quả Optimal Transport
    public void UpdatePath(List<Vector3> newPath)
    {
        pathPoints = newPath;
        currentPoint = 0;
    }
}