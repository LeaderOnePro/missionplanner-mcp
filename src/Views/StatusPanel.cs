using System;
using System.Drawing;
using System.Windows.Forms;
using MissionPlanner.MCP.Models;

namespace MissionPlanner.MCP.Views
{
    /// <summary>
    /// 显示无人机状态信息的面板
    /// </summary>
    public class StatusPanel : Panel
    {
        // 标签控件
        private Label _labelConnection;
        private Label _labelMode;
        private Label _labelBattery;
        private Label _labelGPS;
        private Label _labelAltitude;
        private Label _labelSpeed;
        private Label _labelPosition;
        private Label _labelHeading;
        private Label _labelAttitude;
        
        // 状态数据
        private DroneStatus _status;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public StatusPanel()
        {
            // 设置面板属性
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Dock = DockStyle.Top;
            this.Height = 150;
            
            // 初始化控件
            InitializeControls();
        }
        
        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitializeControls()
        {
            // 创建标签
            _labelConnection = new Label
            {
                Text = "Connection: Disconnected",
                AutoSize = true,
                Location = new Point(10, 10)
            };
            
            _labelMode = new Label
            {
                Text = "Mode: --",
                AutoSize = true,
                Location = new Point(10, 30)
            };
            
            _labelBattery = new Label
            {
                Text = "Battery: --",
                AutoSize = true,
                Location = new Point(10, 50)
            };
            
            _labelGPS = new Label
            {
                Text = "GPS: --",
                AutoSize = true,
                Location = new Point(10, 70)
            };
            
            _labelAltitude = new Label
            {
                Text = "Altitude: --",
                AutoSize = true,
                Location = new Point(10, 90)
            };
            
            _labelSpeed = new Label
            {
                Text = "Speed: --",
                AutoSize = true,
                Location = new Point(10, 110)
            };
            
            _labelPosition = new Label
            {
                Text = "Position: --",
                AutoSize = true,
                Location = new Point(200, 10)
            };
            
            _labelHeading = new Label
            {
                Text = "Heading: --",
                AutoSize = true,
                Location = new Point(200, 30)
            };
            
            _labelAttitude = new Label
            {
                Text = "Attitude: --",
                AutoSize = true,
                Location = new Point(200, 50)
            };
            
            // 添加控件到面板
            this.Controls.Add(_labelConnection);
            this.Controls.Add(_labelMode);
            this.Controls.Add(_labelBattery);
            this.Controls.Add(_labelGPS);
            this.Controls.Add(_labelAltitude);
            this.Controls.Add(_labelSpeed);
            this.Controls.Add(_labelPosition);
            this.Controls.Add(_labelHeading);
            this.Controls.Add(_labelAttitude);
        }
        
        /// <summary>
        /// 更新状态信息
        /// </summary>
        /// <param name="status">无人机状态</param>
        public void UpdateStatus(DroneStatus status)
        {
            if (status == null)
                return;
            
            _status = status;
            
            // 更新UI
            UpdateUI();
        }
        
        /// <summary>
        /// 更新UI显示
        /// </summary>
        private void UpdateUI()
        {
            // 确保在UI线程上执行
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(UpdateUI));
                return;
            }
            
            // 更新标签文本
            _labelConnection.Text = $"Connection: {(_status.IsConnected ? "Connected" : "Disconnected")}";
            _labelMode.Text = $"Mode: {_status.FlightMode ?? "--"}";
            _labelBattery.Text = $"Battery: {_status.BatteryPercentage:F1}%";
            _labelGPS.Text = $"GPS: {_status.GPSSignalStrength}";
            _labelAltitude.Text = $"Altitude: {_status.Altitude:F1}m";
            _labelSpeed.Text = $"Speed: {_status.Speed:F1}m/s";
            _labelPosition.Text = $"Position: {_status.Latitude:F6}, {_status.Longitude:F6}";
            _labelHeading.Text = $"Heading: {_status.Heading:F1}°";
            _labelAttitude.Text = $"Attitude: P:{_status.Pitch:F1}° R:{_status.Roll:F1}° Y:{_status.Yaw:F1}°";
            
            // 根据连接状态设置颜色
            _labelConnection.ForeColor = _status.IsConnected ? Color.Green : Color.Red;
        }
    }
}
