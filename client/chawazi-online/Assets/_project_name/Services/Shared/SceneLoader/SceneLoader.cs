using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Slider slider;

    [Inject]
    public void Construct(ILogger logger)
    {
        logger.Log("SceneLoader Constructed");
    }

    public void LoadScene(string sceneName)
    {
        // Use a coroutine to load the Scene in the background
        StartCoroutine(LoadAsyncScene(sceneName));
    }

    private IEnumerator LoadAsyncScene(string sceneName)
    {
        //if (slider != null) slider.gameObject.SetActive(true);
        if (slider != null) SetActiveRecursively(slider.gameObject.transform, true);
        var asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;
        var t = 0f;
        while (!asyncLoad.isDone)
        {
            Debug.Log(asyncLoad.isDone);
            t += 0.9f * Time.deltaTime;
            if (slider != null) slider.value = math.lerp(0, 1, t);
            if (slider != null)
                if (slider.value >= .95f)
                    asyncLoad.allowSceneActivation = true;

            yield return null;
        }

        Debug.Log(asyncLoad.isDone + "  out");
        //if (slider != null) slider.gameObject.SetActive(false);
        if (slider != null) SetActiveRecursively(slider.gameObject.transform, false, 1);
    }

    private void SetActiveRecursively(Transform child, bool active, int numberOfParents = 0, int currentParent = 0)
    {
        if (child.parent == null || currentParent == numberOfParents && numberOfParents != 0) return;
        child.gameObject.SetActive(active);
        if (child.parent.gameObject.activeSelf)
        {
            SetActiveRecursively(child.parent, active, numberOfParents, currentParent++);
        }
        else
        {
            child.parent.gameObject.SetActive(active);
            SetActiveRecursively(child.parent, active, numberOfParents, currentParent++);
        }
    }
}