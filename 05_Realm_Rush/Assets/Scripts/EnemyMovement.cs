using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] float movementPeriod = .5f;
    [SerializeField] ParticleSystem destoryParticlePrefab;

    // Use this for initialization
    void Start ()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
	}

    IEnumerator FollowPath(List<Waypoint> path)
    {
        WaitForSeconds delay = new WaitForSeconds(movementPeriod);

        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return delay;
        }
        DestroyEnemy();
    }

    private void DestroyEnemy()
    {
        var destroyVFX = Instantiate(destoryParticlePrefab, transform.position, Quaternion.identity);
        destroyVFX.Play();

        // destory the vfx from hierarchy 
        float destoryDelay = destroyVFX.main.duration;
        Destroy(destroyVFX.gameObject, destoryDelay);

        // destory the actuall enemy
        Destroy(gameObject);
    }
}
