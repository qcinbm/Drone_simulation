/* 
 * This message is auto generated by ROS#. Please DO NOT modify.
 * Note:
 * - Comments from the original code will be written in their own line 
 * - Variable sized arrays will be initialized to array of size 0 
 * Please report any issues at 
 * <https://github.com/siemens/ros-sharp> 
 */

#if ROS2

namespace RosSharp.RosBridgeClient.MessageTypes.Std
{
    public class UInt8 : Message
    {
        public const string RosMessageName = "std_msgs/msg/UInt8";

        //  This was originally provided as an example message.
        //  It is deprecated as of Foxy
        //  It is recommended to create your own semantically meaningful message.
        //  However if you would like to continue using this please use the equivalent in example_msgs.
        public byte data { get; set; }

        public UInt8()
        {
            this.data = 0;
        }

        public UInt8(byte data)
        {
            this.data = data;
        }
    }
}
#endif
