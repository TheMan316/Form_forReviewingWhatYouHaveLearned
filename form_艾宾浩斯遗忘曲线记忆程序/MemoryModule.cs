using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace form_艾宾浩斯遗忘曲线记忆程序 {
    internal class MemoryModule {
        /// <summary>
        /// 记忆次数
        /// </summary>
        public int TotalRememberTimes { get; set; }
        /// <summary>
        /// 记忆等级
        /// </summary>
        public int MemberLevel { get; set; } = -1;
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 记忆时间
        /// </summary>
        public ulong Data_toRemember { get; set; }

        /// <summary>
        /// 更新数据
        /// </summary>
        public void Update(bool isRemember) {
            TotalRememberTimes++;
            if (isRemember) {
                MemberLevel++;
                if (MemberLevel > 8) {
                    MemberLevel = 8;
                }

            }
            else {
                MemberLevel-=2;
                if (MemberLevel < -1) {
                    MemberLevel = -1;
                }
            }
            Data_toRemember = Convert.ToUInt64(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            if (MemberLevel == -1) {
                //加30秒
                Data_toRemember += 30000;
            }
            else {
                Data_toRemember += 艾宾浩斯遗忘曲线类.艾宾浩斯遗忘曲线.Get_timesAdded(MemberLevel);
            }
        }

    }
}
