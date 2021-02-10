/********************************************
 *Copyright(C) 2021 by DefaultCompany 
 *All rights reserved. 
 *FileName:     SingleTon.cs 
 *Author:       FuQiangJun 
 *Version:      1.0 
 *UnityVersion：2018.3.4f1 
 *Date:         2021-02-09 10:05:14 
 *Email:        17611473176@163.com 
 *Description:  
 *History: 
*******************************************/


public class SingleTon<T> where T : SingleTon<T>
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                var ctor = typeof(T).GetConstructor(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic, null, new System.Type[0], null);

                if (ctor == null)
                {
                    throw new System.NullReferenceException("这个类必须有一个私有的无参的构造函数!!!");
                }

                instance = (T)ctor.Invoke(null);
            }

            return instance;
        }
    }

}