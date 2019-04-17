using ETModel;

namespace ETHotfix
{
	[Event(EventIdType.LoginFinish)]
	public class LoginFinish_CreateLobbyUI: AEvent
	{
		public override void Run()
		{
            // UILobbyFactory.Create();
		    Game.Scene.GetComponent<UIComponent>().Create(UIType.UILobby);
        }
	}
}
