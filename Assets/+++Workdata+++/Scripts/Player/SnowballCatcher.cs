using TMPro;
using UnityEngine;

public class SnowballCatcher : MonoBehaviour
{
    [SerializeField] public int ProjectileType = 0;
    [SerializeField] public TextMeshProUGUI MediumTracker;
    [SerializeField] public TextMeshProUGUI HeavyTracker;


    public void UpdateMediumAmmoCount(int newType)
    {
        MediumTracker.text = newType.ToString();
    }
    public void UpdateHeavyAmmoCount(int newType)
    {
        HeavyTracker.text = newType.ToString();
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
