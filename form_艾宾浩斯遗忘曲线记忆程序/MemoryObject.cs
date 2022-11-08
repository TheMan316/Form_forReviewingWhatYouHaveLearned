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
        /// 更新数据时，把位于“未复习内容”中已到达复习时间的记忆模块添加到“正在复习内容”列表中。
        /// </summary>
        public void Update() {
            if (_memoryTree_noNeedToBeRemenbered.Count == 0) {
                return;
            }
            ulong dateNow = Convert.ToUInt64(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            var minTreeNode = _memoryTree_noNeedToBeRemenbered.Find_minTreeNode();
            while (_memoryTree_noNeedToBeRemenbered.Count > 0 && minTreeNode.MemoryModule.ReviewTime < dateNow) {
                _memoryTree_toBeRemembered.Add_memoryModule(minTreeNode.MemoryModule);
                _memoryTree_noNeedToBeRemenbered.Delete_theTreeNode(minTreeNode.MemoryModule);
                minTreeNode = _memoryTree_noNeedToBeRemenbered.Find_minTreeNode();
            }
        }
        /// <summary>
        /// 根据是否记住的状态更新当前记忆模块的“下一个复习时间”，然后把它从“正在复习内容”中删除。
        /// </summary>
        /// <param name="isRemember"></param>
        /// <returns></returns>
        public void Set_reviewTime_ofCurrentMemoryModule(bool isRemember) {
            var memoryModule_hasBeenDeleted = _memoryTree_toBeRemembered.Get_currentMemoryModule_willBeDeleted(isRemember);
            _memoryTree_noNeedToBeRemenbered.Add_memoryModule(memoryModule_hasBeenDeleted);
        }
        /// <summary>
        ///  Get the memory module that closest to the review time
        /// </summary>
        /// <returns></returns>
        public MemoryModule Get_nextMemoryModule() {
            return _memoryTree_toBeRemembered.Get_currentMemoryModule();
        }
        /// <summary>
        /// 删除下一个正在复习的记忆模块。
        /// </summary>
        public void Delete_nextMemoryModule() {
            _memoryTree_toBeRemembered.Delete_theTreeNode(_memoryTree_toBeRemembered.Get_currentMemoryModule());
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
            memoryModule.ReviewTime = Convert.ToUInt64(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
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
