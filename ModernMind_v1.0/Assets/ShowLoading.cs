using UnityEngine;

public class ShowLoading : MonoBehaviour
{
    public GameObject wall, loading;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            loading.SetActive(true);
            wall.SetActive(false);

        }
    }
}
