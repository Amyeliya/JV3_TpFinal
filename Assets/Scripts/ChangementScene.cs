using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangementScene : MonoBehaviour
{
    public void ChangeScene(string sceneName)
  {
    SceneManager.LoadScene(sceneName);
  }
}
