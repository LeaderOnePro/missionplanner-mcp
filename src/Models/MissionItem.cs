using System;

namespace MissionPlanner.MCP.Models
{
    /// <summary>
    /// 表示任务中的一个航点或命令
    /// </summary>
    public class MissionItem
    {
        /// <summary>
        /// 任务项的序号
        /// </summary>
        public int Index { get; set; }
        
        /// <summary>
        /// 任务项的命令类型
        /// </summary>
        public string Command { get; set; }
        
        /// <summary>
        /// 任务项的纬度
        /// </summary>
        public double Latitude { get; set; }
        
        /// <summary>
        /// 任务项的经度
        /// </summary>
        public double Longitude { get; set; }
        
        /// <summary>
        /// 任务项的高度（米）
        /// </summary>
        public double Altitude { get; set; }
        
        /// <summary>
        /// 任务项的参数1
        /// </summary>
        public double Param1 { get; set; }
        
        /// <summary>
        /// 任务项的参数2
        /// </summary>
        public double Param2 { get; set; }
        
        /// <summary>
        /// 任务项的参数3
        /// </summary>
        public double Param3 { get; set; }
        
        /// <summary>
        /// 任务项的参数4
        /// </summary>
        public double Param4 { get; set; }
        
        /// <summary>
        /// 任务项的帧类型
        /// </summary>
        public string Frame { get; set; }
        
        /// <summary>
        /// 任务项是否为当前项
        /// </summary>
        public bool IsCurrent { get; set; }
        
        /// <summary>
        /// 任务项是否已完成
        /// </summary>
        public bool IsCompleted { get; set; }
        
        /// <summary>
        /// 任务项的描述
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// 任务项的创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }
        
        /// <summary>
        /// 任务项的修改时间
        /// </summary>
        public DateTime ModifiedTime { get; set; }
    }
}
