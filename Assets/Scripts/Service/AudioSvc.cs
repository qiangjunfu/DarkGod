/********************************************
 *Copyright(C) 2021 by DefaultCompany 
 *All rights reserved. 
 *FileName:     AudioSvc.cs 
 *Author:       FuQiangJun 
 *Version:      1.0 
 *UnityVersion：2018.3.4f1 
 *Date:         2021-02-10 10:54:53 
 *Email:        17611473176@163.com 
 *Description:  
 *History: 
*******************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 声音服务
/// </summary>
public class AudioSvc : MonoBehaviour
{
    public static AudioSvc Instance = null;
    [SerializeField] private AudioSource bgAudio;
    [SerializeField] private AudioSource uiAudio;


    public void InitSvc()
    {
        Instance = this;
        Debug.Log($"AudioSvc -> InitSvc()");
    }

    /// <summary>
    /// 播放背景音乐
    /// </summary>
    public void PlayBGMusic(string name, bool isLoop = true)
    {
        AudioClip audio = ResSvc.Instance.LoadAudio("ResAudio/" + name, true);
        if  (bgAudio .clip == null || bgAudio .clip .name != name)
        {
            bgAudio.clip = audio;
            bgAudio.loop = isLoop;
            bgAudio.Play();
        }
    }

    /// <summary>
    /// 播放ui音效
    /// </summary>
    public void PlayUIMusic (string name)
    {
        AudioClip audio  = ResSvc.Instance.LoadAudio("ResAudio/" + name, true);
        uiAudio.Play();
    }
}
