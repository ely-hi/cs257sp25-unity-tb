using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemeyState { GoToBase, AttackBase, ChasePlayer, AttackPlayer}
    public EnemeyState currentState;
    public Sight sightSensor;
    public Transform baseTransform;
    public float baseAttackDistance;
    public float playerAttackDistance;
    private NavMeshAgent agent;
    public float lastShootTime;
    public GameObject bulletPrefab;
    public float fireRate;
    public ParticleSystem muzzleEffect;


    void GoToBase() {
        //print("GoToBase");
        // if(sightSensor.detectedObject != null) {
        //     currentState = EnemeyState.ChasePlayer;
        // }

        // float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);
        // if (distanceToBase < baseAttackDistance) {
        //     currentState = EnemeyState.AttackBase;
        // }
        agent.isStopped = false;
        agent.SetDestination(baseTransform.position);
    }

    void AttackBase()
    {
        //print("AttackBase");
        agent.isStopped = true;
        
        LookTo(sightSensor.detectedObject.transform.position);
        Shoot();
    }

    void ChasePlayer() { 
        //print("ChasePlayer");
        // if(sightSensor.detectedObject == null) {
        //     currentState = EnemeyState.GoToBase;
        //     return;
        // }

        // float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        // if (distanceToPlayer <= playerAttackDistance) {
        //     currentState = EnemeyState.AttackPlayer;
        // }

        agent.isStopped = false;

        if (sightSensor.detectedObject == null) {
            currentState = EnemeyState.GoToBase;
            return;
        }
        agent.SetDestination(sightSensor.detectedObject.transform.position);
    }

    void AttackPlayer() {
        //print("AttackPlayer");

        agent.isStopped = true;

        if(sightSensor.detectedObject == null) {
             currentState = EnemeyState.GoToBase;
             return;
         }

        LookTo(sightSensor.detectedObject.transform.position);
        Shoot();

        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
       
        if (distanceToPlayer > playerAttackDistance * 1.1f) {
             currentState = EnemeyState.ChasePlayer;
         }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
    }

    private void Awake()
    {
        baseTransform = GameObject.Find("BaseDamagePoint").transform;
        agent = GetComponentInParent<NavMeshAgent>();
    }

    void Shoot() {
        var timeSinceLastShoot = Time.time - lastShootTime;
        if (timeSinceLastShoot > fireRate) {
            lastShootTime = Time.time;
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            muzzleEffect.Play();
        }
    }

    void LookTo(Vector3 targetPosition) {
        Vector3 directionToPosition = Vector3.Normalize(targetPosition - transform.parent.position);
        directionToPosition.y = 0;
        transform.parent.forward = directionToPosition;
    }  

}
