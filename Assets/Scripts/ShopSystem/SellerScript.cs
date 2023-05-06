using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellerScript : MonoBehaviour
{
    [SerializeField]private GameObject _goToStore;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            _goToStore.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            _goToStore.SetActive(false);
        }
    }
}
