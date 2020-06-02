/*
 *	�˴����� T4 ������� StatusExport.tt ģ������, �������˽����´�����ô�, �����޸�!
 *	
 *	���ļ�������Ŀ Json �ļ�����������������.
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
		#region --���캯��--
		/// <summary>
		/// ��̬���캯��, ע������ע��ص�
		/// </summary>
        static StatusExport ()
        {
			// �ַ�Ӧ�����¼�
			ResolveAppbackcall ();
        }
        #endregion

		#region --˽�з���--
		/// <summary>
		/// ��ȡ���е�ע����, �ַ�����Ӧ���¼�
		/// </summary>
		private static void ResolveAppbackcall ()
		{
			/*
			 * Name: ������
			 * Function: _statusUptime
			 */
			if (Common.UnityContainer.IsRegistered<ICqStatus> ("������") == true)
			{
				Status_Revenue = Common.UnityContainer.Resolve<ICqStatus> ("������").CqStatus;
			}


		}
        #endregion

		#region --��������--
		/*
		 * Id: 1
		 * Name: ������
		 * Title: Revenue
		 * Function: _statusUptime
		 * Period: 1000
		 */
		public static event EventHandler<CqStatusEventArgs> Status_Revenue;
		[DllExport (ExportName = "_statusUptime", CallingConvention = CallingConvention.StdCall)]
		private static string Evnet__statusUptime ()
		{
			CqStatusEventArgs args = new CqStatusEventArgs (1, "������", "Revenue", 1000);
			if (Status_Revenue != null)
			{
				Status_Revenue (null, args);
			}
			return args.FloatWindowData;
		}


        #endregion
	}
}

