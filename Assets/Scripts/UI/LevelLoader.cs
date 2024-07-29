using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
     public static LevelLoader Instance { get; private set; }

    public Animator transition;
    public float transitionTime;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadLevel(string sceneName)
    {
        StartCoroutine(LoadLevelAnim(sceneName));
    }

    IEnumerator LoadLevelAnim(string sceneName)
    {
        //Play anim
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load Scene
        SceneManager.LoadScene(sceneName);
    }
}
