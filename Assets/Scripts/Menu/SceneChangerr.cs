using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerr : MonoBehaviour
{
    //Custom Void for SceneChange
    public void ChangeScene(int sceneId)
    {
        //Shows in console to test
        Debug.Log("Fuck My Life");
        //Changes scene depending on Scene ID
        SceneManager.LoadScene(sceneId);
    }

    public void QuitGame()
    {
        //Quits Play Mode in Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        //If the game is built it will close the app
        Application.Quit();
    }
}
