## 简介
_Other Languages: [English](README.md)_

本开源示例项目演示了不同场景下，`Elite SDK`的集成过程。

## 目录结构
```
├─Assets
│  ├─Editor                     // 编辑器设置目录
│  ├─Plugins                    // 插件文件夹，放置个平台app运行时所需的库文件等
│  │  ├─Android                 // 安卓平台库文件
│  │  ├─iOS                     // iOS平台库文件
│  │  └─x86_64                  // win平台库文件
│  ├─Scenes                     // 场景文件夹，放置各场景的 .unity 文件以及对应的 .cs文件
│  │  ├─Chatroom                // 普通聊天室场景，用以展示基本的聊天室消息的接收、发送。
│  │  ├─ChatroomLocation        // 范围消息场景，用以展示基本的聊天室范围消息的接收、发送。
│  │  ├─ChatroomTag             // 定向消息场景，用以展示基本的聊天室定向消息的接收、发送。
│  │  └─P2P                     // 点对点消息场景，用以展示基本的点对点消息的接收、发送。
│  └─Scripts
├─Packages
└─ProjectSettings
```
## 运行示例项目

### 开发环境要求

在开始运行示例项目之前，请确保开发环境满足以下要求：

| 环境要求 | 说明 |
|--------|--------|
| Unity Editor 版本 | 2019.4.30f1及以上版本 |


### 前提条件
- [已创建应用并获取`App Key`](https://doc.yunxin.163.com/nertc/docs/DE3NDM0NTI?platform=unity)
- 已联系网易云信工作人员开通相关能力，并[注册自己的IM 账号](https://doc.yunxin.163.com/messaging/docs/jMwMTQxODk?platform=android)
- [已下载Unity IM SDK](https://yx-web-nosdn.netease.im/package/1663060266301/elite_unity_sdk_0.3.0.7z?download=elite_unity_sdk_0.3.0.7z)

### 运行示例项目(以windows平台下普通聊天室场景为例)
1. [**创建聊天室**](https://doc.yunxin.163.com/messaging/docs/jA0MzQxOTI?platform=server) 根据页面步骤，发送Post请求到服务端,即可创建自己的聊天室
2. 将`App Key`、账号（`accid`）、`token`、`roomID`填到`EliteChatroomSample.cs`文件的类成员中
3. 打开unity hub, 导入sample目录，用editer打开sample
4. 点击`Import package`=>`Custom Package...`, 导入`elite_unity_sdk.unitypackage`
5. 打开`EliteChatroomScene`，点击Play按钮，即可运行本sample。

### 注意
安卓平台暂时仅支持arm64架构