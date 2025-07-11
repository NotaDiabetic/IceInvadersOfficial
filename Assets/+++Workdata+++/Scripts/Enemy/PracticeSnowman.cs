using UnityEngine;

public class PracticeSnowman : MonoBehaviour
{
    public GameObject Pile;
    public Transform Snowman;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SimpleSnowball") || other.CompareTag("MediumSnowball") || other.CompareTag("HardSnowball"))
        {
            Destroy(gameObject);
            GameObject PL = Instantiate(Pile);
            PL.transform.position = Snowman.position;
        }
    }
}
