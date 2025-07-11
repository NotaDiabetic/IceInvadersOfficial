using UnityEngine;

public class CollectibleBehavior : MonoBehaviour
{
    private Vector3 direction = new Vector3(0, -1, 0);
    private float dropSpeed = 1.5f;
    void Update()
    {
        transform.position += direction * (dropSpeed * Time.deltaTime);
    }
}
