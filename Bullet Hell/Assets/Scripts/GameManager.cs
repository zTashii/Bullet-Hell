using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //Todo:
    //Add timer track for scoring
    public int countdownTimer;
    public TextMeshProUGUI countdownDisplay;
    public float elapsedTime;
    public GameObject[] gameObjects;

    // Start is called before the first frame update
    //void Start()
    //{
    //    StartCoroutine(CountdownStart());
    //}
    private void OnEnable()
    {
        StartGame();
        Timer.elapsedTime = 0;
    }
    // Update is called once per frame


    public void StartGame()
    {
        for(int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(true);
        }
    }

    public IEnumerator StopGames()
    {
        while (countdownTimer > 0)
        {
            countdownDisplay.text = "Game Over!";
            yield return new WaitForSeconds(1f);
            countdownTimer--;
        }
        StopGame();
    }

    public void StopGame()
    {
        //for (int i = 0; i < gameObjects.Length; i++)
        //{
        //    gameObjects[i].SetActive(false);
        //}

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    IEnumerator CountdownStart()
    {
        while (countdownTimer > 0)
        {
            countdownDisplay.text = countdownTimer.ToString();

            yield return new WaitForSeconds(1f);

            countdownTimer--;
        }

        countdownDisplay.text = "Start!";
        
        yield return new WaitForSeconds(1f);
        StartGame();
        countdownDisplay.gameObject.SetActive(false);
        
    }

    private void Update()
    {
        elapsedTime = Timer.elapsedTime;
    }
}
