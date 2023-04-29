using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void LoadScene()
    {
        // Use a coroutine to load the Scene in the background
        StartCoroutine(LoadAsyncScene());
    }

    private IEnumerator LoadAsyncScene()
    {
        slider.gameObject.SetActive(true);
        var asyncLoad = SceneManager.LoadSceneAsync("MainLocalScene");
        while (!asyncLoad.isDone)
        {
            slider.value = asyncLoad.progress;
            yield return null;
        }
        slider.gameObject.SetActive(false);
    }
}