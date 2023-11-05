using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderCollider : ColliderCompatOnPath
{
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.attackOnPath =transform.parent.GetComponentInChildren<DefenderAttack>();
    }
   
}