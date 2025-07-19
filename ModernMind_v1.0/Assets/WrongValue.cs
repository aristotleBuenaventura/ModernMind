using UnityEngine;
using TMPro;

public class WrongValue : MonoBehaviour
{
    public TextMeshProUGUI key;
    public KeyManager keyValue;

    void Update()
    {
        key.text = (20 - keyValue.GetKeyCount()).ToString();
    }
}
