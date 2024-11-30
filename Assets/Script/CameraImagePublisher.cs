using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using RosMessageTypes.Sensor;
using System;

public class CameraImagePublisher : MonoBehaviour
{
    public Camera camera;
    ROSConnection ros;
    public string topicName = "camera_image";
    public int width = 640;
    public int height = 480;

    private Texture2D texture2D;
    private byte[] imageData;

    void Start()
    {
        ros = ROSConnection.instance;
        ros.RegisterPublisher<ImageMsg>(topicName);

        texture2D = new Texture2D(width, height, TextureFormat.RGB24, false);
    }

    void Update()
    {
        // Chụp ảnh từ camera
        RenderTexture renderTexture = new RenderTexture(width, height, 24);
        camera.targetTexture = renderTexture;
        camera.Render();
        RenderTexture.active = renderTexture;

        // Đọc pixel từ RenderTexture vào Texture2D
        texture2D.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        texture2D.Apply();
        camera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        // Chuyển đổi Texture2D thành mảng byte
        imageData = texture2D.GetRawTextureData();

        // Tạo message hình ảnh
        ImageMsg imageMessage = new ImageMsg();
        imageMessage.header.stamp.sec = (int)Time.time;
        imageMessage.header.stamp.nanosec = (uint)((Time.time - (float)Math.Floor(Time.time)) * 1e9);
        imageMessage.height = (uint)height;
        imageMessage.width = (uint)width;
        imageMessage.encoding = "rgb8";
        imageMessage.is_bigendian = 0;
        imageMessage.step = (uint)(width * 3);
        imageMessage.data = imageData;

        // Gửi message
        ros.Send(topicName, imageMessage);
    }
}
