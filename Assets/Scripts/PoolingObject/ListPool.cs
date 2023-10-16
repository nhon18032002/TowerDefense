using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ListPool : MonoBehaviour
{
    [SerializeField] protected List<Transform> list= new List<Transform>();

    public Transform Find(string name)
    {
        if (this.list.Count <= 0) return null;
        Transform trf = this.list.Find((i) => i.name == name);
        if (trf == null) return null;
        this.list.Remove(trf);
       
        return trf;
       
    }
    public void PushToPool(Transform trf)
    {
        trf.SetParent(this.transform);
        trf.gameObject.SetActive(false);
        this.list.Add(trf);

    }
}
