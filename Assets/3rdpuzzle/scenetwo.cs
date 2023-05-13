using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenetwo : MonoBehaviour
{
    public string mainlvl; // Name of the scene you want to switch to
    public float delayTime = 350f; // Delay time in seconds

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
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(mainlvl);
    }
}