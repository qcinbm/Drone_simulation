/* 
 * This message is auto generated by ROS#. Please DO NOT modify.
 * Note:
 * - Comments from the original code will be written in their own line 
 * - Variable sized arrays will be initialized to array of size 0 
 * Please report any issues at 
 * <https://github.com/siemens/ros-sharp> 
 */

#if ROS2

namespace RosSharp.RosBridgeClient.MessageTypes.Moveit
{
    public class GetPlannerParamsRequest : Message
    {
        public const string RosMessageName = "moveit_msgs/srv/GetPlannerParams";

        //  Name of the planning pipeline, uses default if empty
        public string pipeline_id { get; set; }
        //  Name of planning config
        public string planner_config { get; set; }
        //  Optional name of planning group (return global defaults if empty)
        public string group { get; set; }

        public GetPlannerParamsRequest()
        {
            this.pipeline_id = "";
            this.planner_config = "";
            this.group = "";
        }

        public GetPlannerParamsRequest(string pipeline_id, string planner_config, string group)
        {
            this.pipeline_id = pipeline_id;
            this.planner_config = planner_config;
            this.group = group;
        }
    }
}
#endif
