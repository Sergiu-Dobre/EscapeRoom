using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneone : MonoBehaviour
{
    public string p2cutscenetest; // Name of the scene you want to switch to
    public float delayTime = 900f; // Delay time in seconds

    private float timer;

    private void Start()
    {
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delayTime)
        {
            ChangeScene();
            Debug.Log("yez");
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(p2cutscenetest);
    }
}