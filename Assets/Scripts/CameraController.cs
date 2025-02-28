﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController thePlayer;

    private Vector3 lastPlayerPosition;
    private float distanceToMoveX;
    private float distanceToMoveY;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        lastPlayerPosition = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToMoveX = thePlayer.transform.position.x - lastPlayerPosition.x;
        distanceToMoveY = thePlayer.transform.position.y - lastPlayerPosition.y;

        transform.position = new Vector3(transform.position.x + distanceToMoveX, transform.position.y, transform.position.z);

        lastPlayerPosition = thePlayer.transform.position;

    }
}
