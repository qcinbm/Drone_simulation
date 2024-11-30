/* 
 * This message is auto generated by ROS#. Please DO NOT modify.
 * Note:
 * - Comments from the original code will be written in their own line 
 * - Variable sized arrays will be initialized to array of size 0 
 * Please report any issues at 
 * <https://github.com/siemens/ros-sharp> 
 */

#if ROS2

using RosSharp.RosBridgeClient.MessageTypes.BuiltinInterfaces;

namespace RosSharp.RosBridgeClient.MessageTypes.Rosapi
{
    public class GetTimeResponse : Message
    {
        public const string RosMessageName = "rosapi_msgs/srv/GetTime";

        public Time time { get; set; }

        public GetTimeResponse()
        {
            this.time = new Time();
        }

        public GetTimeResponse(Time time)
        {
            this.time = time;
        }
    }
}
#endif
