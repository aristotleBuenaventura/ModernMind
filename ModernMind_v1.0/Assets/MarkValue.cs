using UnityEngine;
using TMPro;

public class MarkValue : MonoBehaviour
{
    public TextMeshProUGUI key, coins;
    public KeyManager keyValue;

    void Update()
    {
        key.text = keyValue.GetKeyCount() + "/20";
        coins.text = (keyValue.GetKeyCount()*3).ToString();
    }
}
