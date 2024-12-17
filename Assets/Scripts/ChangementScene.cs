using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangementScene : MonoBehaviour
{
  [SerializeField] private LevelData levelData;
    public void ChangeScene(string sceneName)
  {
    levelData.score = 0;
    SceneManager.LoadScene(sceneName);
  }
}
