/********************************************
 *Copyright(C) 2021 by DefaultCompany 
 *All rights reserved. 
 *FileName:     LoginSys.cs 
 *Author:       FuQiangJun 
 *Version:      1.0 
 *UnityVersion：2018.3.4f1 
 *Date:         2021-02-09 09:35:22 
 *Email:        17611473176@163.com 
 *Description:  
 *History: 
*******************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 登陆系统
/// </summary>
public class LoginSys : SystemRoot
{
    public static LoginSys Instance = null;
    [Header("登录窗口")] [SerializeField] private LoginWnd loginWnd;

    /// <summary>
    /// 初始化登陆系统
    /// </summary>
    public override  void InitSys()
    {
        base.InitSys();
        Instance = this;

        Debug.Log($"LoginSys -> InitSys()");
    }


    /// <summary>
    /// 进入登陆场景
    /// </summary>
    public void EnterLogin()
    {
        resSvc .AsyncLoadScene(Constants.SceneLogin, LoadCompletedCallback);
    }

    private void LoadCompletedCallback()
    {
        OpenLoginWind();
    }

    public void OpenLoginWind()
    {
        loginWnd.SetWndState();
        audioSvc.PlayBGMusic(Constants.BGLogin);
    }
}
