using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollector : MonoBehaviour
{
   private int cherries = 0;

    // [SerializeField] private Text cherriesText;

    // [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("orange")) //chỉnh trùng tag => 
        {
            // collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            // cherriesText.text = "Cherries: " + cherries;
        }
    }
}
