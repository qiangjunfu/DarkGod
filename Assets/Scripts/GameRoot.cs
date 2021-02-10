/********************************************
 *Copyright(C) 2021 by DefaultCompany 
 *All rights reserved. 
 *FileName:     GameRoot.cs 
 *Author:       FuQiangJun 
 *Version:      1.0 
 *UnityVersion：2018.3.4f1 
 *Date:         2021-02-09 09:33:14 
 *Email:        17611473176@163.com 
 *Description:  程序重当前脚本启动, 所有系统统一初始化
 *History: 
*******************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏根节点
/// </summary>
public class GameRoot : MonoSingleTon<GameRoot>
{
    [Header("加载窗口")] public LoadingWnd loadingWnd;
    [Header("动态提示框窗口")] public DynamicWnd dynamicWnd;


    void Start()
    {
        Debug.Log($"GameRoot -> Start()");

        ClearUIRoot();
        Init();
    }

    private void Init ()
    {
        //服务模块初始化
        ResSvc resSvc = GetComponent<ResSvc>();
        resSvc.InitSvc();
        AudioSvc audioSvc = GetComponent<AudioSvc>();
        audioSvc.InitSvc();

        //业务系统
        LoginSys loginSys = GetComponent<LoginSys>();
        loginSys.InitSys();

        //进入登陆场景
        loginSys.EnterLogin();

    }

    private void ClearUIRoot()
    {
        Transform canvas = transform.Find("Canvas");
        for (int i = 0; i < canvas.childCount ; i++)
        {
            canvas.GetChild(i).gameObject.SetActive(false);
        }
        dynamicWnd.gameObject.SetActive(true);
    }

    /// <summary>
    /// 添加提示信息到队列
    /// </summary>
    public static void AddTips(string tips)
    {
        Instance.dynamicWnd.AddTips(tips);
    }
}
