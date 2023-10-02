using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExitScript : MonoBehaviour
{
    [SerializeField] float delayTimeLoadLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //cach 1
            //StartCoroutine("LoadNextLevel");

            //cach 2
            //StartCoroutine(nameof(LoadNextLevel));

            //cach 3
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        //yield return new WaitForSeconds(delayTimeLoadLevel);
        yield return new WaitForSecondsRealtime(delayTimeLoadLevel);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        FindObjectOfType<ScenePersistScript>().ResetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);

    }
}
