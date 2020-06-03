using IBoxs.Sdk.Cqp.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBoxs.Sdk.Cqp.Model
{
    /// <summary>
    /// 描述 QQ 的类
    /// </summary>
    public class QQInfo
    {
        /// <summary>
        /// 获取唯一标识符, 即QQ号码
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 获取当前实例性别 <see cref="Enum.Sex"/>
        /// </summary>
        public Sex Sex { get; set; }
        /// <summary>
        /// 获取当前实例年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 获取当前实例昵称
        /// </summary>
        public string Nick { get; set; }

        /// <summary>
		/// 判断是否是登录QQ (机器人QQ)
		/// </summary>
		public bool IsLoginQQ
        {
            get
            {
                return cq.GetLoginQQ() == this.Id;
            }
        }
        CqApi cq = new CqApi(CqApi.authCode);
        /// <summary>
        /// 发送私聊消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string SendPrivateMessage(string message)
        {
            return cq.SendPrivateMessage(this.Id, message);
        }

        /// <summary>
		/// 发送赞
		/// </summary>
		/// <param name="count">发送赞的次数, 范围: 1~10 (留空为1次)</param>
		/// <returns>执行成功返回 <code>true</code>, 失败返回 <code>false</code></returns>
		public string SendPraise(int count = 1)
        {
            return cq.SendPraise(this.Id, count);
        }
    }
}
