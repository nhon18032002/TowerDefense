using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : AdminMonoBehaviour
{
    public Transform tData;
    public Transform tCollider;

    
    public virtual void SetData() { }

    protected override void LoadData()
    {
        base.LoadData();
        this.tData = this.transform.Find("Data");
        this.tCollider = this.transform.Find("tCollider");
        
    }

}
