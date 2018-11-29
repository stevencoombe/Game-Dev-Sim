﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    public Transform playerOne;
    public double enemyRadiusP1 = 2;
    public double enemyRadiusP2 = 2;
    public double enemyTrailDistance = 3;
    public bool idling;

    public Animator anim;

    [HideInInspector]
    public Vector3 originalPos;
    public Vector3 currentPos;

    public Quaternion originalRot;
    public Quaternion currentRot;

    private ChaseTwo chase;
    private PathTwo path;
    private EnemyReset reset;

    private void Awake()
    {
        originalPos = new Vector3(gameObject.transform.position.x, 
            0, gameObject.transform.position.z);

        originalRot = gameObject.transform.rotation;

        anim.SetBool("IsIdle", true);
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsAttacking", false);

    }

    public void Start()
    {
        anim = GetComponent<Animator>();
        chase = GetComponent<ChaseTwo>();
        path = GetComponent<PathTwo>();
        reset = GetComponent<EnemyReset>();

        chase.enabled = false;
        path.enabled = false;
        reset.collided = true;
    }

    public void Update()
    {

        currentPos = new Vector3(gameObject.transform.position.x,
            0, gameObject.transform.position.z);

        originalRot = gameObject.transform.rotation;

        if (playerOne != null)
        {

            if (reset.collided == true && idling == false)
            {
                Idle();
            }

            else if (Vector3.Distance(playerOne.position, gameObject.transform.position) < enemyRadiusP1 && idling)
            {
                Chase();
                reset.collided = false;
                            
            }

            else if (Vector3.Distance(playerOne.position, gameObject.transform.position)
                > enemyRadiusP1 + enemyTrailDistance)
            {
                PathBack();
            }


        }
        
    }

    private void Idle()
    {
        anim.SetBool("IsIdle", true);
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsAttacking", false);

        path.enabled = false;
        chase.enabled = false;

        idling = true;
    }

    private void Chase()
    {
        chase.enabled = true;
        path.enabled = false;
        chase.PlayerChaseTwo();
    }

    private void PathBack()
    {
        path.enabled = true;
        chase.enabled = false;
        path.PathBackTwo();
        idling = false;
    }

}
