using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PracticeManager : MonoBehaviour
{
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("PracticeTarget").Length == 0)
        {
            StartCoroutine(StartGame());
        }


    }

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Test Level");

    }
}
