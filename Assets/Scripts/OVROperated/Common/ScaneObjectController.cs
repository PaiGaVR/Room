﻿using UnityEngine;
using System.Collections;

/// <summary>
/// 场景物件的创建、开启等工具类.
/// </summary>
public class ScaneObjectController : MyScripts
{

    // 自定义预设文件的路径.
    public readonly string myMenuPrefabPath = "NGUIMenu/";
    public readonly string myModelPrefabPath = "ModelPrefabs/";

    /// <summary>
    /// 在指定的Transform下创建菜单.
    /// </summary>
    /// 
    /// <param name="parent">指定的Transform,即父对象.</param>
    /// <param name="scaneObjectName">场景工具名称.</param>
    public GameObject CreatePrefabInTransform(Transform parent, MyEnum.ScaneObjectType scaneObjectName, Vector3 position)
    {
        GameObject myObject = Instantiate(Resources.Load(myMenuPrefabPath + scaneObjectName)) as GameObject;
        myObject.transform.localPosition = position;
        myObject.transform.parent = parent;
        return myObject;
    }
    /// <summary>
    ///  模型的预设物体
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="scaneObjectName"></param>
    /// <param name="position"></param>
    public GameObject CreatePrefabHomeInTransform(Transform parent, MyEnum.HuXingType scaneObjectName, Vector3 position)
    {
        GameObject myObject = Instantiate(Resources.Load(myModelPrefabPath + scaneObjectName)) as GameObject;
        myObject.transform.localPosition = position;
        myObject.transform.parent = parent;
        return myObject;
    }

    protected override void CreateDo()
    {
        // 注册场景物件控制器.
        MyController.setScaneObjectController(this);
    }

    protected override void DestroyDo(){}
}
