using System;
using System.Windows.Forms;

namespace MissionPlanner.MCP
{
    /// <summary>
    /// MCP插件主类，用于与MissionPlanner集成
    /// </summary>
    public class MCPPlugin
    {
        // 插件名称
        public string Name => "Mission Control Panel";
        
        // 插件版本
        public string Version => "1.0.0";
        
        // 插件描述
        public string Description => "Enhanced control panel for MissionPlanner";
        
        // 插件作者
        public string Author => "LeaderOnePro";
        
        // 插件控件实例
        private MCPControl _mcpControl;
        
        /// <summary>
        /// 初始化插件
        /// </summary>
        public void Initialize()
        {
            try
            {
                // 创建MCP控件
                _mcpControl = new MCPControl();
                
                // 这里将添加与MissionPlanner的集成代码
                // 例如注册菜单项、添加到主界面等
                
                Console.WriteLine($"MCP Plugin initialized: {Name} v{Version}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing MCP Plugin: {ex.Message}");
            }
        }
        
        /// <summary>
        /// 加载插件
        /// </summary>
        public void Load()
        {
            try
            {
                // 这里将添加插件加载时的逻辑
                Console.WriteLine("MCP Plugin loaded");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading MCP Plugin: {ex.Message}");
            }
        }
        
        /// <summary>
        /// 卸载插件
        /// </summary>
        public void Unload()
        {
            try
            {
                // 清理资源
                _mcpControl?.Dispose();
                
                Console.WriteLine("MCP Plugin unloaded");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error unloading MCP Plugin: {ex.Message}");
            }
        }
        
        /// <summary>
        /// 获取插件控件
        /// </summary>
        /// <returns>MCP控件实例</returns>
        public Control GetControl()
        {
            return _mcpControl ?? (_mcpControl = new MCPControl());
        }
    }
}
