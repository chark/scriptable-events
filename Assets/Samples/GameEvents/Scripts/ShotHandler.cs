using UnityEngine;
using UnityEngine.Events;

public class ShotHandler : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onShot = default;

    public void HandleShot(Transform shot)
    {
        Destroy(shot.gameObject);
        onShot.Invoke();
    }
}
