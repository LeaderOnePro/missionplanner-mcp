using System;
using System.Drawing;
using System.Windows.Forms;
using MissionPlanner.MCP.Controllers;

namespace MissionPlanner.MCP.Views
{
    /// <summary>
    /// 提供无人机控制功能的面板
    /// </summary>
    public class ControlPanel : Panel
    {
        // 控制器
        private DroneController _droneController;
        
        // 按钮控件
        private Button _btnConnect;
        private Button _btnDisconnect;
        private Button _btnArm;
        private Button _btnDisarm;
        private Button _btnTakeoff;
        private Button _btnLand;
        private Button _btnRTL;
        private ComboBox _cmbModes;
        private Button _btnSetMode;
        private NumericUpDown _numAltitude;
        private Label _lblAltitude;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="droneController">无人机控制器</param>
        public ControlPanel(DroneController droneController)
        {
            _droneController = droneController;
            
            // 设置面板属性
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Dock = DockStyle.Left;
            this.Width = 200;
            
            // 初始化控件
            InitializeControls();
            
            // 注册事件处理程序
            RegisterEventHandlers();
        }
        
        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitializeControls()
        {
            // 创建连接按钮
            _btnConnect = new Button
            {
                Text = "Connect",
                Location = new Point(10, 10),
                Width = 80,
                Height = 30
            };
            
            // 创建断开连接按钮
            _btnDisconnect = new Button
            {
                Text = "Disconnect",
                Location = new Point(100, 10),
                Width = 80,
                Height = 30,
                Enabled = false
            };
            
            // 创建解锁按钮
            _btnArm = new Button
            {
                Text = "Arm",
                Location = new Point(10, 50),
                Width = 80,
                Height = 30,
                Enabled = false
            };
            
            // 创建上锁按钮
            _btnDisarm = new Button
            {
                Text = "Disarm",
                Location = new Point(100, 50),
                Width = 80,
                Height = 30,
                Enabled = false
            };
            
            // 创建起飞按钮
            _btnTakeoff = new Button
            {
                Text = "Takeoff",
                Location = new Point(10, 90),
                Width = 80,
                Height = 30,
                Enabled = false
            };
            
            // 创建降落按钮
            _btnLand = new Button
            {
                Text = "Land",
                Location = new Point(100, 90),
                Width = 80,
                Height = 30,
                Enabled = false
            };
            
            // 创建返航按钮
            _btnRTL = new Button
            {
                Text = "RTL",
                Location = new Point(10, 130),
                Width = 170,
                Height = 30,
                Enabled = false
            };
            
            // 创建模式选择下拉框
            _cmbModes = new ComboBox
            {
                Location = new Point(10, 170),
                Width = 120,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Enabled = false
            };
            
            // 添加常用模式
            _cmbModes.Items.AddRange(new object[] {
                "STABILIZE",
                "ALTHOLD",
                "LOITER",
                "RTL",
                "AUTO",
                "GUIDED",
                "LAND"
            });
            
            // 创建设置模式按钮
            _btnSetMode = new Button
            {
                Text = "Set Mode",
                Location = new Point(140, 170),
                Width = 40,
                Height = 23,
                Enabled = false
            };
            
            // 创建高度标签
            _lblAltitude = new Label
            {
                Text = "Takeoff Altitude (m):",
                Location = new Point(10, 210),
                AutoSize = true
            };
            
            // 创建高度输入框
            _numAltitude = new NumericUpDown
            {
                Location = new Point(130, 208),
                Width = 50,
                Minimum = 1,
                Maximum = 100,
                Value = 5,
                DecimalPlaces = 1,
                Increment = 0.5m
            };
            
            // 添加控件到面板
            this.Controls.Add(_btnConnect);
            this.Controls.Add(_btnDisconnect);
            this.Controls.Add(_btnArm);
            this.Controls.Add(_btnDisarm);
            this.Controls.Add(_btnTakeoff);
            this.Controls.Add(_btnLand);
            this.Controls.Add(_btnRTL);
            this.Controls.Add(_cmbModes);
            this.Controls.Add(_btnSetMode);
            this.Controls.Add(_lblAltitude);
            this.Controls.Add(_numAltitude);
        }
        
        /// <summary>
        /// 注册事件处理程序
        /// </summary>
        private void RegisterEventHandlers()
        {
            // 连接按钮点击事件
            _btnConnect.Click += (sender, e) => {
                try
                {
                    // 这里将添加实际的连接逻辑
                    bool connected = _droneController.Connect("COM1");
                    
                    // 更新按钮状态
                    UpdateButtonStates(connected);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            
            // 断开连接按钮点击事件
            _btnDisconnect.Click += (sender, e) => {
                try
                {
                    // 断开连接
                    _droneController.Disconnect();
                    
                    // 更新按钮状态
                    UpdateButtonStates(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Disconnection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            
            // 解锁按钮点击事件
            _btnArm.Click += (sender, e) => {
                try
                {
                    // 这里将添加实际的解锁逻辑
                    MessageBox.Show("Arming motors...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // 更新按钮状态
                    _btnArm.Enabled = false;
                    _btnDisarm.Enabled = true;
                    _btnTakeoff.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Arming error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            
            // 上锁按钮点击事件
            _btnDisarm.Click += (sender, e) => {
                try
                {
                    // 这里将添加实际的上锁逻辑
                    MessageBox.Show("Disarming motors...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // 更新按钮状态
                    _btnArm.Enabled = true;
                    _btnDisarm.Enabled = false;
                    _btnTakeoff.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Disarming error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            
            // 起飞按钮点击事件
            _btnTakeoff.Click += (sender, e) => {
                try
                {
                    // 获取起飞高度
                    double altitude = (double)_numAltitude.Value;
                    
                    // 起飞
                    bool success = _droneController.TakeOff(altitude);
                    
                    if (success)
                    {
                        MessageBox.Show($"Taking off to {altitude}m...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Takeoff error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            
            // 降落按钮点击事件
            _btnLand.Click += (sender, e) => {
                try
                {
                    // 降落
                    bool success = _droneController.Land();
                    
                    if (success)
                    {
                        MessageBox.Show("Landing...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Landing error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            
            // 返航按钮点击事件
            _btnRTL.Click += (sender, e) => {
                try
                {
                    // 返航
                    bool success = _droneController.ReturnToHome();
                    
                    if (success)
                    {
                        MessageBox.Show("Returning to home...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"RTL error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            
            // 设置模式按钮点击事件
            _btnSetMode.Click += (sender, e) => {
                try
                {
                    // 获取选择的模式
                    string mode = _cmbModes.SelectedItem?.ToString();
                    
                    if (string.IsNullOrEmpty(mode))
                    {
                        MessageBox.Show("Please select a flight mode.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    
                    // 设置模式
                    bool success = _droneController.SetMode(mode);
                    
                    if (success)
                    {
                        MessageBox.Show($"Mode set to {mode}.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Set mode error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            
            // 无人机控制器连接状态改变事件
            _droneController.ConnectionChanged += (sender, connected) => {
                // 确保在UI线程上执行
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action<bool>(UpdateButtonStates), connected);
                }
                else
                {
                    UpdateButtonStates(connected);
                }
            };
        }
        
        /// <summary>
        /// 更新按钮状态
        /// </summary>
        /// <param name="connected">是否已连接</param>
        private void UpdateButtonStates(bool connected)
        {
            _btnConnect.Enabled = !connected;
            _btnDisconnect.Enabled = connected;
            _btnArm.Enabled = connected;
            _btnDisarm.Enabled = false;
            _btnTakeoff.Enabled = false;
            _btnLand.Enabled = connected;
            _btnRTL.Enabled = connected;
            _cmbModes.Enabled = connected;
            _btnSetMode.Enabled = connected;
        }
    }
}
