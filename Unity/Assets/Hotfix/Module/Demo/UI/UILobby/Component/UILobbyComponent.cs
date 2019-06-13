using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
	[ObjectSystem]
	public class UiLobbyComponentSystem : AwakeSystem<UILobbyComponent>
	{
		public override void Awake(UILobbyComponent self)
		{
			self.Awake();
		}
	}
	
	public class UILobbyComponent : UIBaseComponent
	{
		private GameObject enterMap;
		private Text text;
	    private GameObject backLogin;
	    
		public void Awake()
		{
			ReferenceCollector rc = this.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
			
			enterMap = rc.Get<GameObject>("EnterMap");
			enterMap.GetComponent<Button>().onClick.Add(this.EnterMap);

			this.text = rc.Get<GameObject>("Text").GetComponent<Text>();
		    backLogin = rc.Get<GameObject>("Back");
		    this.backLogin.GetComponent<Button>().onClick.Add(BackLogin);

		}
	    public override void Show()
	    {
	        base.Show();
	        Log.Debug(" ui lobby show");
	    }
	    public override void Close()
	    {
	        base.Close();
	        Log.Debug(" ui lobby Close");
        }
        private void EnterMap()
		{
		    MapHelper.EnterMapAsync().Coroutine();
		}

	    private void BackLogin()
	    {
	        Log.Debug("返回 登录");
	        LoginHelper.ExitLogin();
            Game.Scene.GetComponent<UIComponent>().Close(UIType.UILobby);
	        Game.Scene.GetComponent<UIComponent>().Create(UIType.UILogin);
        }

	}
}
