﻿using System;
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
        public int CurMemberLevel { get; set; } = -1;
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
        public ulong ReviewTime { get; set; }

        /// <summary>
        /// 更新数据
        /// </summary>
        public void Update(bool isRemember,int minLevel) {
            var date_toRemember = DateTime.Now;
            TotalRememberTimes++;
            if (isRemember) {
                CurMemberLevel++;
                if (CurMemberLevel > 10) {
                    CurMemberLevel = 10;
                }
  
            }
            else {
                CurMemberLevel -= 2;
            }
            if (CurMemberLevel < minLevel) {
                CurMemberLevel = minLevel;
            }
            if (CurMemberLevel <= 0) {
                //加30秒
                date_toRemember = date_toRemember.AddSeconds(30);
            }
            else {
               uint m = 艾宾浩斯遗忘曲线类.艾宾浩斯遗忘曲线.Get_timesAdded(CurMemberLevel);
                date_toRemember = date_toRemember.AddMinutes(m);
            }

            ReviewTime = Convert.ToUInt64(date_toRemember.ToString("yyyyMMddHHmmssfff"));
        }

    }
}
