using UnityEngine;

public class Dummy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() == null)
        {
            return;
        }

        Enemy e = collision.gameObject.GetComponent<Enemy>();
        //e.TakeDamage();
    }
}
