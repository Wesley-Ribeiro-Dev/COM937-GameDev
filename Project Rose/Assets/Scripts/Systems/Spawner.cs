using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _radius = 13.02f;
    [SerializeField] private GameObject[] enemies;

    public float GetDelay ()
    {
        return _delay;
    }
    void Start()
    {
        InvokeRepeating("SpawnGoblins", 0, _delay);
        InvokeRepeating("SpawnFlyingEyes", 0, _delay);
    }

    public void SpawnGoblins()
    {
        float radius = 13.02f;
        Vector3 randomPos = Random.insideUnitSphere * radius;
        randomPos += transform.position;
        randomPos.y = 0f;
    
        Vector3 direction = randomPos - transform.position;
        direction.Normalize();
    
        float dotProduct = Vector3.Dot(transform.forward, direction);
        float dotProductAngle = Mathf.Acos(dotProduct / transform.forward.magnitude * direction.magnitude);
    
        randomPos.x = Mathf.Cos(dotProductAngle) * radius + transform.position.x;
        randomPos.y = Mathf.Sin(dotProductAngle * (Random.value > 0.5f ? 1f : -1f)) * radius + transform.position.y;
        randomPos.z = transform.position.z;
        
        Instantiate(enemies[0], randomPos, Quaternion.identity);
    }
    
    public void SpawnFlyingEyes()
    {
        float radius = 13.02f;
        Vector3 randomPos = Random.insideUnitSphere * radius;
        randomPos += transform.position;
        randomPos.y = 0f;
    
        Vector3 direction = randomPos - transform.position;
        direction.Normalize();
    
        float dotProduct = Vector3.Dot(transform.forward, direction);
        float dotProductAngle = Mathf.Acos(dotProduct / transform.forward.magnitude * direction.magnitude);
    
        randomPos.x = Mathf.Cos(dotProductAngle) * radius + transform.position.x;
        randomPos.y = Mathf.Sin(dotProductAngle * (Random.value > 0.5f ? 1f : -1f)) * radius + transform.position.y;
        randomPos.z = transform.position.z;
        
        Instantiate(enemies[1], randomPos, Quaternion.identity);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    public void SpawnEnemies()
    {
        InvokeRepeating("SpawnGoblins", 0, _delay);
        InvokeRepeating("SpawnFlyingEyes", 0, _delay);
    }

    public void StopSpawning()
    {
        CancelInvoke();
    }

    public void DecreaseDelay()
    {
        if (_delay > 0.1f)
            _delay -= 0.1f;
    }
}