using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyBehavior : MonoBehaviour
{
    public Transform PatrolRoute;
    public List<Transform> Locations;
    private int _locationIndex = 0;
    private NavMeshAgent _agent;
    public Transform Player;
    private GameBehavior _gameManager;


    void Start()
    {  
        _agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player").transform;
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();

    }

    void InitializePatrolRoute()
    {
        foreach(Transform child in PatrolRoute) {

            Locations.Add(child);
            }
    }

    void Update()
    {
        if(_agent.remainingDistance < 0.2f && !_agent.pathPending) {
        MoveToNextPatrolLocation();
    }
}

    void MoveToNextPatrolLocation()
    {
        if (Locations.Count == 0)
            return;
        _agent.destination = Locations[_locationIndex].position;
        _locationIndex = (_locationIndex + 1) % Locations.Count;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player detected - attack!");
            _agent.destination = Player.position;
            Debug.Log("Enemy detected!");

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player out of range, resume patrol");
        }
    }
    void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.name == "Enemy")
        {
            _gameManager.HP -= 1;
        }
    }

}