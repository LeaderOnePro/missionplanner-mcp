using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;
using MissionPlanner.MCP.Models;
using MissionPlanner.MCP.Controllers;
using MissionPlanner.MCP.Views;

namespace MissionPlanner.MCP
{
    /// <summary>
    /// MCP控制面板的主要用户界面控件
    /// </summary>
    public partial class MCPControl : UserControl
    {
        // 控制器
        private DroneController _droneController;
        private MissionController _missionController;

        // 视图组件
        private StatusPanel _statusPanel;
        private ControlPanel _controlPanel;
        private MissionPanel _missionPanel;

        // 定时器，用于定期更新状态
        private System.Timers.Timer _updateTimer;

        /// <summary>
        /// 构造函数
        /// </summary>
        public MCPControl()
        {
            InitializeComponent();

            // 设置控件属性
            this.Dock = DockStyle.Fill;

            // 初始化控制器
            InitializeControllers();

            // 初始化UI
            InitializeUI();

            // 初始化定时器
            InitializeTimer();
        }

        /// <summary>
        /// 初始化控制器
        /// </summary>
        private void InitializeControllers()
        {
            try
            {
                // 创建无人机控制器
                _droneController = new DroneController();

                // 创建任务控制器
                _missionController = new MissionController();

                Console.WriteLine("MCP Controllers initialized");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing MCP Controllers: {ex.Message}");
            }
        }

        /// <summary>
        /// 初始化用户界面
        /// </summary>
        private void InitializeUI()
        {
            try
            {
                // 创建状态面板
                _statusPanel = new StatusPanel();

                // 创建控制面板
                _controlPanel = new ControlPanel(_droneController);

                // 创建任务面板
                _missionPanel = new MissionPanel(_missionController);

                // 添加到控件
                panelData.Controls.Add(_missionPanel);
                panelControls.Controls.Add(_controlPanel);
                panelStatus.Controls.Add(_statusPanel);

                Console.WriteLine("MCP Control UI initialized");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing MCP Control UI: {ex.Message}");
            }
        }

        /// <summary>
        /// 初始化定时器
        /// </summary>
        private void InitializeTimer()
        {
            try
            {
                // 创建定时器，每秒更新一次
                _updateTimer = new System.Timers.Timer(1000);
                _updateTimer.Elapsed += OnTimerElapsed;
                _updateTimer.AutoReset = true;
                _updateTimer.Enabled = true;

                Console.WriteLine("MCP Timer initialized");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing MCP Timer: {ex.Message}");
            }
        }

        /// <summary>
        /// 定时器事件处理程序
        /// </summary>
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                // 更新无人机状态
                _droneController.UpdateStatus();

                // 更新状态面板
                _statusPanel.UpdateStatus(_droneController.GetStatus());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in timer update: {ex.Message}");
            }
        }

        /// <summary>
        /// 更新控制面板数据
        /// </summary>
        public void UpdateData()
        {
            try
            {
                // 更新无人机状态
                _droneController.UpdateStatus();

                // 更新状态面板
                _statusPanel.UpdateStatus(_droneController.GetStatus());

                Console.WriteLine("MCP Control data updated");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating MCP Control data: {ex.Message}");
            }
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">是否释放托管资源</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // 停止定时器
                if (_updateTimer != null)
                {
                    _updateTimer.Stop();
                    _updateTimer.Dispose();
                }
            }

            base.Dispose(disposing);
        }
    }
}
