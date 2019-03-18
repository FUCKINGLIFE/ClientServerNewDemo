using ETModel;

namespace ETHotfix
{
    [Event(EventIdType.InitSceneStart)]
    public class InitSceneStart_CreateRegisterUI : AEvent
    {
        public override void Run()
        {
            UI ui = UIRegisterFactory.Create();
            Game.Scene.GetComponent<UIComponent>().Add(ui);
        }
    }
}