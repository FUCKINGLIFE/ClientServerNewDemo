using System;
using System.Net;
using ETModel;
using Model.Module.Demo;

namespace ETHotfix
{
    [MessageHandler(AppType.Realm)]
    public class C2R_RegisterHandler : AMRpcHandler<C2R_Register, R2C_Register>
    {
        protected override void Run(Session session, C2R_Register message, Action<R2C_Register> reply)
        {
            RunAsync(session, message, reply).Coroutine();
        }

        private async ETVoid RunAsync(Session session, C2R_Register message, Action<R2C_Register> reply)
        {
            R2C_Register response = new R2C_Register();
            try
            {
                DBProxyComponent db = Game.Scene.GetComponent<DBProxyComponent>();
                var accounts = await db.Query<Account>($"{{'UserName\':\'{ message.Account}\'}}");  //" {'UserName': '111111'} "
                if (accounts.Count > 0)
                {
                    response.Error = ErrorCode.ERR_AccountHasRegistered;
                    response.Message = "该用户名已注册";
                }
                else
                {
                    Account account = ComponentFactory.Create<Account>();
                    account.UserName = message.Account;
                    account.PassWord = message.Password;
                    await  db.Save(account);
                    response.Error = 0;
                    response.Message = "注册成功";
                }
              

                reply(response);
            }
            catch (Exception e)
            {
                ReplyError(response, e, reply);
            }
        }
    }
}