using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameStatus : MonoBehaviour
{
    // config params
   [Range(0.1f,10f)] [SerializeField] float gameSpeed;
    [SerializeField] int pointScorePerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText; 
    // state variable
    [SerializeField] int currentScore = 0;
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        scoreText.text = currentScore.ToString();

    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }
    public void AddToScore()
    {
        currentScore = currentScore + pointScorePerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
