/********************************************
 *Copyright(C) 2021 by DefaultCompany 
 *All rights reserved. 
 *FileName:     Test111.cs 
 *Author:       FuQiangJun 
 *Version:      1.0 
 *UnityVersion：2018.3.4f1 
 *Date:         2021-02-10 02:35:48 
 *Email:        17611473176@163.com 
 *Description:  
 *History: 
*******************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test111 : MonoBehaviour
{
    public float f = 0.32843f;
    public int index = 0;

    void Start()
    {
        
    }

   
    void Update()
    {
       string s  = f.ToString($"f{index }");
        Debug.Log(s);
    }
}
