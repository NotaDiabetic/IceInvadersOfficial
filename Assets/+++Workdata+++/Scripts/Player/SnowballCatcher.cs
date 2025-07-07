using TMPro;
using UnityEngine;

public class SnowballCatcher : MonoBehaviour
{
    [SerializeField] public int ProjectileType = 0;
    [SerializeField] public TextMeshProUGUI TypeTracker;


    public void UpdateProjectileType(int newType)
    {
        TypeTracker.text = newType.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SimpleSnowball") || other.CompareTag("MediumSnowball") || other.CompareTag("HardSnowball"))
        {
            Debug.Log(message: "Hit a wall");
            Destroy(other.gameObject);
        }



    }
}
