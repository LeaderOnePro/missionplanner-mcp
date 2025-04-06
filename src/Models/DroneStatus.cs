using System;

namespace MissionPlanner.MCP.Models
{
    /// <summary>
    /// 表示无人机的状态信息
    /// </summary>
    public class DroneStatus
    {
        /// <summary>
        /// 无人机的连接状态
        /// </summary>
        public bool IsConnected { get; set; }
        
        /// <summary>
        /// 无人机的当前模式
        /// </summary>
        public string FlightMode { get; set; }
        
        /// <summary>
        /// 无人机的电池电量百分比
        /// </summary>
        public double BatteryPercentage { get; set; }
        
        /// <summary>
        /// 无人机的GPS信号强度
        /// </summary>
        public int GPSSignalStrength { get; set; }
        
        /// <summary>
        /// 无人机的当前高度（米）
        /// </summary>
        public double Altitude { get; set; }
        
        /// <summary>
        /// 无人机的当前速度（米/秒）
        /// </summary>
        public double Speed { get; set; }
        
        /// <summary>
        /// 无人机的当前位置（纬度）
        /// </summary>
        public double Latitude { get; set; }
        
        /// <summary>
        /// 无人机的当前位置（经度）
        /// </summary>
        public double Longitude { get; set; }
        
        /// <summary>
        /// 无人机的当前航向（度）
        /// </summary>
        public double Heading { get; set; }
        
        /// <summary>
        /// 无人机的当前俯仰角（度）
        /// </summary>
        public double Pitch { get; set; }
        
        /// <summary>
        /// 无人机的当前横滚角（度）
        /// </summary>
        public double Roll { get; set; }
        
        /// <summary>
        /// 无人机的当前偏航角（度）
        /// </summary>
        public double Yaw { get; set; }
        
        /// <summary>
        /// 无人机的当前状态更新时间
        /// </summary>
        public DateTime LastUpdated { get; set; }
        
        /// <summary>
        /// 无人机的当前任务进度（百分比）
        /// </summary>
        public double MissionProgress { get; set; }
        
        /// <summary>
        /// 无人机的当前任务状态
        /// </summary>
        public string MissionStatus { get; set; }
        
        /// <summary>
        /// 无人机的当前任务项索引
        /// </summary>
        public int CurrentWaypointIndex { get; set; }
        
        /// <summary>
        /// 无人机的总任务项数量
        /// </summary>
        public int TotalWaypoints { get; set; }
        
        /// <summary>
        /// 无人机的当前遥控信号强度
        /// </summary>
        public int RCSignalStrength { get; set; }
        
        /// <summary>
        /// 无人机的当前数据链路信号强度
        /// </summary>
        public int DataLinkSignalStrength { get; set; }
        
        /// <summary>
        /// 无人机的当前错误信息
        /// </summary>
        public string ErrorMessage { get; set; }
        
        /// <summary>
        /// 无人机的当前警告信息
        /// </summary>
        public string WarningMessage { get; set; }
        
        /// <summary>
        /// 无人机的当前状态是否正常
        /// </summary>
        public bool IsHealthy { get; set; }
        
        /// <summary>
        /// 无人机的当前自动驾驶仪类型
        /// </summary>
        public string AutopilotType { get; set; }
        
        /// <summary>
        /// 无人机的当前固件版本
        /// </summary>
        public string FirmwareVersion { get; set; }
        
        /// <summary>
        /// 无人机的当前飞行时间（秒）
        /// </summary>
        public double FlightTime { get; set; }
        
        /// <summary>
        /// 无人机的当前剩余飞行时间（秒）
        /// </summary>
        public double RemainingFlightTime { get; set; }
        
        /// <summary>
        /// 无人机的当前距离起飞点的距离（米）
        /// </summary>
        public double DistanceFromHome { get; set; }
        
        /// <summary>
        /// 无人机的当前垂直速度（米/秒）
        /// </summary>
        public double VerticalSpeed { get; set; }
        
        /// <summary>
        /// 无人机的当前地面速度（米/秒）
        /// </summary>
        public double GroundSpeed { get; set; }
        
        /// <summary>
        /// 无人机的当前空速（米/秒）
        /// </summary>
        public double AirSpeed { get; set; }
        
        /// <summary>
        /// 无人机的当前电池电压（伏特）
        /// </summary>
        public double BatteryVoltage { get; set; }
        
        /// <summary>
        /// 无人机的当前电池电流（安培）
        /// </summary>
        public double BatteryCurrent { get; set; }
        
        /// <summary>
        /// 无人机的当前电池温度（摄氏度）
        /// </summary>
        public double BatteryTemperature { get; set; }
        
        /// <summary>
        /// 无人机的当前电机状态
        /// </summary>
        public bool MotorsArmed { get; set; }
    }
}
