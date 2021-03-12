using UnityEngine;
// This complete script can be attached to a camera to make it
// continuously point at another object.

public class LookAtCamera : MonoBehaviour
{
    [SerializeField]
    Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Update()
    {
        transform.forward = -target.forward;
    }
}
