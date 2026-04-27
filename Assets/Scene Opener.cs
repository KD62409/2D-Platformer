using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOpener : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
