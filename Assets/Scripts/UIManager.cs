using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private LevelData levelData;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI waveText;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        scoreText.text = levelData.score.ToString("D3");
        waveText.text = $"{levelData.wave}";
    }
}