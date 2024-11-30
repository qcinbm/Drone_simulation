/* 
 * This message is auto generated by ROS#. Please DO NOT modify.
 * Note:
 * - Comments from the original code will be written in their own line 
 * - Variable sized arrays will be initialized to array of size 0 
 * Please report any issues at 
 * <https://github.com/siemens/ros-sharp> 
 */

#if ROS2

using RosSharp.RosBridgeClient.MessageTypes.Octomap;

namespace RosSharp.RosBridgeClient.MessageTypes.Octomap
{
    public class GetOctomap_Response : Message
    {
        public const string RosMessageName = "octomap_msgs/msg/GetOctomap_Response";

        public Octomap map { get; set; }

        public GetOctomap_Response()
        {
            this.map = new Octomap();
        }

        public GetOctomap_Response(Octomap map)
        {
            this.map = map;
        }
    }
}
#endif
