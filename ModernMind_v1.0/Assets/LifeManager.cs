using UnityEngine;
using UnityEngine.UI;
using TMPro; // ✅ Import TextMeshPro namespace

public class LifeManager : MonoBehaviour
{
    public static LifeManager Instance { get; private set; }

    [SerializeField] private Image[] hearts;
    [SerializeField] private Image[] Secondhearts;
    [SerializeField] private TextMeshProUGUI livesText; // ✅ Add TMP text reference

    public int lives = 3; // Initial lives
    public GameObject Joystick;
    public GameObject Pick;
    public GameObject Jump;
    public GameObject GameOver;
    public GameObject ULITIN, TUMULOY, Star, GameOverImage;

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

    private void Update()
    {
        // ✅ Continuously update text every frame
        livesText.text = lives.ToString();
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
            ULITIN.SetActive(true);
            TUMULOY.SetActive(false);
            Star.SetActive(false);
            GameOverImage.SetActive(true);
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
        for (int i = 0; i < Secondhearts.Length; i++)
        {
            Secondhearts[i].enabled = (i < lives);
        }
    }
}
