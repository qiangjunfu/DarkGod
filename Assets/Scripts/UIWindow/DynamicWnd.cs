/********************************************
 *Copyright(C) 2021 by DefaultCompany 
 *All rights reserved. 
 *FileName:     DynamicWnd.cs 
 *Author:       FuQiangJun 
 *Version:      1.0 
 *UnityVersion：2018.3.4f1 
 *Date:         2021-02-10 11:33:35 
 *Email:        17611473176@163.com 
 *Description:  
 *History: 
*******************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 动态UI窗口
/// </summary>
public class DynamicWnd : WindowRoot
{
    [SerializeField] private Animation tipsAni;
    [SerializeField] private Text textTips;
    /// <summary>
    /// 提示信息队列, 不被新提示覆盖
    /// </summary>
    private Queue<string> tipsQue = new Queue<string>();
    private bool isTipsShow = false;


    protected override void InitWnd()
    {
        base.InitWnd();
        SetActive(textTips.gameObject, false);
    }


    private void Update()
    {
        if (tipsQue.Count > 0 && isTipsShow == false)
        {
            lock (tipsQue)
            {
                isTipsShow = true;
                string tips = tipsQue.Dequeue();
                SetTips(tips);
            }
        }
    }


    /// <summary>
    /// 添加提示信息到队列
    /// </summary>
    public void AddTips(string tips)
    {
        lock (tipsQue)
        {
            tipsQue.Enqueue(tips);
        }
    }

    /// <summary>
    /// 显示动态提示框信息
    /// </summary>
    private void SetTips(string tips)
    {
        SetActive(textTips.gameObject, true);
        SetText(textTips, tips);

        AnimationClip clip = tipsAni.GetClip("TipsShowAni");
        tipsAni.Play();

        StartCoroutine(AniPlayDone(clip.length, PlayDoneCallback));
    }

    private void PlayDoneCallback()
    {
        isTipsShow = false;
        SetActive(textTips.gameObject, false);
    }


    private IEnumerator AniPlayDone(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        if (action != null)
        {
            action();
        }
    }
}
