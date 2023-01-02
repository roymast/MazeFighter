using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] GameObject objectToFollow;
    [SerializeField] Character character;
    [SerializeField] Gun gun;
    [SerializeField] int DistanceToFollow;
    [SerializeField] int MinDistanceToPlayer;

    [SerializeField] int agnle;
    [SerializeField] float distance;

    [SerializeField] float lastTimeAttack;
    [SerializeField] float minTimeBetweenAttacks;
    [SerializeField] float randomTimeToWait;
    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, objectToFollow.transform.position);
        if (distance > DistanceToFollow)
        {
            Debug.Log("stop moveing");
            return;
        }
        if (distance > MinDistanceToPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, objectToFollow.transform.position, character.speed * Time.deltaTime);

            // get direction you want to point at
            Vector2 direction = ((Vector2)objectToFollow.transform.position - (Vector2)transform.position).normalized;

            // set vector of transform directly
            transform.up = direction;
            if ((Time.time - randomTimeToWait) - lastTimeAttack > minTimeBetweenAttacks)
            {
                randomTimeToWait = Random.Range(1f, 2.5f);
                lastTimeAttack = Time.time;
                character.UseWeapon();
            }
        }        
    }    
}
