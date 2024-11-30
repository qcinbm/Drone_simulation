/* 
 * This message is auto generated by ROS#. Please DO NOT modify.
 * Note:
 * - Comments from the original code will be written in their own line 
 * - Variable sized arrays will be initialized to array of size 0 
 * Please report any issues at 
 * <https://github.com/siemens/ros-sharp> 
 */

#if !ROS2

using RosSharp.RosBridgeClient.MessageTypes.Moveit;

namespace RosSharp.RosBridgeClient.MessageTypes.Moveit
{
    public class MoveGroupResult : Message
    {
        public const string RosMessageName = "moveit_msgs/MoveGroupResult";

        //  An error code reflecting what went wrong
        public MoveItErrorCodes error_code { get; set; }
        //  The full starting state of the robot at the start of the trajectory
        public RobotState trajectory_start { get; set; }
        //  The trajectory that moved group produced for execution
        public RobotTrajectory planned_trajectory { get; set; }
        //  The trace of the trajectory recorded during execution
        public RobotTrajectory executed_trajectory { get; set; }
        //  The amount of time it took to complete the motion plan
        public double planning_time { get; set; }

        public MoveGroupResult()
        {
            this.error_code = new MoveItErrorCodes();
            this.trajectory_start = new RobotState();
            this.planned_trajectory = new RobotTrajectory();
            this.executed_trajectory = new RobotTrajectory();
            this.planning_time = 0.0;
        }

        public MoveGroupResult(MoveItErrorCodes error_code, RobotState trajectory_start, RobotTrajectory planned_trajectory, RobotTrajectory executed_trajectory, double planning_time)
        {
            this.error_code = error_code;
            this.trajectory_start = trajectory_start;
            this.planned_trajectory = planned_trajectory;
            this.executed_trajectory = executed_trajectory;
            this.planning_time = planning_time;
        }
    }
}
#endif
