using ETModel;
using System;
using UnityEngine;

namespace ETHotfix
{
    /// <summary>
    /// UI窗体主控组件需要继承此类
    /// </summary>
    public abstract class UIBaseComponent : Component
    {
        public event Action OnCloseOneTime;
        public event Action OnShow;
        public event Action OnClose;
        private Component parent;
        public Component Parent
        {
            get
            {
                return this.parent;
            }
            set
            {
                this.parent = value;

#if !SERVER
                if (this.parent == null)
                {
                    this.GameObject.transform.SetParent(Global.transform, false);
                    return;
                }

                if (this.GameObject != null && this.parent.GameObject != null)
                {
                    this.GameObject.transform.SetParent(this.parent.GameObject.transform, false);
                }
#endif
            }
        }
        public bool InShow { get { return Layer != WindowLayer.UIHiden; } }
        public string Layer { get; set; } = WindowLayer.UIHiden;

        public virtual void Show()
        {
            GetParent<UI>().GameObject.SetActive(true);
            OnShow?.Invoke();
        }

        public virtual void Close()
        {
            GetParent<UI>().GameObject.SetActive(false);

            if (OnCloseOneTime != null)
            {
                OnCloseOneTime.Invoke();
                OnCloseOneTime = null;
            }
            OnClose?.Invoke();
        }

        public override void Dispose()
        {
            base.Dispose();

            OnCloseOneTime = null;
            OnShow = null;
            OnClose = null;
            Layer = WindowLayer.UIHiden;
        }
    }
}