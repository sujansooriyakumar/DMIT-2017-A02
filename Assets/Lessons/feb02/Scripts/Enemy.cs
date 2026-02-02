using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public string enemyName;
    public int HP;
    public int ATK;
    public int DEF;
    public Sightline sightline;
    public float attackDelay;

    public abstract void Patrol();
    public abstract void Attack();
    public abstract void TakeDamage();
    public abstract void Die();

    public abstract void Pursue();

    private void Update()
    {
        if (sightline.SightlineCheck())
        {
            Pursue();
        }
    }

    public IEnumerator AttackCoroutine()
    {
        while (true)
        {
            Attack();
            yield return new WaitForSeconds(attackDelay);
        }
        yield return null;
    }


}
