using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GlobalSceneManager : SingletonPersistent<GlobalSceneManager>
{
    [Header("Events")]
    [SerializeField] GameEventString onSceneLoaded;
    [SerializeField] GameEventString onSceneUnloaded;

    private HashSet<string> loadedScenes = new HashSet<string>();

    public void LoadScene(string sceneName) => StartCoroutine(LoadSceneAsync(sceneName));
    public void UnloadScene(string sceneName) => StartCoroutine(UnloadSceneAsync(sceneName));

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        if (loadedScenes.Contains(sceneName)) yield break;

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!operation.isDone) yield return null;

        loadedScenes.Add(sceneName);
        onSceneLoaded.Raise(sceneName);
    }

    private IEnumerator UnloadSceneAsync(string sceneName)
    {
        if (!loadedScenes.Contains(sceneName)) yield break;

        AsyncOperation operation = SceneManager.UnloadSceneAsync(sceneName);
        while (!operation.isDone) yield return null;

        loadedScenes.Remove(sceneName);
        onSceneUnloaded.Raise(sceneName);
    }
}