using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangementScene : MonoBehaviour
{
    public void Scene(string sceneName)
  {
    SceneManager.LoadScene(sceneName);
  }
}
