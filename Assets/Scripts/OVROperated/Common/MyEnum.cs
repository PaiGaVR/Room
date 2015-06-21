using UnityEngine;
using System.Collections;

//================================================================================
/// 所用到的枚举类集合
///
/// 集合大部分枚举类
//================================================================================

public static class MyEnum {

    public enum HuXingType
    {
        modo
    }

    /// <summary>
    /// 场景类型.
    /// </summary>
    public enum ScaneType
    {
        InitScane
    }

    /// <summary>
    /// 场景物件的名称.
    /// </summary>
    public enum ScaneObjectType
    {
       XiangQingMenu, icon, TiHuanMenu, FunctionMenu, test, LoadMenu
    }

    /// <summary>
    /// 菜单级别.
    /// </summary>
    public enum MenuLevel
    {
        first = 0, second = 1, third = 3, other = 4
    }

    /// <summary>
    /// 模型的类型，贴地面、贴墙、和贴天花板
    /// </summary>
    public enum PlaceObjectType
    {
        DiMian, FeiDiMian, TieQiang
    }

    /// <summary>
    /// 方向
    /// </summary>
    public enum Direction
    {
        X, Y, Z
    }
}
