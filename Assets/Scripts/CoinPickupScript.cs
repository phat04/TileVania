using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickupScript : MonoBehaviour
{
    [SerializeField] AudioClip coinAudioClip;
    [SerializeField] int pointsForCoin = 100;

    bool wasCollected;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSessionScript>().AddToScore(pointsForCoin);
            AudioSource.PlayClipAtPoint(coinAudioClip, Camera.main.transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
