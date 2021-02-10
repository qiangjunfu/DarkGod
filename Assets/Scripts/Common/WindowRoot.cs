/********************************************
 *Copyright(C) 2021 by DefaultCompany 
 *All rights reserved. 
 *FileName:     WindowRoot.cs 
 *Author:       FuQiangJun 
 *Version:      1.0 
 *UnityVersion：2018.3.4f1 
 *Date:         2021-02-10 02:09:42 
 *Email:        17611473176@163.com 
 *Description:  
 *History: 
*******************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 窗口基类
/// </summary>
public class WindowRoot : MonoBehaviour
{
    public ResSvc resSvc = null;
    private  AudioSvc audioSvc = null;


    /// <summary>
    /// 修改窗口显示状态
    /// </summary>
    public void SetWndState(bool isActive = true)
    {
        SetActive(this.gameObject, isActive);

        if (isActive)
        {
            InitWnd();
        }
        else
        {
            ClearWnd();
        }
    }

    /// <summary>
    /// 初始化窗口
    /// </summary>
    protected virtual void InitWnd()
    {
        resSvc = ResSvc.Instance;
        audioSvc = AudioSvc.Instance;
    }

    /// <summary>
    /// 清除窗口
    /// </summary>
    protected virtual void ClearWnd()
    {
        audioSvc = null;
        resSvc = null;
    }


    #region Tool Function
    /// <summary>
    /// 激活物体
    /// </summary>
    protected void SetActive(GameObject go, bool isActive)
    {
        go.SetActive(isActive);
    }
    /// <summary>
    /// 修改Text显示内容
    /// </summary>
    protected void SetText(Text text, string context = "")
    {
        text.text = context;
    }
    /// <summary>
    /// 修改Text显示内容
    /// </summary>
    protected void SetText(Text text, int value)
    {
        text.text = value.ToString();
    }
    /// <summary>
    /// 修改Text显示内容
    /// </summary>
    protected void SetText(Text text, float value, int index)
    {
        text.text = value.ToString($"f{index }");
    }


    #endregion 
}
