using UnityEngine;
using System.Collections;

/// <summary>
/// 场景初始化的控制器
/// </summary>
public class RootController : MyScripts
{
    // 初始化时的场景类型（InitScane： 刚开始的场景、TheObjectBrowserScane：物件浏览器的场景、TheObjectOperatedScane：物件操作的场景）.
    public MyEnum.ScaneType scaneType;

    // 头部射线.
    private Ray headRay;

    private GameObject home;

    protected override void CreateDo()
    {
        //注册场景初始化的控制器.
        MyController.setRootController(this);

        transform.gameObject.AddComponent<InitScaneRoot>();
    }

    void Update()
    {
        headRay.origin = transform.position;
        headRay.direction = transform.forward;
        Debug.DrawRay(headRay.origin, headRay.direction, Color.blue);
    }

    /// <summary>
    /// 获取头部射线.
    /// </summary>
    /// 
    /// <returns>头部射线.</returns>
    public Ray getHeadRay()
    {
        return headRay;
    }

    protected override void DestroyDo() 
    { 

    }
}
