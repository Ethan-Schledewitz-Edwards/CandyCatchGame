using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyComponent : MonoBehaviour
{
    public Candy Candy => candy;
    [SerializeField] private Candy candy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Add to players score
        if (collision.CompareTag("Player"))
        {
            ScoreTracker.Instance.AddToScore(candy.CandyValue);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
