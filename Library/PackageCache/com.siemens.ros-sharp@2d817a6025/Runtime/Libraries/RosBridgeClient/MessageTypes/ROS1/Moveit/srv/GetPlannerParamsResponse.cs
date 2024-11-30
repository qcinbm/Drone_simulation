/* 
 * This message is auto generated by ROS#. Please DO NOT modify.
 * Note:
 * - Comments from the original code will be written in their own line 
 * - Variable sized arrays will be initialized to array of size 0 
 * Please report any issues at 
 * <https://github.com/siemens/ros-sharp> 
 */

#if !ROS2

namespace RosSharp.RosBridgeClient.MessageTypes.Moveit
{
    public class GetPlannerParamsResponse : Message
    {
        public const string RosMessageName = "moveit_msgs/GetPlannerParams";

        //  parameters as key-value pairs
        public PlannerParams @params { get; set; }

        public GetPlannerParamsResponse()
        {
            this.@params = new PlannerParams();
        }

        public GetPlannerParamsResponse(PlannerParams @params)
        {
            this.@params = @params;
        }
    }
}
#endif
