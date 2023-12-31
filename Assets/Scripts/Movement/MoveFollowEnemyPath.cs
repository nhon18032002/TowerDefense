using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFollowEnemyPath : BaseMovement
{
    private Coroutine myCoroutine;
    [SerializeField] protected List<Vector3> path;
    [SerializeField] protected int currentIndex;
    [SerializeField] protected Enemy enemy;
    [SerializeField] protected EnemyAttack enemyAttack;
    [SerializeField] protected Animator animator;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.enemy = this.transform.parent.GetComponent<Enemy>();
        this.enemyAttack = this.transform.parent.GetComponentInChildren<EnemyAttack>();
        this.animator = transform.parent.GetComponentInChildren<Animator>();
    }
    public void SetPath(List<Vector3> path)
    {
        this.path = path;
        this.currentIndex=0;
    }
 
    IEnumerator MoveWithPath()
    {
        while (this.currentIndex != this.path.Count - 1)
        {
            if (Time.timeScale == 0)
            {
               
                goto jump;
            }
            if(this.enemyAttack!=null&&this.enemyAttack._isAttack)
            {
                goto jump;
            }
            if (this.path.Count !=0)
            {
                if (this.transform.parent.position != this.path[this.currentIndex + 1])
                {                   
                    this.transform.parent.position = Vector3.MoveTowards(this.transform.parent.position, this.path[this.currentIndex + 1], this.enemy.dataEnemy._runSpeed*Time.deltaTime);
                    Vector3 distance = this.path[this.currentIndex + 1] - transform.parent.position;
                    float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
                    if (angle < 90 && angle > -90) this.animator.transform.localScale = new Vector3(1,1, 0);
                    else this.animator.transform.localScale = new Vector3(-1,1, 0);
                }
                else this.currentIndex++;
            }
            jump:
            yield return null;
        }
        EnemyManager.instance.listPool.PushToPool(this.transform.parent);
        Player.instance.DecHeal(1);
        myCoroutine = null;
    }
    protected override void Move()
    {
        myCoroutine = StartCoroutine(MoveWithPath());
    }

    protected void OnEnable()
    {
        if (this.myCoroutine == null) this.Move();
    }
    protected override void OnDisable()
    {
        this.myCoroutine = null;
        this.currentIndex = 0;
    }
    
}
