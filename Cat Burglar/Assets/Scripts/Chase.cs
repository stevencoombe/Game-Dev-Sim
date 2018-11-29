﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Chase : MonoBehaviour
{  
    public Animator anim;
    public GameObject player;

    private NavMeshAgent nav;
    private EnemyOne enemy;

	//[SerializeField] private Image image;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        enemy = GetComponent<EnemyOne>();
    }

    public void PlayerChase()
    {
        if (enemy == null)
        {
            return;
        }
        nav.SetDestination(enemy.playerOne.position);
        anim.SetBool("IsIdle", false);
        anim.SetBool("IsWalking", true);
        anim.SetBool("IsAttacking", false);

    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.name)
        {
           	case "PlayerOne": Destroy(player); break;
			//image.enabled = true;
		}
    }
}
