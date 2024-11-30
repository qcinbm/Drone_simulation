/* 
 * This message is auto generated by ROS#. Please DO NOT modify.
 * Note:
 * - Comments from the original code will be written in their own line 
 * - Variable sized arrays will be initialized to array of size 0 
 * Please report any issues at 
 * <https://github.com/siemens/ros-sharp> 
 */

#if !ROS2

namespace RosSharp.RosBridgeClient.MessageTypes.Rosapi
{
    public class ServicesForTypeRequest : Message
    {
        public const string RosMessageName = "rosapi/ServicesForType";

        public string type { get; set; }

        public ServicesForTypeRequest()
        {
            this.type = "";
        }

        public ServicesForTypeRequest(string type)
        {
            this.type = type;
        }
    }
}
#endif
