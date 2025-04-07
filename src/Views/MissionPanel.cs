using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using MissionPlanner.MCP.Models;
using MissionPlanner.MCP.Controllers;

namespace MissionPlanner.MCP.Views
{
    /// <summary>
    /// 显示和管理任务的面板
    /// </summary>
    public class MissionPanel : Panel
    {
        // 控制器
        private MissionController _missionController;
        
        // 控件
        private ListView _listMissions;
        private ListView _listWaypoints;
        private Button _btnNewMission;
        private Button _btnLoadMission;
        private Button _btnSaveMission;
        private Button _btnDeleteMission;
        private Button _btnAddWaypoint;
        private Button _btnRemoveWaypoint;
        private Button _btnStartMission;
        private Button _btnPauseMission;
        private Button _btnResumeMission;
        private Button _btnCancelMission;
        
        // 当前选中的任务
        private Mission _selectedMission;
        
        // 当前选中的航点
        private MissionItem _selectedWaypoint;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="missionController">任务控制器</param>
        public MissionPanel(MissionController missionController)
        {
            _missionController = missionController;
            
            // 设置面板属性
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Dock = DockStyle.Fill;
            
            // 初始化控件
            InitializeControls();
            
            // 注册事件处理程序
            RegisterEventHandlers();
            
            // 加载任务列表
            LoadMissionList();
        }
        
        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitializeControls()
        {
            // 创建任务列表
            _listMissions = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Location = new Point(10, 10),
                Size = new Size(300, 150),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            
            // 添加列
            _listMissions.Columns.Add("Name", 150);
            _listMissions.Columns.Add("Status", 80);
            _listMissions.Columns.Add("Waypoints", 70);
            
            // 创建航点列表
            _listWaypoints = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Location = new Point(10, 200),
                Size = new Size(300, 200),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
            };
            
            // 添加列
            _listWaypoints.Columns.Add("#", 30);
            _listWaypoints.Columns.Add("Command", 80);
            _listWaypoints.Columns.Add("Lat", 80);
            _listWaypoints.Columns.Add("Lon", 80);
            _listWaypoints.Columns.Add("Alt", 50);
            
            // 创建任务按钮
            _btnNewMission = new Button
            {
                Text = "New Mission",
                Location = new Point(10, 170),
                Width = 90,
                Height = 25
            };
            
            _btnLoadMission = new Button
            {
                Text = "Load",
                Location = new Point(110, 170),
                Width = 60,
                Height = 25,
                Enabled = false
            };
            
            _btnSaveMission = new Button
            {
                Text = "Save",
                Location = new Point(180, 170),
                Width = 60,
                Height = 25,
                Enabled = false
            };
            
            _btnDeleteMission = new Button
            {
                Text = "Delete",
                Location = new Point(250, 170),
                Width = 60,
                Height = 25,
                Enabled = false
            };
            
            // 创建航点按钮
            _btnAddWaypoint = new Button
            {
                Text = "Add Waypoint",
                Location = new Point(10, 410),
                Width = 100,
                Height = 25,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                Enabled = false
            };
            
            _btnRemoveWaypoint = new Button
            {
                Text = "Remove",
                Location = new Point(120, 410),
                Width = 80,
                Height = 25,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                Enabled = false
            };
            
            // 创建任务控制按钮
            _btnStartMission = new Button
            {
                Text = "Start Mission",
                Location = new Point(10, 445),
                Width = 100,
                Height = 25,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                Enabled = false
            };
            
            _btnPauseMission = new Button
            {
                Text = "Pause",
                Location = new Point(120, 445),
                Width = 60,
                Height = 25,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                Enabled = false
            };
            
            _btnResumeMission = new Button
            {
                Text = "Resume",
                Location = new Point(190, 445),
                Width = 60,
                Height = 25,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                Enabled = false
            };
            
            _btnCancelMission = new Button
            {
                Text = "Cancel",
                Location = new Point(260, 445),
                Width = 60,
                Height = 25,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                Enabled = false
            };
            
            // 添加控件到面板
            this.Controls.Add(_listMissions);
            this.Controls.Add(_listWaypoints);
            this.Controls.Add(_btnNewMission);
            this.Controls.Add(_btnLoadMission);
            this.Controls.Add(_btnSaveMission);
            this.Controls.Add(_btnDeleteMission);
            this.Controls.Add(_btnAddWaypoint);
            this.Controls.Add(_btnRemoveWaypoint);
            this.Controls.Add(_btnStartMission);
            this.Controls.Add(_btnPauseMission);
            this.Controls.Add(_btnResumeMission);
            this.Controls.Add(_btnCancelMission);
        }
        
        /// <summary>
        /// 注册事件处理程序
        /// </summary>
        private void RegisterEventHandlers()
        {
            // 任务列表选择改变事件
            _listMissions.SelectedIndexChanged += (sender, e) => {
                try
                {
                    if (_listMissions.SelectedItems.Count > 0)
                    {
                        // 获取选中的任务
                        _selectedMission = _listMissions.SelectedItems[0].Tag as Mission;
                        
                        // 更新航点列表
                        LoadWaypointList(_selectedMission);
                        
                        // 更新按钮状态
                        _btnLoadMission.Enabled = true;
                        _btnSaveMission.Enabled = true;
                        _btnDeleteMission.Enabled = true;
                        _btnAddWaypoint.Enabled = true;
                        _btnStartMission.Enabled = _selectedMission.Items.Count > 0;
                    }
                    else
                    {
                        _selectedMission = null;
                        _listWaypoints.Items.Clear();
                        
                        // 更新按钮状态
                        _btnLoadMission.Enabled = false;
                        _btnSaveMission.Enabled = false;
                        _btnDeleteMission.Enabled = false;
                        _btnAddWaypoint.Enabled = false;
                        _btnStartMission.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error selecting mission: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            
            // 航点列表选择改变事件
            _listWaypoints.SelectedIndexChanged += (sender, e) => {
                try
                {
                    if (_listWaypoints.SelectedItems.Count > 0)
                    {
                        // 获取选中的航点
                        _selectedWaypoint = _listWaypoints.SelectedItems[0].Tag as MissionItem;
                        
                        // 更新按钮状态
                        _btnRemoveWaypoint.Enabled = true;
                    }
                    else
                    {
                        _selectedWaypoint = null;
                        
                        // 更新按钮状态
                        _btnRemoveWaypoint.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error selecting waypoint: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            
            // 新建任务按钮点击事件
            _btnNewMission.Click += (sender, e) => {
                try
                {
                    // 显示输入对话框
                    string name = Microsoft.VisualBasic.Interaction.InputBox("Enter mission name:", "New Mission", "Mission " + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                    
                    if (!string.IsNullOrEmpty(name))
                    {
                        // 创建新任务
                        Mission mission = _missionController.CreateMission(name, "");
                        
                        // 刷新任务列表
                        LoadMissionList();
                        
                        // 选中新任务
                        SelectMission(mission);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating mission: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            
            // 加载任务按钮点击事件
            _btnLoadMission.Click += (sender, e) => {
                try
                {
                    if (_selectedMission != null)
                    {
                        // 加载任务
                        bool success = _missionController.LoadMission(_selectedMission);
                        
                        if (success)
                        {
                            MessageBox.Show($"Mission '{_selectedMission.Name}' loaded.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading mission: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            
            // 保存任务按钮点击事件
            _btnSaveMission.Click += (sender, e) => {
                try
                {
                    if (_selectedMission != null)
                    {
                        // 保存任务
                        bool success = _missionController.SaveMission(_selectedMission);
                        
                        if (success)
                        {
                            MessageBox.Show($"Mission '{_selectedMission.Name}' saved.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving mission: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            
            // 删除任务按钮点击事件
            _btnDeleteMission.Click += (sender, e) => {
                try
                {
                    if (_selectedMission != null)
                    {
                        // 确认删除
                        DialogResult result = MessageBox.Show($"Are you sure you want to delete mission '{_selectedMission.Name}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        
                        if (result == DialogResult.Yes)
                        {
                            // 删除任务
                            bool success = _missionController.DeleteMission(_selectedMission);
                            
                            if (success)
                            {
                                // 刷新任务列表
                                LoadMissionList();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting mission: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            
            // 添加航点按钮点击事件
            _btnAddWaypoint.Click += (sender, e) => {
                try
                {
                    if (_selectedMission != null)
                    {
                        // 创建新航点
                        MissionItem waypoint = new MissionItem
                        {
                            Command = "WAYPOINT",
                            Latitude = 0,
                            Longitude = 0,
                            Altitude = 10,
                            CreatedTime = DateTime.Now,
                            ModifiedTime = DateTime.Now
                        };
                        
                        // 添加到任务
                        bool success = _missionController.AddMissionItem(_selectedMission, waypoint);
                        
                        if (success)
                        {
                            // 刷新航点列表
                            LoadWaypointList(_selectedMission);
                            
                            // 更新按钮状态
                            _btnStartMission.Enabled = _selectedMission.Items.Count > 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding waypoint: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            
            // 移除航点按钮点击事件
            _btnRemoveWaypoint.Click += (sender, e) => {
                try
                {
                    if (_selectedMission != null && _selectedWaypoint != null)
                    {
                        // 移除航点
                        bool success = _missionController.RemoveMissionItem(_selectedMission, _selectedWaypoint);
                        
                        if (success)
                        {
                            // 刷新航点列表
                            LoadWaypointList(_selectedMission);
                            
                            // 更新按钮状态
                            _btnStartMission.Enabled = _selectedMission.Items.Count > 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error removing waypoint: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            
            // 开始任务按钮点击事件
            _btnStartMission.Click += (sender, e) => {
                try
                {
                    if (_selectedMission != null)
                    {
                        // 开始任务
                        bool success = _missionController.StartMission(_selectedMission);
                        
                        if (success)
                        {
                            // 更新按钮状态
                            _btnStartMission.Enabled = false;
                            _btnPauseMission.Enabled = true;
                            _btnCancelMission.Enabled = true;
                            
                            // 刷新任务列表
                            LoadMissionList();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error starting mission: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            
            // 暂停任务按钮点击事件
            _btnPauseMission.Click += (sender, e) => {
                try
                {
                    if (_selectedMission != null)
                    {
                        // 暂停任务
                        bool success = _missionController.PauseMission(_selectedMission);
                        
                        if (success)
                        {
                            // 更新按钮状态
                            _btnPauseMission.Enabled = false;
                            _btnResumeMission.Enabled = true;
                            
                            // 刷新任务列表
                            LoadMissionList();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error pausing mission: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            
            // 恢复任务按钮点击事件
            _btnResumeMission.Click += (sender, e) => {
                try
                {
                    if (_selectedMission != null)
                    {
                        // 恢复任务
                        bool success = _missionController.ResumeMission(_selectedMission);
                        
                        if (success)
                        {
                            // 更新按钮状态
                            _btnPauseMission.Enabled = true;
                            _btnResumeMission.Enabled = false;
                            
                            // 刷新任务列表
                            LoadMissionList();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error resuming mission: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            
            // 取消任务按钮点击事件
            _btnCancelMission.Click += (sender, e) => {
                try
                {
                    if (_selectedMission != null)
                    {
                        // 确认取消
                        DialogResult result = MessageBox.Show($"Are you sure you want to cancel mission '{_selectedMission.Name}'?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        
                        if (result == DialogResult.Yes)
                        {
                            // 取消任务
                            bool success = _missionController.CancelMission(_selectedMission);
                            
                            if (success)
                            {
                                // 更新按钮状态
                                _btnStartMission.Enabled = true;
                                _btnPauseMission.Enabled = false;
                                _btnResumeMission.Enabled = false;
                                _btnCancelMission.Enabled = false;
                                
                                // 刷新任务列表
                                LoadMissionList();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error cancelling mission: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            
            // 任务控制器任务更新事件
            _missionController.MissionUpdated += (sender, mission) => {
                // 确保在UI线程上执行
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => {
                        // 刷新任务列表
                        LoadMissionList();
                        
                        // 如果当前选中的任务是更新的任务，则刷新航点列表
                        if (_selectedMission != null && _selectedMission.Id == mission.Id)
                        {
                            LoadWaypointList(mission);
                        }
                    }));
                }
                else
                {
                    // 刷新任务列表
                    LoadMissionList();
                    
                    // 如果当前选中的任务是更新的任务，则刷新航点列表
                    if (_selectedMission != null && _selectedMission.Id == mission.Id)
                    {
                        LoadWaypointList(mission);
                    }
                }
            };
        }
        
        /// <summary>
        /// 加载任务列表
        /// </summary>
        private void LoadMissionList()
        {
            try
            {
                // 清空列表
                _listMissions.Items.Clear();
                
                // 获取所有任务
                List<Mission> missions = _missionController.GetAllMissions();
                
                // 添加到列表
                foreach (Mission mission in missions)
                {
                    ListViewItem item = new ListViewItem(mission.Name);
                    item.SubItems.Add(mission.Status);
                    item.SubItems.Add(mission.TotalItems.ToString());
                    item.Tag = mission;
                    
                    _listMissions.Items.Add(item);
                }
                
                // 如果有选中的任务，则重新选中
                if (_selectedMission != null)
                {
                    SelectMission(_selectedMission);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading mission list: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// 加载航点列表
        /// </summary>
        /// <param name="mission">任务</param>
        private void LoadWaypointList(Mission mission)
        {
            try
            {
                // 清空列表
                _listWaypoints.Items.Clear();
                
                if (mission == null || mission.Items == null)
                    return;
                
                // 添加到列表
                foreach (MissionItem waypoint in mission.Items)
                {
                    ListViewItem item = new ListViewItem(waypoint.Index.ToString());
                    item.SubItems.Add(waypoint.Command);
                    item.SubItems.Add(waypoint.Latitude.ToString("F6"));
                    item.SubItems.Add(waypoint.Longitude.ToString("F6"));
                    item.SubItems.Add(waypoint.Altitude.ToString("F1"));
                    item.Tag = waypoint;
                    
                    _listWaypoints.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading waypoint list: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// 选中指定的任务
        /// </summary>
        /// <param name="mission">要选中的任务</param>
        private void SelectMission(Mission mission)
        {
            try
            {
                if (mission == null)
                    return;
                
                // 查找任务项
                foreach (ListViewItem item in _listMissions.Items)
                {
                    Mission m = item.Tag as Mission;
                    
                    if (m != null && m.Id == mission.Id)
                    {
                        // 选中项
                        item.Selected = true;
                        item.EnsureVisible();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting mission: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
