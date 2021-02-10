/********************************************
 *Copyright(C) 2021 by DefaultCompany 
 *All rights reserved. 
 *FileName:     ResSvc.cs 
 *Author:       FuQiangJun 
 *Version:      1.0 
 *UnityVersion：2018.3.4f1 
 *Date:         2021-02-09 09:45:11 
 *Email:        17611473176@163.com 
 *Description:  资源加载服务
 *History: 
*******************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 资源加载服务
/// </summary>
public class ResSvc : MonoBehaviour
{
    public static ResSvc Instance = null;
    private Action prgCBAction = null;
    private Dictionary<string, AudioClip> adDic = new Dictionary<string, AudioClip>();


    /// <summary>
    /// 初始化资源加载
    /// </summary>
    public void InitSvc()
    {
        Instance = this;
        Debug.Log($"ResSvc -> InitSvc()");

    }

    private void Update()
    {
        if (prgCBAction != null)
        {
            prgCBAction();
        }
    }

    /// <summary>
    /// 异步加载场景
    /// </summary>
    public void AsyncLoadScene(string sceneName, Action loaded = null)
    {
        GameRoot.Instance.loadingWnd.SetWndState();

        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName);

        prgCBAction = (() =>
        {
            float value = ao.progress;
            GameRoot.Instance.loadingWnd.SetProgress(value);
            if (value >= 1)
            {
                prgCBAction = null;
                ao = null;
                GameRoot.Instance.loadingWnd.SetWndState(false);
                //LoginSys.Instance.OpenLoginWind();
                if (loaded != null)
                {
                    loaded();
                }
            }
        });
    }


    /// <summary>
    /// 加载音频
    /// </summary>
    public AudioClip LoadAudio(string path, bool cache = false)
    {
        AudioClip ac = null;
        if (adDic.ContainsKey(path))
        {
            ac = adDic[path];
        }
        else
        {
            ac = Resources.Load<AudioClip>(path);

            if (cache)
            {
                adDic.Add(path, ac);
            }
        }

        return ac;
    }
}
