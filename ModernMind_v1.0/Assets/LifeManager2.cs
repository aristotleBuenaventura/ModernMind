using UnityEngine;
using UnityEngine.UI;

public class LifeManager2 : MonoBehaviour
{
    public static LifeManager2 Instance { get; private set; }

    [SerializeField] private Image[] hearts;
    [SerializeField] private Image[] secondHearts;
    [SerializeField] private GameObject gameOverScreen; // ✅ Game Over screen reference

    public int lives = 3; // Initial lives

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DecreaseLife()
    {
        if (lives > 0)
        {
            lives--;
            UpdateHearts();
            UpdateSecondHearts();
        }

        if (lives <= 0)
        {
            GameOver();
        }
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = (i < lives);
        }
    }

    private void UpdateSecondHearts()
    {
        for (int i = 0; i < secondHearts.Length; i++)
        {
            secondHearts[i].enabled = (i < lives);
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }
    }
}
