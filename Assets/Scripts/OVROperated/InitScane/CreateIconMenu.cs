using UnityEngine;
using System.Collections;

public class CreateIconMenu : MyScripts
{
    private GameObject icon;

    protected override void CreateDo()
    {
        icon = MyController.CreatePrefabInTransform(transform.root, MyEnum.ScaneObjectType.icon, transform.root.position);
        icon.layer = 5;
    }

    protected override void DestroyDo()
    {

    }
}
