using System;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [UIFactory(UIType.UILobby)]
    public  class UILobbyFactory:IUIFactory
    {
        //       public static UI Create()
        //       {
        //        try
        //        {
        // 		ResourcesComponent resourcesComponent = ETModel.Game.Scene.GetComponent<ResourcesComponent>();
        //         resourcesComponent.LoadBundle(UIType.UILobby.StringToAB());
        // 		GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset(UIType.UILobby.StringToAB(), UIType.UILobby);
        // 		GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject);
        //         UI ui = ComponentFactory.Create<UI, string, GameObject>(UIType.UILobby, gameObject, false);
        //
        // 		ui.AddUiComponent<UILobbyComponent>();
        //            Game.Scene.GetComponent<UIComponent>().Add(ui);
        //               return ui;
        //        }
        //        catch (Exception e)
        //        {
        // 		Log.Error(e);
        //         return null;
        //        }
        // }

        public UI Create(Scene scene, string type, GameObject parent)
        {
            try
            {
                ResourcesComponent resourcesComponent = ETModel.Game.Scene.GetComponent<ResourcesComponent>();
                resourcesComponent.LoadBundle($"{type}.unity3d");
                GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset(type.StringToAB(), type);
                GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject);
                gameObject.layer = LayerMask.NameToLayer(LayerNames.UI);
                UI ui = ComponentFactory.Create<UI, string, GameObject>(type, gameObject, false);
                ui.AddUiComponent<UILobbyComponent>();
                return ui;
            }
            catch (Exception e)
            {
                Log.Error(e.ToStr());
                return null;
            }
        }

        public void Remove(string type)
        {
            ETModel.Game.Scene.GetComponent<ResourcesComponent>().UnloadBundle($"{type}.unity3d");
        }

    }
}