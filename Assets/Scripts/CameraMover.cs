using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CameraMover : MonoBehaviour
{
    private GameObject player;
    private Vector3 prevPlayerPos;
    private Vector3 posVector;
    public float scale = 3.0f;
    public float cameraSpeed = 1.0f;

    void Start()
    {
        player = GameObject.Find("Ship");
        prevPlayerPos = new Vector3(0, 2, -4);
    }

    void Update()
    {
        Vector3 currentPlayerPos = player.transform.position;
        Vector3 backVector = (prevPlayerPos - currentPlayerPos).normalized;
        posVector = (backVector == Vector3.zero) ? posVector : backVector;
        Vector3 targetPos = currentPlayerPos + scale * posVector;
        targetPos.y = targetPos.y + 2f;
        this.transform.position = Vector3.Lerp(
            this.transform.position,
            targetPos,
            cameraSpeed * Time.deltaTime
        );
        this.transform.LookAt(player.transform.position);
        prevPlayerPos = player.transform.position;
    }

}