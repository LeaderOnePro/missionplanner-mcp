using System;
using System.Collections.Generic;
using MissionPlanner.MCP.Models;

namespace MissionPlanner.MCP.Controllers
{
    /// <summary>
    /// 负责任务规划和执行的控制器
    /// </summary>
    public class MissionController
    {
        // 当前任务
        private Mission _currentMission;
        
        // 任务列表
        private List<Mission> _missions;
        
        // 事件：任务更新
        public event EventHandler<Mission> MissionUpdated;
        
        // 事件：任务开始
        public event EventHandler<Mission> MissionStarted;
        
        // 事件：任务暂停
        public event EventHandler<Mission> MissionPaused;
        
        // 事件：任务恢复
        public event EventHandler<Mission> MissionResumed;
        
        // 事件：任务完成
        public event EventHandler<Mission> MissionCompleted;
        
        // 事件：任务取消
        public event EventHandler<Mission> MissionCancelled;
        
        // 事件：任务错误
        public event EventHandler<string> ErrorOccurred;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public MissionController()
        {
            _missions = new List<Mission>();
        }
        
        /// <summary>
        /// 创建新任务
        /// </summary>
        /// <param name="name">任务名称</param>
        /// <param name="description">任务描述</param>
        /// <returns>新创建的任务</returns>
        public Mission CreateMission(string name, string description)
        {
            try
            {
                // 创建新任务
                var mission = new Mission
                {
                    Name = name,
                    Description = description
                };
                
                // 添加到任务列表
                _missions.Add(mission);
                
                Console.WriteLine($"Created new mission: {name}");
                
                return mission;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating mission: {ex.Message}");
                ErrorOccurred?.Invoke(this, $"Mission creation error: {ex.Message}");
                return null;
            }
        }
        
        /// <summary>
        /// 加载任务
        /// </summary>
        /// <param name="mission">要加载的任务</param>
        /// <returns>是否加载成功</returns>
        public bool LoadMission(Mission mission)
        {
            try
            {
                // 设置当前任务
                _currentMission = mission;
                
                Console.WriteLine($"Loaded mission: {mission.Name}");
                
                // 触发任务更新事件
                MissionUpdated?.Invoke(this, mission);
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading mission: {ex.Message}");
                ErrorOccurred?.Invoke(this, $"Mission loading error: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// 保存任务
        /// </summary>
        /// <param name="mission">要保存的任务</param>
        /// <returns>是否保存成功</returns>
        public bool SaveMission(Mission mission)
        {
            try
            {
                // 更新修改时间
                mission.ModifiedTime = DateTime.Now;
                
                // 如果任务不在列表中，则添加
                if (!_missions.Contains(mission))
                {
                    _missions.Add(mission);
                }
                
                Console.WriteLine($"Saved mission: {mission.Name}");
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving mission: {ex.Message}");
                ErrorOccurred?.Invoke(this, $"Mission saving error: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="mission">要删除的任务</param>
        /// <returns>是否删除成功</returns>
        public bool DeleteMission(Mission mission)
        {
            try
            {
                // 从列表中移除
                bool result = _missions.Remove(mission);
                
                // 如果当前任务是被删除的任务，则清空当前任务
                if (_currentMission == mission)
                {
                    _currentMission = null;
                }
                
                Console.WriteLine($"Deleted mission: {mission.Name}");
                
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting mission: {ex.Message}");
                ErrorOccurred?.Invoke(this, $"Mission deletion error: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// 添加任务项
        /// </summary>
        /// <param name="mission">目标任务</param>
        /// <param name="item">要添加的任务项</param>
        /// <returns>是否添加成功</returns>
        public bool AddMissionItem(Mission mission, MissionItem item)
        {
            try
            {
                // 设置任务项索引
                item.Index = mission.Items.Count;
                
                // 添加到任务
                mission.Items.Add(item);
                
                // 更新任务修改时间
                mission.ModifiedTime = DateTime.Now;
                
                Console.WriteLine($"Added mission item {item.Index} to mission: {mission.Name}");
                
                // 触发任务更新事件
                MissionUpdated?.Invoke(this, mission);
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding mission item: {ex.Message}");
                ErrorOccurred?.Invoke(this, $"Mission item addition error: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// 移除任务项
        /// </summary>
        /// <param name="mission">目标任务</param>
        /// <param name="item">要移除的任务项</param>
        /// <returns>是否移除成功</returns>
        public bool RemoveMissionItem(Mission mission, MissionItem item)
        {
            try
            {
                // 从任务中移除
                bool result = mission.Items.Remove(item);
                
                // 更新剩余任务项的索引
                for (int i = 0; i < mission.Items.Count; i++)
                {
                    mission.Items[i].Index = i;
                }
                
                // 更新任务修改时间
                mission.ModifiedTime = DateTime.Now;
                
                Console.WriteLine($"Removed mission item from mission: {mission.Name}");
                
                // 触发任务更新事件
                MissionUpdated?.Invoke(this, mission);
                
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing mission item: {ex.Message}");
                ErrorOccurred?.Invoke(this, $"Mission item removal error: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// 开始执行任务
        /// </summary>
        /// <param name="mission">要执行的任务</param>
        /// <returns>是否开始成功</returns>
        public bool StartMission(Mission mission)
        {
            try
            {
                // 设置任务状态
                mission.Status = "Running";
                mission.IsRunning = true;
                mission.StartTime = DateTime.Now;
                mission.CurrentItemIndex = 0;
                mission.Progress = 0;
                
                Console.WriteLine($"Started mission: {mission.Name}");
                
                // 触发任务开始事件
                MissionStarted?.Invoke(this, mission);
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting mission: {ex.Message}");
                ErrorOccurred?.Invoke(this, $"Mission start error: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// 暂停任务
        /// </summary>
        /// <param name="mission">要暂停的任务</param>
        /// <returns>是否暂停成功</returns>
        public bool PauseMission(Mission mission)
        {
            try
            {
                // 设置任务状态
                mission.Status = "Paused";
                mission.IsRunning = false;
                
                Console.WriteLine($"Paused mission: {mission.Name}");
                
                // 触发任务暂停事件
                MissionPaused?.Invoke(this, mission);
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error pausing mission: {ex.Message}");
                ErrorOccurred?.Invoke(this, $"Mission pause error: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// 恢复任务
        /// </summary>
        /// <param name="mission">要恢复的任务</param>
        /// <returns>是否恢复成功</returns>
        public bool ResumeMission(Mission mission)
        {
            try
            {
                // 设置任务状态
                mission.Status = "Running";
                mission.IsRunning = true;
                
                Console.WriteLine($"Resumed mission: {mission.Name}");
                
                // 触发任务恢复事件
                MissionResumed?.Invoke(this, mission);
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error resuming mission: {ex.Message}");
                ErrorOccurred?.Invoke(this, $"Mission resume error: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// 取消任务
        /// </summary>
        /// <param name="mission">要取消的任务</param>
        /// <returns>是否取消成功</returns>
        public bool CancelMission(Mission mission)
        {
            try
            {
                // 设置任务状态
                mission.Status = "Cancelled";
                mission.IsRunning = false;
                mission.IsCancelled = true;
                mission.EndTime = DateTime.Now;
                
                // 计算实际飞行时间
                if (mission.StartTime.HasValue)
                {
                    mission.ActualFlightTime = (DateTime.Now - mission.StartTime.Value).TotalSeconds;
                }
                
                Console.WriteLine($"Cancelled mission: {mission.Name}");
                
                // 触发任务取消事件
                MissionCancelled?.Invoke(this, mission);
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cancelling mission: {ex.Message}");
                ErrorOccurred?.Invoke(this, $"Mission cancellation error: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// 完成任务
        /// </summary>
        /// <param name="mission">要完成的任务</param>
        /// <returns>是否完成成功</returns>
        public bool CompleteMission(Mission mission)
        {
            try
            {
                // 设置任务状态
                mission.Status = "Completed";
                mission.IsRunning = false;
                mission.IsCompleted = true;
                mission.EndTime = DateTime.Now;
                mission.Progress = 100;
                
                // 计算实际飞行时间
                if (mission.StartTime.HasValue)
                {
                    mission.ActualFlightTime = (DateTime.Now - mission.StartTime.Value).TotalSeconds;
                }
                
                Console.WriteLine($"Completed mission: {mission.Name}");
                
                // 触发任务完成事件
                MissionCompleted?.Invoke(this, mission);
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error completing mission: {ex.Message}");
                ErrorOccurred?.Invoke(this, $"Mission completion error: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// 获取所有任务
        /// </summary>
        /// <returns>任务列表</returns>
        public List<Mission> GetAllMissions()
        {
            return _missions;
        }
        
        /// <summary>
        /// 获取当前任务
        /// </summary>
        /// <returns>当前任务</returns>
        public Mission GetCurrentMission()
        {
            return _currentMission;
        }
    }
}
