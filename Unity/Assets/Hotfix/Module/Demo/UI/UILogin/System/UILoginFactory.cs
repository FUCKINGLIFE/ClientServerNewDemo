using System;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [UIFactory(UIType.UILogin)]
    public  class UILoginFactory :IUIFactory
    {
  //       public static UI Create()
  //       {
	 //        try
	 //        {
		// 		ResourcesComponent resourcesComponent = ETModel.Game.Scene.GetComponent<ResourcesComponent>();
		// 		resourcesComponent.LoadBundle(UIType.UILogin.StringToAB());
		// 		GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset(UIType.UILogin.StringToAB(), UIType.UILogin);
		// 		GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject);
  //               UI ui = ComponentFactory.Create<UI, string, GameObject>(UIType.UILogin, gameObject, false);
	 //            // ui.AddComponent<UILoginComponent>();
	 //            ui.AddUiComponent<UILoginComponent>();
	 //            Game.Scene.GetComponent<UIComponent>().Create(UIType.UILogin);
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
                    resourcesComponent.LoadBundle(type.StringToAB());
                    GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset(type.StringToAB(), type);
                    GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject);
                    gameObject.layer = LayerMask.NameToLayer(LayerNames.UI);
                    UI ui = ComponentFactory.Create<UI, string, GameObject>(type, gameObject, false);
                    ui.AddUiComponent<UILoginComponent,int>(1);
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
                ETModel.Game.Scene.GetComponent<ResourcesComponent>().UnloadBundle(type.StringToAB());
            }
        }
}