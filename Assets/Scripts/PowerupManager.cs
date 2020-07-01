using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    private bool doublePoints;
    private bool safeMode;

    private bool powerupActive;

    private float powerupLengthCounter;

    private ScoreManager theScoreManager;
    private PlatformGenerator thePlatformGenerator;

    private float normalPointsPerSecond;
    private float spikeRate;

    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(powerupActive)
        {
            powerupLengthCounter -= Time.deltaTime;

            if (doublePoints)
            {
                theScoreManager.scorePerSecond = normalPointsPerSecond * 2;
                theScoreManager.shouldDouble = true;
                Debug.Log("Points are being double for <" + powerupLengthCounter + "> seconds.");
            }

            if (safeMode)
            {
                thePlatformGenerator.randomSpikeThreshold = 0f;
                Debug.Log("Spikes are being disabled for <" + powerupLengthCounter + "> seconds.");
            }

            if (powerupLengthCounter <= 0)
            {
                theScoreManager.scorePerSecond = normalPointsPerSecond;
                thePlatformGenerator.randomSpikeThreshold = spikeRate;
                theScoreManager.shouldDouble = false;

                powerupActive = false;
            }
        }
    }

    public void ActivatePowerup(bool points, bool safe, float time)
    {
        doublePoints = points;
        safeMode = safe;
        powerupLengthCounter = time;

        normalPointsPerSecond = theScoreManager.scorePerSecond;
        spikeRate = thePlatformGenerator.randomSpikeThreshold;

        powerupActive = true;
    }
}
