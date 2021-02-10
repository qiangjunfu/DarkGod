/********************************************
 *Copyright(C) 2021 by DefaultCompany 
 *All rights reserved. 
 *FileName:     LoadingWnd.cs 
 *Author:       FuQiangJun 
 *Version:      1.0 
 *UnityVersion：2018.3.4f1 
 *Date:         2021-02-09 10:16:58 
 *Email:        17611473176@163.com 
 *Description:  
 *History: 
*******************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 场景加载窗口
/// </summary>
public class LoadingWnd : WindowRoot
{
    [SerializeField] private Text textTips;
    [SerializeField] private Slider slider;
    [SerializeField] private Text textProgress;



    protected override void InitWnd()
    {
        base.InitWnd();

        SetText(textTips, "Tips:带有霸体状态的技能在施放时可以规避控制");
        slider.value = 0;
        SetText(textProgress, (int)(slider.value * 100) + "%");
    }

    /// <summary>
    /// 修改进度条
    /// </summary>
    public void SetProgress(float progress)
    {
        slider.value = progress;
        SetText(textProgress, (int)(slider.value * 100) + "%");
    }
}
