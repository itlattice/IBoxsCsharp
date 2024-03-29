﻿using IBoxs.Sdk.Cqp.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Sdk.Cqp.Interface
{
    /// <summary>
	/// Type=104 群解除禁言事件接口
	/// </summary>
    public interface IReceiveRemoveGroupBan
    {
        /// <summary>
		/// 当在派生类中重写时, 处理收到的群解除禁言
		/// </summary>
		/// <param name="sender">事件的触发对象</param>
		/// <param name="e">事件的附加参数</param>
		void ReceiveRemoveGroupBan (object sender, CqGroupBanEventArgs e);
    }
}
