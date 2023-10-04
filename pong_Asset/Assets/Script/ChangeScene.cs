
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void MoveScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
