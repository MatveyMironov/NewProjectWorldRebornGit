using UnityEngine;

public class TransformFollowerMB : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void OnEnable()
    {
        if (target == null) { return; }
        transform.position = target.position;
    }

    private void Update()
    {
        if (target == null) { return; }
        transform.position = target.position;
    }

    public void AssignFollowedTransform(Transform newTarget)
    {
        target = newTarget;
    }
}