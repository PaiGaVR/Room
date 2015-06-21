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

    private GameObject icon;

    protected override void CreateDo()
    {
        //注册场景初始化的控制器.
        MyController.setRootController(this);

        // 初始化场景.
        ScaneSwitch(this.scaneType);

        InitScane();

        home = MyController.CreatePrefabHomeInTransform(null, MyEnum.HuXingType.modo, Vector3.zero);

        AddMeshCollider(home.transform);
    }

    void Update()
    {
        headRay.origin = transform.position;
        headRay.direction = transform.forward;
        Debug.DrawRay(headRay.origin, headRay.direction, Color.blue);
        if (home != null)
        {
            foreach (Transform tran in home.transform)
            {
                if (tran.tag.Equals("DiMianWuTi") || tran.tag.Equals("TianHuaBanWuTi"))
                {
                    if (Vector3.Distance(tran.position, transform.position) <= 3f)
                    {
                        if (tran.FindChild("icon(Clone)") != null)
                        {
                            tran.FindChild("icon(Clone)").gameObject.SetActive(true);
                            Vector3 v = transform.position - tran.FindChild("icon(Clone)").position;
                            Quaternion rotation;
                            rotation = Quaternion.LookRotation(v);
                            tran.FindChild("icon(Clone)").transform.rotation = rotation;
                        }
                    }
                    else
                    {
                        if (tran.FindChild("icon(Clone)") != null)
                        {
                            tran.FindChild("icon(Clone)").gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// 场景选择.
    /// </summary>
    /// <param name="scaneType">场景类型.</param>
    public void ScaneSwitch(MyEnum.ScaneType scaneType)
    {
        switch (scaneType)
        {
            case MyEnum.ScaneType.InitScane: break;
        }
    }

    private void AddMeshCollider(Transform transform)
    {
        foreach (Transform trans in transform)
        {
            AddIconToGameObject(trans);

            if (trans.childCount != 0)
            {
                AddMeshCollider(trans);
            }
            else
            {
                trans.gameObject.AddComponent<MeshCollider>();
            }
        }
    }

    private void AddIconToGameObject(Transform tran)
    {
        if (transform.tag.Equals("DiMianWuTi"))
        {
            icon = MyController.CreatePrefabInTransform(transform, MyEnum.ScaneObjectType.icon, new Vector3(tran.position.x, tran.position.y + 0.3f, tran.position.z));
        }
        if (transform.tag.Equals("TianHuaBanWuTi"))
        {
            icon = MyController.CreatePrefabInTransform(transform, MyEnum.ScaneObjectType.icon, new Vector3(tran.position.x, tran.position.y - 0.3f, tran.position.z));
        }

        if (transform.tag.Equals("QiangZhi") && transform.tag.Equals("Men") && transform.tag.Equals("QiangShangWuTi"))
        {
            icon = MyController.CreatePrefabInTransform(transform, MyEnum.ScaneObjectType.icon, tran.position - transform.forward.normalized);
        }

    }

    /// <summary>
    /// 初始的场景设置.
    /// </summary>
    private void InitScane()
    {
        transform.gameObject.AddComponent<InitScaneRoot>();
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
