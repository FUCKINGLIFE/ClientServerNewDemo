using System;
using System.Net;
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
	[ObjectSystem]
	public class UiLoginComponentSystem : AwakeSystem<UILoginComponent>
	{
		public override void Awake(UILoginComponent self)
		{
			self.Awake();
		}
	}
	
	public class UILoginComponent: UIBaseComponent
	{
		private GameObject account;
		private GameObject loginBtn;

		public void Awake()
		{
		    ReferenceCollector rc = this.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            loginBtn = rc.Get<GameObject>("LoginBtn");
			loginBtn.GetComponent<Button>().onClick.Add(OnLogin);
			this.account = rc.Get<GameObject>("Account");
		}
	    //每次Show窗体都会调用，通常用于初始化界面
	    public override void Show()
	    {
	        base.Show();

	        //展示界面逻辑
	        Log.Debug(" ui login show");
	    }

	    //关闭时调用
	    public override void Close()
	    {
	        base.Close();

            //关闭界面逻辑
	        Log.Debug(" ui login Close");
        }
        public void OnLogin()
		{
		    Log.Debug("点击登录按钮");
			LoginHelper.OnLoginAsync(this.account.GetComponent<InputField>().text).Coroutine();
		}
	    
	    
	}
}
