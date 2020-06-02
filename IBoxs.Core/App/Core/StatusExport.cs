/*
 *	此代码由 T4 引擎根据 StatusExport.tt 模板生成, 若您不了解以下代码的用处, 请勿修改!
 *	
 *	此文件包含项目 Json 文件的悬浮窗导出函数.
 */
using System;
using System.Runtime.InteropServices;
using System.Text;
using IBoxs.Sdk.Cqp.EventArgs;
using IBoxs.Sdk.Cqp.Interface;
using Unity;

namespace IBoxs.Core.App.Core
{
    public class StatusExport
    {
		#region --构造函数--
		/// <summary>
		/// 静态构造函数, 注册依赖注入回调
		/// </summary>
        static StatusExport ()
        {
			// 分发应用内事件
			ResolveAppbackcall ();
        }
        #endregion

		#region --私有方法--
		/// <summary>
		/// 获取所有的注入项, 分发到对应的事件
		/// </summary>
		private static void ResolveAppbackcall ()
		{
			/*
			 * Name: 浮悬窗
			 * Function: _statusUptime
			 */
			if (Common.UnityContainer.IsRegistered<ICqStatus> ("浮悬窗") == true)
			{
				Status_Revenue = Common.UnityContainer.Resolve<ICqStatus> ("浮悬窗").CqStatus;
			}


		}
        #endregion

		#region --导出方法--
		/*
		 * Id: 1
		 * Name: 浮悬窗
		 * Title: Revenue
		 * Function: _statusUptime
		 * Period: 1000
		 */
		public static event EventHandler<CqStatusEventArgs> Status_Revenue;
		[DllExport (ExportName = "_statusUptime", CallingConvention = CallingConvention.StdCall)]
		private static string Evnet__statusUptime ()
		{
			CqStatusEventArgs args = new CqStatusEventArgs (1, "浮悬窗", "Revenue", 1000);
			if (Status_Revenue != null)
			{
				Status_Revenue (null, args);
			}
			return args.FloatWindowData;
		}


        #endregion
	}
}

