using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public static LifeManager Instance { get; private set; }

    [SerializeField] private Image[] hearts;
    [SerializeField] private Image[] Secondhearts;
    private int lives = 3; // Initial lives
    public GameObject Joystick;
    public GameObject Pick;
    public GameObject Jump;
    public GameObject GameOver;

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
            Debug.Log("Game Over!");
            Joystick.SetActive(false);
            Jump.SetActive(false);
            Pick.SetActive(false);
            GameOver.SetActive(true);
            // Implement Game Over logic here

        }
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = (i < lives); // Hide hearts when lives decrease
        }
    }

    private void UpdateSecondHearts()
    {
        for (int i = 0; i < Secondhearts.Length; i++)
        {
            Secondhearts[i].enabled = (i < lives); // Hide hearts when lives decrease
        }
    }
}