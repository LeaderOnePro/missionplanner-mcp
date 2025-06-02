# Mission Control Panel (MCP) for MissionPlanner

## 声明
此 MCP 插件目前未完成开发，且项目已停止维护。

## 功能特点

- **集中状态显示**：在一个面板上显示所有关键飞行数据
- **简化的控制界面**：常用操作一键完成
- **高效任务规划**：直观的任务创建和管理界面
- **实时监控**：实时更新的飞行数据和状态信息
- **自定义布局**：可根据需要调整界面布局
- **多平台支持**：支持各种基于ArduPilot的无人机平台

## 安装方法

详细的安装指南请参考[INSTALL.md](INSTALL.md)文件。

### 快速安装

1. 下载最新的MCP发布版本
2. 将DLL文件复制到MissionPlanner的`plugins`文件夹中
3. 重启MissionPlanner

## 开发状态

当前处于活跃开发阶段。主要功能已经实现，但仍在不断完善和改进中。

### 路线图

- [x] 基本界面设计
- [x] 状态显示面板
- [x] 控制面板
- [x] 任务规划面板
- [ ] 与 MissionPlanner 的完全集成
- [ ] 高级配置选项
- [ ] 用户手册和文档

## 如何贡献

我们欢迎并鼓励社区贡献！如果您想参与开发，请按照以下步骤操作：

1. Fork 本仓库
2. 创建您的功能分支 (`git checkout -b feature/amazing-feature`)
3. 提交您的更改 (`git commit -m 'Add some amazing feature'`)
4. 推送到分支 (`git push origin feature/amazing-feature`)
5. 创建一个 Pull Request

## 技术栈

- C# / .NET Framework 4.6.1
- Windows Forms
- MAVLink 协议

## 许可证

本项目采用 GPL-3.0 许可证 - 详细信息请参见 [LICENSE](LICENSE) 文件。

## 联系方式

- 项目维护者：LeaderOnePro
- 邮箱：leaderonepro@outlook.com

## 致谢

- [ArduPilot](https://ardupilot.org/) 团队开发的出色开源飞控系统
- [MissionPlanner](https://github.com/ArduPilot/MissionPlanner) 项目及其贡献者
