# MissionPlanner MCP 安装指南

本文档提供了安装和使用MissionPlanner Mission Control Panel (MCP)的详细说明。

## 系统要求

- Windows 7/8/10/11
- .NET Framework 4.6.1或更高版本
- MissionPlanner最新版本

## 安装步骤

### 方法1：使用预编译的DLL

1. 下载最新的MCP发布版本（MissionPlanner.MCP.dll）
2. 将DLL文件复制到MissionPlanner的`plugins`文件夹中
   - 通常位于`C:\Program Files (x86)\Mission Planner\plugins`或`C:\Program Files\Mission Planner\plugins`
3. 重启MissionPlanner
4. MCP将作为一个新的选项卡出现在MissionPlanner的主界面中

### 方法2：从源代码编译

1. 克隆或下载本仓库
2. 使用Visual Studio 2019或更高版本打开`MissionPlanner.MCP.sln`解决方案文件
3. 编译项目
4. 将生成的`MissionPlanner.MCP.dll`文件复制到MissionPlanner的`plugins`文件夹中
5. 重启MissionPlanner

## 使用说明

### 启动MCP

1. 启动MissionPlanner
2. 在主界面顶部的选项卡中，点击"MCP"选项卡
3. MCP界面将会显示

### 连接到无人机

1. 在MCP界面左侧的控制面板中，点击"Connect"按钮
2. 选择合适的连接方式和端口
3. 连接成功后，状态面板将显示无人机的实时状态信息

### 创建和执行任务

1. 在MCP界面的任务面板中，点击"New Mission"按钮创建新任务
2. 输入任务名称
3. 点击"Add Waypoint"按钮添加航点
4. 设置航点的位置和参数
5. 点击"Start Mission"按钮开始执行任务

### 控制无人机

1. 使用左侧控制面板中的按钮控制无人机
   - Arm/Disarm：解锁/上锁电机
   - Takeoff：起飞到指定高度
   - Land：降落
   - RTL：返航
   - Set Mode：设置飞行模式

## 故障排除

### MCP未显示在MissionPlanner中

- 确保DLL文件已正确复制到plugins文件夹
- 检查MissionPlanner的日志文件中是否有关于MCP的错误信息
- 尝试重新安装MissionPlanner

### 无法连接到无人机

- 确保无人机已开启并且通信链路正常
- 检查连接端口和波特率设置
- 尝试在MissionPlanner的主界面中先连接，然后再切换到MCP

### 其他问题

如果遇到其他问题，请查看日志文件或提交问题报告到项目仓库。

## 支持

如有问题或建议，请通过以下方式联系我们：

- 提交GitHub Issue
- 发送邮件至：leaderonepro@outlook.com
