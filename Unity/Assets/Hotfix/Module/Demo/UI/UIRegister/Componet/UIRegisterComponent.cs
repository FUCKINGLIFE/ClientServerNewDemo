using System;
using System.Net;
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
    [ObjectSystem]
    public class UIRegisterComponentSystem : AwakeSystem<UIRegisterComponent>
    {
        public override void Awake(UIRegisterComponent self)
        {
            self.Awake();
        }
    }
    public class UIRegisterComponent : Component
    {
        private GameObject account;
        private GameObject password;
        private GameObject registerBtn;

        public void Awake()
        {
            ReferenceCollector rc = this.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            registerBtn = rc.Get<GameObject>("RegisterBtn");
            registerBtn.GetComponent<Button>().onClick.Add(OnRegister);
            account = rc.Get<GameObject>("Account");
            password = rc.Get<GameObject>("Password");
        }

        void OnRegister()
        {
            RegisterHelper.OnRegisterAsync(account.GetComponent<InputField>().text, password.GetComponent<InputField>().text).Coroutine();
        }
    }
}
