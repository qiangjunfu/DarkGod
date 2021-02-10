/********************************************
 *Copyright(C) 2021 by DefaultCompany 
 *All rights reserved. 
 *FileName:     LoginWnd.cs 
 *Author:       FuQiangJun 
 *Version:      1.0 
 *UnityVersion：2018.3.4f1 
 *Date:         2021-02-09 10:15:51 
 *Email:        17611473176@163.com 
 *Description:  
 *History: 
*******************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 登录窗口
/// </summary>
public class LoginWnd : WindowRoot 
{
    [SerializeField] private InputField iptAcct;
    [SerializeField] private InputField iptPass;
    [SerializeField] private Button btnEnter;
    [SerializeField] private Button btnNotice;


    /// <summary>
    /// 初始化登陆窗口
    /// </summary>
    protected override  void InitWnd()
    {
        base.InitWnd();

        //Debug.Log($"LoginWnd -> InitWnd()");
        if (PlayerPrefs.HasKey("Acct") && PlayerPrefs.HasKey("Pass"))
        {
            iptAcct.text = PlayerPrefs.GetString("Acct");
            iptPass.text = PlayerPrefs.GetString("Pass");
        }
        else
        {
            iptAcct.text = "";
            iptPass.text = "";
        }
    }
}
