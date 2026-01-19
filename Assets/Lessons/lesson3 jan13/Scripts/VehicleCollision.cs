using UnityEngine;
using UnityEngine.Events;

public class VehicleCollision : MonoBehaviour
{
    string tagToCheck;
    public UnityEvent OnCollision;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != tagToCheck) return;
        OnCollision?.Invoke();
    }
}
