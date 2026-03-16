using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject loadingScreen;
    public Slider progressBar;
    void Start()
    {
        //SceneManager.LoadScene(1);
        //SceneManager.LoadScene(2, LoadSceneMode.Additive);
        LoadScene(1);
    }

    public void LoadScene(int sceneID)
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneAsync(sceneID));
    }

    private IEnumerator LoadSceneAsync(int sceneID)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID, LoadSceneMode.Additive);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressBar.value = progress;
            // update our loading bar
            yield return null;
        }
    }
}
