using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace form_艾宾浩斯遗忘曲线记忆程序 {
    public class 艾宾浩斯遗忘曲线类 {
        public static 艾宾浩斯遗忘曲线类 艾宾浩斯遗忘曲线 = new 艾宾浩斯遗忘曲线类();
        /// <summary>
        /// 根据遗忘曲线为每个记忆等级设置被添加的值。
        /// </summary>
        private  List<uint> _list_timeAdded = new List<uint>();
        public 艾宾浩斯遗忘曲线类() {
            Init_list();
        }
        public uint Get_timesAdded(int memoryLevel) {
            return 艾宾浩斯遗忘曲线._list_timeAdded[memoryLevel];
        }

        private  void Init_list() {
            int timeAdded_beBasedOnCurveLevel = 0;
            //共有11个等级
            for (int memberLevel = 0; memberLevel < 11; memberLevel++) {
                switch (memberLevel) {
                    //单位：分钟
                    //分别为：30秒，5分钟、30分钟、3小时、12小时、1天、2天、4天、7天、15天、30天
                    case 0:
                        timeAdded_beBasedOnCurveLevel = 0; //三十秒的数据不在这添加。
                        break;
                    case 1:
                        timeAdded_beBasedOnCurveLevel = 5;
                        break;
                    case 2:
                        timeAdded_beBasedOnCurveLevel = 30;
                        break;
                    case 3:
                        timeAdded_beBasedOnCurveLevel = 180;
                        break;
                    case 4:
                        timeAdded_beBasedOnCurveLevel = 720;
                        break;
                    case 5:
                        timeAdded_beBasedOnCurveLevel = 1440;
                        break;
                    case 6:
                        timeAdded_beBasedOnCurveLevel = 2880;
                        break;
                    case 7:
                        timeAdded_beBasedOnCurveLevel = 5760;
                        break;
                    case 8:
                        timeAdded_beBasedOnCurveLevel = 10080;
                        break;
                    case 9:
                        timeAdded_beBasedOnCurveLevel = 21600;
                        break;
                    case 10:
                        timeAdded_beBasedOnCurveLevel = 43200;
                        break;
                    default:
                        break;
                }
                _list_timeAdded.Add((uint)(timeAdded_beBasedOnCurveLevel));
            }
        }
    }

    internal class TreeNode {
        public MemoryModule MemoryModule { get; set; } 
        public TreeNode LeftTreeNode { get; set; } 
        public TreeNode RightTreeNode { get; set; } 
        public TreeNode(MemoryModule memoryModule) {
            this.MemoryModule = memoryModule;
        }

    }
    //当前时间内需要复习的内容。
    internal class BinaryTree {

        private TreeNode _rootNode = null;



        public int Count { get; set; }
        public BinaryTree() {
        }
        /// <summary>
        /// Get the will be deleted memory module that is closest to the review time and update its review time
        /// </summary>
        /// <param name="isRemember"></param>
        /// <returns></returns>
        public MemoryModule Get_currentMemoryModule_willBeDeleted(bool isRemember,int defaultMinimumLevel) {
            MemoryModule memoryModule = Find_minTreeNode().MemoryModule;
            Delete_theTreeNode(memoryModule);
            memoryModule.Update(isRemember, defaultMinimumLevel);
            return memoryModule;
        }
        /// <summary>
        /// Get the memory module that closest to the review time
        /// </summary>
        /// <returns></returns>
        public MemoryModule Get_currentMemoryModule() {
            return Find_minTreeNode().MemoryModule;
        }
        public MemoryModule Find_theMemoryModule(MemoryModule theMemoryModule) {
            
            if (_rootNode == null) {
                return null;
            }
            TreeNode parentNode_ofCurrentTreeNode = null;
            TreeNode currentTreeNode = _rootNode;
            while (theMemoryModule.ReviewTime != currentTreeNode.MemoryModule.ReviewTime) {
                //更新父节点
                parentNode_ofCurrentTreeNode = currentTreeNode;
                MemoryModule currentMemoryModule = currentTreeNode.MemoryModule;
                if (theMemoryModule.ReviewTime < currentMemoryModule.ReviewTime) {
                    if (currentTreeNode.LeftTreeNode != null) {
                        currentTreeNode = currentTreeNode.LeftTreeNode;
                    }
                    //如果左节点为空，说明找到了这个值。
                    else {
                        break;
                    }
                }
                else if (theMemoryModule.ReviewTime > currentMemoryModule.ReviewTime) {
                    if (currentTreeNode.RightTreeNode != null) {
                        currentTreeNode = currentTreeNode.RightTreeNode;
                    }
                    //如果右节点为空，说明找到了这个值
                    else {
                        break;
                    }
                }
            }
            return currentTreeNode.MemoryModule;
        }

        public void Delete_theTreeNode(MemoryModule memoryModule_willBeDelete) {
            if (_rootNode == null) {
                return;
            }
            TreeNode parentNode_ofCurrentTreeNode = null;
            TreeNode currentTreeNode = _rootNode;
            bool IsLefeTreeNode = false;
            while (memoryModule_willBeDelete != currentTreeNode.MemoryModule) {
                //更新父节点
                parentNode_ofCurrentTreeNode = currentTreeNode;
                MemoryModule currentMemoryModule = currentTreeNode.MemoryModule;
                if (memoryModule_willBeDelete.ReviewTime < currentMemoryModule.ReviewTime) {
                    IsLefeTreeNode = true;
                    if (currentTreeNode.LeftTreeNode != null) {
                        currentTreeNode = currentTreeNode.LeftTreeNode;
                    }
                    //如果左节点为空，说明找到了这个值。
                    else {
                        return;
                    }
                }
                else if (memoryModule_willBeDelete.ReviewTime > currentMemoryModule.ReviewTime) {
                    IsLefeTreeNode = false;
                    if (currentTreeNode.RightTreeNode != null) {
                        currentTreeNode = currentTreeNode.RightTreeNode;
                    }
                    //如果左节点为空，说明找不到这个值。直接退出方法。
                    else {
                        return;
                    }
                }
            }
            //此时被删除字节点有4中情况：
            //1、被找到的节点如果两个子节点都为空
            if (currentTreeNode.LeftTreeNode == null && currentTreeNode.RightTreeNode == null) {
                //父节点为空，说明为根节点。更新根节点。
                if (parentNode_ofCurrentTreeNode == null) {
                    _rootNode = null;
                }
                //判断这个被删除节点是左节点还是右节点
                else if (IsLefeTreeNode) {
                    parentNode_ofCurrentTreeNode.LeftTreeNode = null;
                }
                else {
                    parentNode_ofCurrentTreeNode.RightTreeNode = null;
                }
            }
            //2、被找到的节点如果左子节点为空，移植右边的子节点到父节点的对应子节点上。
            else if (currentTreeNode.LeftTreeNode == null) {
                //父节点为空，说明为根节点。更新根节点。
                if (parentNode_ofCurrentTreeNode == null) {
                    _rootNode = currentTreeNode.RightTreeNode;
                }
                //判断这个被删除节点是左节点还是右节点
                else if (IsLefeTreeNode) {
                    parentNode_ofCurrentTreeNode.LeftTreeNode = currentTreeNode.RightTreeNode;
                }
                else {
                    parentNode_ofCurrentTreeNode.RightTreeNode = currentTreeNode.RightTreeNode;
                }
            }
            //3、被找到的节点如果右子节点为空，移植左边的子节点到父节点的对应子节点上。
            else if (currentTreeNode.RightTreeNode == null) {
                //父节点为空，说明为根节点。更新根节点。
                if (parentNode_ofCurrentTreeNode == null) {
                    _rootNode = currentTreeNode.LeftTreeNode;
                }
                //判断这个被删除节点是左节点还是右节点
                else if (IsLefeTreeNode) {
                    parentNode_ofCurrentTreeNode.LeftTreeNode = currentTreeNode.LeftTreeNode;
                }
                else {
                    parentNode_ofCurrentTreeNode.RightTreeNode = currentTreeNode.LeftTreeNode;
                }
            }
            //4、被找到的子节点的两个节点都存在，那么需要重新从两个子节点中找出一个比新左子节点大但是比新右子节点小的值。
            //而这个值可以是右子节点树的最小值。
            else {
                TreeNode successor = Get_successor(currentTreeNode);
                successor.LeftTreeNode = currentTreeNode.LeftTreeNode;
                if (currentTreeNode == _rootNode) {
                    _rootNode = successor;
                }
                else if (IsLefeTreeNode) {
                    parentNode_ofCurrentTreeNode.LeftTreeNode = successor;
                }
                else {
                    parentNode_ofCurrentTreeNode.RightTreeNode = successor;
                }
            }
            Count--;
        }
        /// <summary>
        /// 返回该节点右子节点的最小值。
        /// </summary>
        /// <param name="parentNode">注意:该节点的右子节点一定存在！</param>
        /// <returns></returns>
        public TreeNode Get_successor(TreeNode parentNode) {
            TreeNode parentNode_ofCurrentTreeNode = parentNode.RightTreeNode;
            TreeNode currentNode = parentNode_ofCurrentTreeNode.LeftTreeNode;
            //当前节点为空，则说明父节点就是最小值了。
            while (currentNode != null) {
                parentNode_ofCurrentTreeNode = currentNode;
                currentNode = parentNode_ofCurrentTreeNode.LeftTreeNode;
            }
            return parentNode_ofCurrentTreeNode;
        }
        /// <summary>
        /// 获取最小的节点。
        /// </summary>
        /// <returns></returns>
        public TreeNode Find_minTreeNode() {
            if (_rootNode == null) {
                return null;
            }
            else if (_rootNode.LeftTreeNode == null) {
                return _rootNode;
            }
            TreeNode currentTreeNode = _rootNode;
            //找到空，说明它就是最小值了
            while (currentTreeNode.LeftTreeNode != null) {
                currentTreeNode = currentTreeNode.LeftTreeNode;
            }
            return currentTreeNode;
        }
        /// <summary>
        /// 得到最大的节点
        /// </summary>
        /// <returns></returns>
        public TreeNode Find_maxTreeNode() {
            if (_rootNode == null) {
                return null;
            }
            else if (_rootNode.RightTreeNode == null) {
                return _rootNode;
            }
            TreeNode currentTreeNode = _rootNode;
            //找到空，说明它就是最大值了
            while (currentTreeNode.RightTreeNode != null) {
                currentTreeNode = currentTreeNode.RightTreeNode;
            }
            return currentTreeNode;
        }
        public void Add_memoryModule(MemoryModule memoryModule_willBeAdded) {
            TreeNode currentTreeNode = _rootNode;
            Count++;
            if (currentTreeNode == null) {
                
                _rootNode = new TreeNode(memoryModule_willBeAdded);
                return;
            }

            //根据时间判断判断方向
            while (currentTreeNode.MemoryModule.ReviewTime != memoryModule_willBeAdded.ReviewTime) {
                MemoryModule currentMemoryModule = currentTreeNode.MemoryModule;
                if (memoryModule_willBeAdded.ReviewTime < currentMemoryModule.ReviewTime) {
                    if (currentTreeNode.LeftTreeNode == null) {
                        currentTreeNode.LeftTreeNode = new TreeNode(memoryModule_willBeAdded);
                        break;
                    }
                    currentTreeNode = currentTreeNode.LeftTreeNode;

                }
                else if (memoryModule_willBeAdded.ReviewTime > currentMemoryModule.ReviewTime) {
                    if (currentTreeNode.RightTreeNode == null) {
                        currentTreeNode.RightTreeNode = new TreeNode(memoryModule_willBeAdded);
                        break;
                    }
                    currentTreeNode = currentTreeNode.RightTreeNode;

                }
            }

        }
        public void Add_attributeOfMemoryModule_toTheElement(XElement xElement) {
            void Loop_chilrendNode(TreeNode node, XElement xElement1) {
                xElement1.Add(new XElement("模块",
                 new XElement("内容", $"{ node.MemoryModule.Content}"),
                 new XAttribute("标题", $"{node.MemoryModule.Title}"),
                 new XAttribute("下次复习时间", $"{node.MemoryModule.ReviewTime}"),
                 new XAttribute("共复习次数", $"{node.MemoryModule.TotalRememberTimes}"),
                  new XAttribute("记忆等级", $"{node.MemoryModule.CurMemberLevel}")));

                if (node.LeftTreeNode != null) {
                    Loop_chilrendNode(node.LeftTreeNode, xElement1);
                }
                if (node.RightTreeNode != null) {
                    Loop_chilrendNode(node.RightTreeNode, xElement1);
                }
            }
            if (_rootNode == null) {
                return;
            }
            xElement.Add(new XElement("模块",
                  new XElement("内容", $"{ _rootNode.MemoryModule.Content}"),
                  new XAttribute("标题", $"{_rootNode.MemoryModule.Title}"),
                  new XAttribute("下次复习时间", $"{_rootNode.MemoryModule.ReviewTime}"),
                  new XAttribute("共复习次数", $"{_rootNode.MemoryModule.TotalRememberTimes}"),
                   new XAttribute("记忆等级", $"{_rootNode.MemoryModule.CurMemberLevel}")));
            if (_rootNode.LeftTreeNode != null) {
                Loop_chilrendNode(_rootNode.LeftTreeNode, xElement);
            }
            if (_rootNode.RightTreeNode != null) {
                Loop_chilrendNode(_rootNode.RightTreeNode, xElement);
            }
        }
      
    }
}
