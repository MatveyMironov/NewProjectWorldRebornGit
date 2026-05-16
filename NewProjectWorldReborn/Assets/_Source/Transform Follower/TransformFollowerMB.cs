using UnityEngine;

public class TransformFollowerMB : MonoBehaviour
{
    public Transform FollowedTransform;

    private void OnEnable()
    {
        if (FollowedTransform == null) { return; }
        transform.position = FollowedTransform.position;
    }

    private void Update()
    {
        if (FollowedTransform == null) { return; }
        transform.position = FollowedTransform.position;
    }
}