using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager;

    public DeathScript theDeathMenu;

    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    public void RestartGame()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);

        theDeathMenu.gameObject.SetActive(true);

        //StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }

    //public IEnumerator RestartGameCo()
    //{
    //    theScoreManager.scoreIncreasing = false; ;
    //    thePlayer.gameObject.SetActive(false);
    //    yield return new WaitForSeconds(0.5f);
    //    platformList = FindObjectsOfType<PlatformDestroyer>();
    //    for (int i = 0; i < platformList.Length; i++)
    //    {
    //        platformList[i].gameObject.SetActive(false);
    //    }
    //    thePlayer.transform.position = playerStartPoint;
    //    platformGenerator.position = platformStartPoint;
    //    thePlayer.gameObject.SetActive(true);

    //    theScoreManager.scoreCount = 0;
    //    theScoreManager.scoreIncreasing = true;
    //}
}
