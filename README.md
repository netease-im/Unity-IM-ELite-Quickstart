## Overview
_Other Languages: [简体中文](README_zh_CN.md)_

The sample project allows you to integrate Elite SDK for a variety of Unity scenes. Four Unity scenes are available in the sample project:

>* Private messaging (P2P) in the sample\Assets\Scenes\P2P folder, used for basic end-to-end messaging.
>* Generic chat room in the sample\Assets\Scenes\Charoom folder, used for basic messaging in chat rooms.
>* Directional messaging in chat rooms in the sample\Assets\Scenes\CharoomTag folder, used for sending *directional* messages in chat rooms.
>* Location-specific messaging in chat rooms in the sample\Assets\Scenes\CharoomLocation folder, used for basic messaging for *specific locations* in chat rooms.

## Folder structure
```
├─Assets
│  ├─Editor                     // Editor settings
│  ├─Plugins                    // Plugins folder that contains libraries required for supported platforms
│  │  ├─Android                 // libraries for Android
│  │  ├─iOS                     // libraries for iOS
│  │  └─x86_64                  // libraries for Windows
│  ├─Scenes                     // Scene folder that contains files for scenes with .unity and .cs extensions
│  │  ├─Chatroom                // Generic chat room
│  │  ├─ChatroomLocation        // Chat room with location-specific messaging
│  │  ├─ChatroomTag             // Chat room with directional messaging
│  │  └─P2P                     // P2P messaging
│  └─Scripts
├─Packages
└─ProjectSettings
```

## Run the demo project

### Development environment requirements

Before starting the demo project, make sure your development environment meets the following requirements:

| Environment | Description |
|--------|--------|
| Unity Editor | 2019.4.30f1 or later |


### Prerequisites

- [Create a project and get `App Key`](https://doc.yunxin.163.com/nertc/docs/DE3NDM0NTI?platform=unity)
- You have contacted CommsEase technical support, activated required services and [signed up your IM account](https://doc.yunxin.163.com/messaging/docs/jMwMTQxODk?platform=android).
- [NIM SDK for Unity downloaded](https://yx-web-nosdn.netease.im/package/1663060266301/elite_unity_sdk_0.3.0.7z?download=elite_unity_sdk_0.3.0.7z)

### Run the sample project (A generic chat room on Windows)
1. [**Create a chat room**](https://doc.yunxin.163.com/messaging/docs/jA0MzQxOTI?platform=server)
Create a chat room by sending a POST request.
2. Specify the `AppKey`, `account`(`accid`) , `token` and `roomID` to the class member in `EliteChatroomSample.cs`.
3. Open Unity Hub and import the sample directory. Open the sample with unity editor.
4. Click `Import package`=>`Custom Package...` menu，import `elite_unity_sdk.unitypackage`.
5. Open `EliteChatroomScene`, Click the Play button and run the sample app. Click SDKInit to initialize the SDK and log in to the system using your IM account. Create a chat room with a specific ID and join the chat room. Then, you can send text messages in the chat room.

### Note
The sdk is only support Arm64 in android platform
