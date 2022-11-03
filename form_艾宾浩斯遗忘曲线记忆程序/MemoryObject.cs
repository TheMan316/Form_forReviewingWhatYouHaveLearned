using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace form_艾宾浩斯遗忘曲线记忆程序 {
    internal class MemoryObject {
        /// <summary>
        /// 当前主题需要复习的内容。
        /// </summary>
        private BinaryTree _memoryTree_toBeRemembered;
        /// <summary>
        /// 当前主题无需复习的内容。
        /// </summary>
        private BinaryTree _memoryTree_noNeedToBeRemenbered;
        /// <summary>
        /// 当前主题的名字
        /// </summary>
        public string ObjectName { get; set; }    
        /// <summary>
        /// 在创建新主题时，被调用
        /// </summary>
        /// <param name="objectName"></param>
        public MemoryObject(string objectName) {
            ObjectName = objectName;
            _memoryTree_toBeRemembered = new BinaryTree();
            _memoryTree_noNeedToBeRemenbered = new BinaryTree();
        }
        /// <summary>
        /// 更新数据。
        /// Add the MemoryModules that has reached the review time in the "_memoryTree_noNeedToBeRemenbered" 
        /// to the "_memoryTree_toBeRemembered".
        /// </summary>
        public void Update() {
            if (_memoryTree_noNeedToBeRemenbered.Count == 0) {
                return;
            }
            ulong dateNow = Convert.ToUInt64(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            var minTreeNode = _memoryTree_noNeedToBeRemenbered.Find_minTreeNode();
            while (_memoryTree_noNeedToBeRemenbered.Count > 0 && minTreeNode.MemoryModule.Data_toRemember < dateNow) {
                _memoryTree_toBeRemembered.Add_memoryModule(minTreeNode.MemoryModule);
                _memoryTree_noNeedToBeRemenbered.Delete_theTreeNode(minTreeNode.MemoryModule);
                minTreeNode = _memoryTree_noNeedToBeRemenbered.Find_minTreeNode();
            }
        }
        /// <summary>
        /// 每次返回“下一个记忆模块后”，都会更新该模块的“下一次记忆时间”。并把它从当前“所需复习内容”中移除，
        /// 添加到“无需复习内容”中。
        /// </summary>
        /// <param name="isRemember"></param>
        /// <returns></returns>
        public MemoryModule Get_nextMemoryModule(bool isRemember) {
            var nextMemoryModule = _memoryTree_toBeRemembered.Get_nextMemoryModule(isRemember);
            _memoryTree_noNeedToBeRemenbered.Add_memoryModule(nextMemoryModule);
            return nextMemoryModule;
        }
        public MemoryModule Get_nextMemoryModule() {
            return _memoryTree_toBeRemembered.Get_nextMemoryModule();
        }
        /// <summary>
        /// 创建一个记忆模块。
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public void Creat_memoryModule(string title,string content) {
            MemoryModule memoryModule = new MemoryModule();
            memoryModule.Title = title;
            memoryModule.Content = content;
            memoryModule.Data_toRemember = Convert.ToUInt64(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            _memoryTree_toBeRemembered.Add_memoryModule(memoryModule);
        }
        public void Add_memoryModule_noNeedToBeRemenbered(MemoryModule memoryModule) {
            _memoryTree_noNeedToBeRemenbered.Add_memoryModule(memoryModule);
        }
        public void Add_memoryModule_toBeRemenbered(MemoryModule memoryModule) {
            _memoryTree_toBeRemembered.Add_memoryModule(memoryModule);
        }
        public int Get_times_toRemember() {
            return _memoryTree_toBeRemembered.Count;
        }
        public BinaryTree Get_memoryTree_toBeRemembered() {
            return _memoryTree_toBeRemembered;
        }
        public BinaryTree Get_memoryTree_noNeedToBeRemenbered() {
            return _memoryTree_noNeedToBeRemenbered;
        }
    }
}
