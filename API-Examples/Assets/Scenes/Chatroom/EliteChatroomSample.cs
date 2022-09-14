/*
 *                                   欢迎使用elite sdk！
 *本SDK（以下简称elite）实现了IM（即时通信）的所有功能，elite可以帮您快速构建属于自己的IM app。
 *
 *====================================前置准备工作=====================================
 *在使用elite之前，有以下前置操作需要开发者完成：
 *
 *1，申请appkey。
 *   申请步骤请参考“新手接入指南”：
 *   安卓：https://doc.yunxin.163.com/TM5MzM5Njk/docs/TY1OTU4NDQ?platform=android
 *   iOS：https://doc.yunxin.163.com/messaging/docs/TE2Nzg1MDg?platform=iOS
 *   windows/mac： https://doc.yunxin.163.com/messaging/docs/jEyMjc5NjI?platform=pc
 *   打开上述页面后，右上角注册、登录、创建应用(需要实名认证)，在appkey管理页面即可查看到自己的
 *   appkey。申请到appkey后，需要将appkey填写到OnLoginClick方法内,供登录时使用。
 *   649863844c871cc449f8e2488ae01f2a
 *
 *2，注册云信IM账号
 *   登录 IM 前，需注册云信 IM 账号。
 *   https://doc.yunxin.163.com/TM5MzM5Njk/docs/DQ3Nzk1MTY?platform=server
 *   申请成功后，服务端会返回accid跟token，请保存好这两个数据，并将其填到OnLoginClick方法内,
 *   供登录时使用
 *
 *3，若要使用P2P功能，则需要后台配置，允许非好友发送P2P消息
 *   默认配置下，是不允许非好友发送P2P消息的，而当前elite尚未集成添加好友相关的API,故此处需要配置，
 *   允许非好友互发P2P消息。
 *   该配置过程需要联系开发者大赛工作人员帮您处理。
 *   
 *4，若要使用聊天室功能，需要开启appkey的聊天室功能，开启后，需要调用后台接口创建聊天室，创建之后，
 *   方可加入聊天室、在聊天室中发消息。
 *   创建聊天室的链接：https://doc.yunxin.163.com/messaging/docs/jA0MzQxOTI?platform=server
 *
 *==================================elite SDK目录结构==================================
 *
 *NimEliteCSharpSDK
 *│
 *├─sdk
 *    │
 *    │  NimSdk.cs                          elite sdk主体类，包含了sdk的初始化、反初始化等方法
 *    │  INimChatroomClient.cs              聊天室接口类，提供聊天室环境的初始化、反初始化、获取聊天室服务等方法
 *    │  INimChatroomMessageBuilder.cs      工具类
 *    │  INimClient.cs                      IM客户端功能接口类，提供IM登录服务(INimAuthService)、消息服务(INimMessageService)等功能
 *    │
 *    ├─enums                              存放SDK用到的各种枚举值类型的类定义
 *    │
 *    ├─params                             存放SDK用到的各种参数结构体类型的类定义
 *    │
 *    ├─result                             存放SDK用到的各种返回值类型的类定义
 *    │
 *    └─service                            
 *            INimAuthService.cs             IM登录服务接口类，提供登录、登出、注册登录状态回调等方法，是接入IM的第一步 
 *            INimSessionService.cs          IM会话服务接口类，提供生成本地会话、查询会话等方法
 *            INimSystemMessageService.cs    IM系统消息服务接口类，提供系统消息的回调注册、发送自定义系统消息等方法           INimMessageService.cs
 *            INimPassThroughService.cs      IM透传服务接口类，开发者可忽略本接口
 *            
 *            INimChatroomService.cs         聊天室服务接口类，是聊天室功能的主要接口，提供聊天室登录服务、聊天室成员管理服务等
 *            INimChatroomAuthService.cs     聊天室登录服务接口类，提供聊天室的登录、登出、注册登录状态回调等方法
 *            INimChatroomMemberService.cs   聊天室成员服务接口类，提供聊天室成员查询、成员禁言、踢出成员等方法
 *            INimChatroomMessageService.cs  聊天室消息服务接口类，提供发送聊天室消息、查询聊天室消息、注册消息通知等方法
 *            INimChatroomPluginService.cs   聊天室插件服务接口类，用于获取登录聊天室时所需的token
 *            INimChatroomQueueService.cs    聊天室队列服务接口类，开发者可忽略本接口
 *
 *
 *本文件实现了一个简单的Sample Code,实现了聊天室的主要功能，
 *开发者可以使用本sample实现聊天室的登录、登出、发送普通聊天室消息等操作
 *
 * ===================================第一步：初始化elite===================================
 * 点击界面上的SDKInit按钮即可触发elite的初始化，该过程同时会创建nimClient以及nimChatroomClient并初始化它们。
 * 后续步骤的所有操作都要依赖于这两个client对象。
 *
 * =====================================第二步：登录SDK====================================
 * UI上填写想要登陆的账号，然后点击Login按钮即可登录到云信IM服务器，请确保您已经申请了自己的appkey并已经注册了IM账号
 * 申请步骤请见上方“前置准备工作”
 *
 * ==================================第三步：进入聊天室SDK==================================
 * UI上填写想要登陆的聊天室ID，然后点击EnterChatroom按钮即可进入聊天室，请确保您已创建了了自己的聊天室
 * 创建聊天室步骤请见上方“前置准备工作”
 * 
 * =================================第四步：发送聊天室消息==================================
 * 输入想要发送的消息内容，点击SendMessage按钮即可将消息发送到聊天室，聊天室内的其他成员即可收到您发送的消息
 */

using System;
using UnityEngine;
using NimElite;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;

public class EliteChatroomSample : MonoBehaviour
{
    //此处需要开发者填写自己申请到的appkey，申请步骤请见“前置准备工作(1)”
    string appKey = "";
    //从界面获取登录账号
    string accID = "";
    //处需要开发者填写自己账号对应的token，注册账号步骤请见“前置准备工作(2)”
    string token = "";
    //处需要开发者填写自己已经创建好的RoomID，创建聊天室步骤请见“前置准备工作(4)”
    long roomID = 0;

    INimClient nimClient;
    INimChatroomClient nimChatroomClient;
    INimChatroomService chatroomService;
    INimChatroomMessageService chatroomMessageService;
    INimAuthService authService;
    INimChatroomPluginService chatroomPluginService;
    INimChatroomAuthService chatroomAuthService;

    //Text控件，用以展示所有的聊天消息
    public Text allMessageText;
    //输入控件，用以获取输入的消息
    InputField txtMessage;

    // Start is called before the first frame update
    void Start()
    {
        _ = Loom.Current;
        txtMessage = GameObject.Find("MessageInputField").GetComponent<InputField>();

        //初始化并登录IM
        if (SDKInit())
        {
            Login();
        }
        else
        {
            Debug.Log("SDKInit failed!");
        }
    }

    void OnApplicationQuit()
    {
        Logout();

        SDKUninit();
    }

    private void RegisterAuthServiceCallback(ref INimAuthService authService)
    {
        //注册离线通知回调
        authService.RegisterDisconnect(() => {
            Debug.Log("AuthService Disconnected!");
        });
        //注册被踢通知回调
        authService.RegisterKickout((NimKickDetail arg) => {
            Debug.Log("AuthService Kickout， description: " + arg.description);
        });
    }

    private void RegisterChatroomMessageServiceCallback(ref INimChatroomMessageService chatroomMessageService)
    {
        //注册接收消息回调
        chatroomMessageService.RegisterReceiveMessage((NimChatroomMessage arg) => {
            Debug.Log($"ReceiveMessage, from: {arg.fromID}");
            AppendMessageToUI(arg.fromID + " :\n" + arg.messageAttach);
        });
        //注册接收批量消息回调
        chatroomMessageService.RegisterReceiveMessages((List<NimChatroomMessage> arg) =>{
            Debug.Log("ReceiveMessages");
            foreach(var msg in arg)
            {
                AppendMessageToUI(msg.fromID + " :\n" + msg.messageAttach);
            }
        });
    }
    public bool SDKInit()
    {
        NimSDKInitializeParam param = new NimSDKInitializeParam
        {
            //设置SDK的data目录，用以存放SDK的日志等文件
            appDataPath = Application.persistentDataPath + "/nim_data",
            appInstallPath = Application.persistentDataPath
        };

        Debug.Log("NimSdk.CreateClient() appDataPath: " + param.appDataPath);

        //1,初始化SDK
        NimSdk.SdkInit(param);

        //2,创建INimClient
        nimClient = NimSdk.CreateClient();

        //3,初始化INimClient，一般情况下，initConfig内的字段全部使用默认值即可
        NimSdkConfig initConfig = new NimSdkConfig();
        bool initRet = nimClient.Initialize(initConfig);
        Debug.Log($"Initialize nimClient done, result: {initRet}");

        //4,创建INimChatroomClient
        nimChatroomClient = NimSdk.CreateChatroomClient();

        //5,初始化INimChatroomClient
        initRet = nimChatroomClient.Initialize();
        Debug.Log($"Initialize nimClient done, result: {initRet}");

        //6,注册登录状态回调，以接受登陆状态变更等通知
        authService = nimClient.GetAuthService();
        RegisterAuthServiceCallback(ref authService);

        //7,注册聊天室消息回调，方可接收到聊天室消息、并将消息展示到UI
        chatroomService = nimChatroomClient.GetChatroomService();
        chatroomMessageService = chatroomService.GetMessageService();
        chatroomAuthService = chatroomService.GetAuthService();
        chatroomPluginService = nimClient.GetChatroomPluginService();
        RegisterChatroomMessageServiceCallback(ref chatroomMessageService);

        return initRet;
    }
    public void SDKUninit()
    {
        NimSdk.SdkUninit();
    }
    public void Login()
    {
        if (nimClient == null)
        {
            Debug.Log("Fatal Error: nimClient == null!!!");
            return;
        }

        //构造Login所需参数
        NimAuthInfo authInfo = new NimAuthInfo();
        authInfo.appKey = appKey;
        authInfo.accid = accID;
        authInfo.token = token;

        //登录IM
        authService.Login(authInfo, (NimLoginCallbackParam arg) => {
            //登录过程一共有4个阶段(NimLoginStep)，每个阶段都会回调回来
            Debug.Log($"AuthService login， step: {arg.step}， code: {arg.code}，message： {arg.message}");
        });
    }
    public void Logout()
    {
        if (nimClient == null)
        {
            Debug.Log("Fatal Error: nimClient == null!!!");
            return;
        }


        //登出IM
        authService.Logout((NimCallbackParam arg) => {
            Debug.Log($"AuthService login， code: {arg.code}, message: {arg.message}");
        });
    }
    /*
     * 加入聊天室
     */
    public void OnEnterChatroomClick()
    {
        if (nimClient == null)
        {
            Debug.Log("Fatal Error: nimClient == null!!!");
            return;
        }

        if (nimChatroomClient == null)
        {
            Debug.Log("Fatal Error: nimChatroomClient == null!!!");
            return;
        }

        
        NimChatroomGetEnterTokenParam getEnterTokenParam = new NimChatroomGetEnterTokenParam();

        getEnterTokenParam.roomID = roomID;

        //Enter之前，需要先获取Token，在获取Token的回调中再调用Enter
        chatroomPluginService.GetChatroomEnterToken(getEnterTokenParam, (NimChatroomGetEnterTokenResponse arg) => {
            Debug.Log($"GetChatroomEnterToken return, code: {arg.code}, token: {arg.token}");
            if (arg.code != NimEMResultCode.Success)
                return;

            NimChatroomEnterParam enterParam = new NimChatroomEnterParam();
            enterParam.roomID = getEnterTokenParam.roomID;
            //此处昵称使用登录账号，开发者可以自由设置的自己的昵称
            enterParam.nickname = accID;
            enterParam.token = arg.token;

            chatroomAuthService.Enter(enterParam, (NimChatroomEnterResult enterResult) => {
                Debug.Log("Chatroom Enter return, code: " + enterResult.code);
            });
        });
    }
    private void AppendMessageToUI(string msg)
    {
        //更新UI的操作需要在主线程完成，QueueOnMainThread方法会将任务投递到主线程执行
        Loom.QueueOnMainThread(() => {
            string cur = allMessageText.text;
            StringBuilder sb = new StringBuilder();
            sb.Append(cur);
            sb.AppendLine(msg);
            allMessageText.text = sb.ToString();
        });
    }
    public void OnExitChatroomClick()
    {
        INimChatroomAuthService chatroomAuthService = chatroomService.GetAuthService();

        chatroomAuthService.Exit((NimCallbackParam arg) =>{
            Debug.Log("Chatroom Exit return, code: " + arg.code);
        });
    }

    /*
     * 发送一条普通聊天室消息
     */
    public void OnSendMessageClick()
    {

        NimChatroomSendMessageParam message = new NimChatroomSendMessageParam();
        //将要发送的消息内容,聊天室消息内容放在messageAttach中
        message.messageAttach = txtMessage.text;
        message.messageType = NimEMMessageType.Text;

        chatroomMessageService.SendMessage(message, (NimChatroomSendMessageResult arg) => {
            if(NimEMResultCode.Success != arg.code)
            {
                Debug.Log("SendMessage error, code: " + arg.code);
                return;
            }

            Debug.Log("SendMessage success!");
            //将发送成功的消息更新到UI，需要在主线程执行更新
            AppendMessageToUI(arg.message.fromNick + ": \n" + arg.message.messageAttach);
        });
    }
}
