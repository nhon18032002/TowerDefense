using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDenfense : MonoBehaviour
{  
    public DataTowerDefense data;
    public TowerAttack attack;
    protected virtual void Awake() => this.LoadComponent();
    
    protected virtual void LoadComponent()
    {
       
        this.data = transform.Find("Data").GetComponent<DataTowerDefense>();
    }
}
