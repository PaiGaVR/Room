using UnityEngine;
using System.Collections;

//================================================================================
/// 初始化场景脚本
///
/// 初始化场景脚本，加载选择球，和菜单MyEnum.ScaneObjectType.Menu
//================================================================================

public class InitScaneRoot : MyScripts
{

    /// <summary>
    /// 编辑场景中的头瞄脚本.
    /// </summary>
    private InitHead initHead;

    private GameObject icon;

    private bool flag = true;

    protected override void CreateDo()
    {
        MyController.setInitScaneRoot(this);

        initHead = transform.gameObject.AddComponent<InitHead>();
    }

    public GameObject getIcon()
    {
        return icon;
    }

    void Update()
    {
        if (!flag)
        {
            Destroy(initHead);
        }
    }

    public void turn(bool flag)
    {
        this.flag = flag;
    }

    public InitHead getInitHeadScripts()
    {
        return initHead;
    }

    protected override void DestroyDo()
    {
        MyController.setInitScaneRoot(null);
    }
}
