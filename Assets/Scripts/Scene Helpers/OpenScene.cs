using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    public string sceneToOpen;

    public void SceneOpener()
    {
        SceneManager.LoadScene(sceneToOpen);
    }


}
