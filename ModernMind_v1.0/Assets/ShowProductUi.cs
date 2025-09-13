using UnityEngine;

public class ShowProductUi : MonoBehaviour
{
    public GameObject ProductUi;   // UI panel to show
    public GameObject Product;     // The product itself

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) // only trigger if colliding with Player
        {
            Product.SetActive(false);
            ProductUi.SetActive(true);
        }
    }
}
