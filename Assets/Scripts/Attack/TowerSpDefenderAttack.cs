using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpDefenderAttack : TowerAttack
{
    
    [SerializeField] protected TowerSpawnDefender tower;
    [SerializeField] protected int countDefender;
    [SerializeField] protected Transform objectSpawn;
    [SerializeField] protected Transform spawnPoint;
    [SerializeField] protected Collider2D colliderPath;
    public void ReduceCountDefender() => this.countDefender--;
    protected void OnEnable()
    {
        this.countDefender = 0;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
    
        this.tower = this.transform.parent.GetComponent<TowerSpawnDefender>();
      
    }
    private void Start()
    {
        this.Attack();
    }
    protected override void Attack()
    {
        StartCoroutine(IsSpawnDefender());
    }
    protected void SpawnDefender()
    {
        Vector3 randomPos = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), 0);
        Vector3 newPos = randomPos + this.spawnPoint.position;
        if (Vector3.Distance(newPos, this.colliderPath.ClosestPoint(newPos)) > 0.03f)
        {
            this.SpawnDefender();
            return;
        }
        Transform newObj= DefenderSpawner.instance.Spawn(this.objectSpawn.name, this.spawnPoint.position,Quaternion.identity,newPos);
        newObj.GetComponentInChildren<DataDefender>().SetSpawner(this.transform.parent);
        newObj.gameObject.SetActive(true);
    }
    protected IEnumerator IsSpawnDefender()
    {

        while(true)
        {
            if(this.countDefender<this.dataTower._atk)
            {
                yield return new WaitForSeconds(this.dataTower._atkSpeed);
                this.countDefender++;
                this.SpawnDefender();
                
            }

            yield return null;
        }
    }
 
}
