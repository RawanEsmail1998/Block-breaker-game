using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklessVFX;
   
    [SerializeField] Sprite[] hitSprites;
    Level level;

    // state variables
    [SerializeField] int timesHit; // only for debug purposes
    private void Start()
    {
        CountBreakableBlocks();

    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.countBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            HandleHit();
        }


    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyedBlock();

        }else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int SpriteIndex = timesHit - 1;
        if(hitSprites[SpriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[SpriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
        }
       
    }

    private void DestroyedBlock()
    {
        PlayBlockDestroySFX();
        // destroy the game object
        Destroy(gameObject);
        // the name of the collision
        //Debug.Log(collision.gameObject.name);
        level.BlockDestroyed();
        TriggerSparklessVFX();
    }

    private void PlayBlockDestroySFX()
    {
        FindObjectOfType<GameStatus>().AddToScore();

        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

    }

    private void TriggerSparklessVFX()
    {
        GameObject sparkles = Instantiate(blockSparklessVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
