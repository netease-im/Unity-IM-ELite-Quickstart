## Overview
_Other Languages: [简体中文](README_zh_CN.md)_

The sample project allows you to integrate `Elite SDK` for a variety of Unity scenes. 

## Folder structure
```
├─Assets
│  ├─Editor                     // Editor settings
│  ├─Plugins                    // Plugins folder that contains libraries required for supported platforms
│  │  ├─Android                 // libraries for Android
│  │  ├─iOS                     // libraries for iOS
│  │  └─x86_64                  // libraries for Windows
│  ├─Scenes                     // Scene folder that contains files for scenes with .unity and .cs extensions
│  │  ├─Chatroom                // Generic chat room, used for basic messaging in chat rooms.
│  │  ├─ChatroomLocation        // Location-specific messaging, used for basic messaging for specific locations in chat rooms.
│  │  ├─ChatroomTag             // Directional messaging, used for sending directional messages in chat rooms.
│  │  └─P2P                     // P2P messaging, used for basic end-to-end messaging.
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
5. Open `EliteChatroomScene`, Click the Play button and run the sample app. 

### Note
The SDK is only supported in the Arm64 Android platform.
