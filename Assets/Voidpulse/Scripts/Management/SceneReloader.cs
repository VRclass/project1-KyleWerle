using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{

    public void ReloadScene()
    {
        StartCoroutine(ChangeScene(1f));
    }

    IEnumerator ChangeScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
