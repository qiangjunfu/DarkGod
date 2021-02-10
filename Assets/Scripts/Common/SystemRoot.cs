/********************************************
 *Copyright(C) 2021 by DefaultCompany 
 *All rights reserved. 
 *FileName:     SystemRoot.cs 
 *Author:       FuQiangJun 
 *Version:      1.0 
 *UnityVersion：2018.3.4f1 
 *Date:         2021-02-10 11:19:57 
 *Email:        17611473176@163.com 
 *Description:  
 *History: 
*******************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 业务系统基类
/// </summary>
public class SystemRoot : MonoBehaviour
{
    protected ResSvc resSvc;
    protected AudioSvc audioSvc;


    /// <summary>
    /// 初始化业务系统
    /// </summary>
    public virtual void InitSys()
    {
        resSvc = ResSvc.Instance;
        audioSvc = AudioSvc.Instance;
    }
    
}
