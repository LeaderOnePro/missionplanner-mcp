using System;
using System.Collections.Generic;

namespace MissionPlanner.MCP.Models
{
    /// <summary>
    /// 表示一个完整的任务
    /// </summary>
    public class Mission
    {
        /// <summary>
        /// 任务的唯一标识符
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// 任务的名称
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 任务的描述
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// 任务的创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }
        
        /// <summary>
        /// 任务的修改时间
        /// </summary>
        public DateTime ModifiedTime { get; set; }
        
        /// <summary>
        /// 任务的航点列表
        /// </summary>
        public List<MissionItem> Items { get; set; }
        
        /// <summary>
        /// 任务的当前状态
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// 任务的进度（百分比）
        /// </summary>
        public double Progress { get; set; }
        
        /// <summary>
        /// 任务的当前航点索引
        /// </summary>
        public int CurrentItemIndex { get; set; }
        
        /// <summary>
        /// 任务的总航点数量
        /// </summary>
        public int TotalItems => Items?.Count ?? 0;
        
        /// <summary>
        /// 任务的起始位置（纬度）
        /// </summary>
        public double StartLatitude { get; set; }
        
        /// <summary>
        /// 任务的起始位置（经度）
        /// </summary>
        public double StartLongitude { get; set; }
        
        /// <summary>
        /// 任务的起始高度（米）
        /// </summary>
        public double StartAltitude { get; set; }
        
        /// <summary>
        /// 任务的结束位置（纬度）
        /// </summary>
        public double EndLatitude { get; set; }
        
        /// <summary>
        /// 任务的结束位置（经度）
        /// </summary>
        public double EndLongitude { get; set; }
        
        /// <summary>
        /// 任务的结束高度（米）
        /// </summary>
        public double EndAltitude { get; set; }
        
        /// <summary>
        /// 任务的总距离（米）
        /// </summary>
        public double TotalDistance { get; set; }
        
        /// <summary>
        /// 任务的估计飞行时间（秒）
        /// </summary>
        public double EstimatedFlightTime { get; set; }
        
        /// <summary>
        /// 任务的实际飞行时间（秒）
        /// </summary>
        public double ActualFlightTime { get; set; }
        
        /// <summary>
        /// 任务的开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        
        /// <summary>
        /// 任务的结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
        
        /// <summary>
        /// 任务是否已完成
        /// </summary>
        public bool IsCompleted { get; set; }
        
        /// <summary>
        /// 任务是否已取消
        /// </summary>
        public bool IsCancelled { get; set; }
        
        /// <summary>
        /// 任务是否正在执行
        /// </summary>
        public bool IsRunning { get; set; }
        
        /// <summary>
        /// 任务的错误信息
        /// </summary>
        public string ErrorMessage { get; set; }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public Mission()
        {
            Id = Guid.NewGuid();
            CreatedTime = DateTime.Now;
            ModifiedTime = DateTime.Now;
            Items = new List<MissionItem>();
            Status = "New";
            Progress = 0;
            CurrentItemIndex = 0;
        }
    }
}
