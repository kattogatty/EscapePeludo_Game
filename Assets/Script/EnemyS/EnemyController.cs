using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Animator enemyAnimator;
    private NavMeshAgent agent; 
    private Transform transformPlayer;
    public EnemyState currentState; // variable para saber en que estado se encuentra actualmente
    public Vector2 patrolArea; //variable para añadir valores aleatorios en un plano 2D 
    private Vector3 destinationPoint; // variable de punto aleatorio
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        transformPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        currentState = EnemyState.PATROL; // estado actual
        InvokeRepeating ("GeneratePatrolPosition", 0f, 5f); // se invoca el calculo del destino del enemigo cada 5 seg
    }

    public void GeneratePatrolPosition() // evento para calcular el punto destino de patrullaje 
    {
        if(currentState != EnemyState.PATROL)
        return;

        destinationPoint = transformPlayer.position + 
                            (Vector3.right * Random.Range(-patrolArea.x, patrolArea.x)) + 
                            (Vector3.forward * (Random.Range(-patrolArea.y, patrolArea.y))); 
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(destinationPoint);
        enemyAnimator.SetFloat("Speed", agent.velocity.sqrMagnitude);
    }
}

public enum EnemyState // Maquina de estados de enemigo 
{
    PATROL,
    CHASE, 
    ATTACK
}