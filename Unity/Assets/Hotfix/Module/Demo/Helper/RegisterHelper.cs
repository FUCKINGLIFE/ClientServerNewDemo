using System;
using ETModel;

namespace ETHotfix
{
    public static class RegisterHelper
    {
        public static async ETVoid OnRegisterAsync(string account, string password)
        {
            try
            {
                // 创建一个ETModel层的Session
                ETModel.Session session = ETModel.Game.Scene.GetComponent<NetOuterComponent>().Create(GlobalConfigComponent.Instance.GlobalProto.Address);

                // 创建一个ETHotfix层的Session, ETHotfix的Session会通过ETModel层的Session发送消息
                Session realmSession = ComponentFactory.Create<Session, ETModel.Session>(session);
                R2C_Register r2CRegister = (R2C_Register)await realmSession.Call(new C2R_Register() { Account = account, Password = password });
                realmSession.Dispose();
                Log.Info(r2CRegister.Message + r2CRegister.Error);
                if (r2CRegister.Error == 0)
                {
                    Game.EventSystem.Run(EventIdType.RegisterFinish);
                }
                else if (r2CRegister.Error == ErrorCode.ERR_AccountHasRegistered)
                {
                    Log.Info(r2CRegister.Message);
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}
