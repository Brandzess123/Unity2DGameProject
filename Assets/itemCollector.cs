using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{
   private int cherries = 0;

    [SerializeField] private Text Fruit_Text;

    // [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("orange")) //chỉnh trùng tag => 
        {
            // collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            Fruit_Text.text = "Cherries: " + cherries;
        }
    }
}
