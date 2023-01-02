using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointBehaviour : MonoBehaviour
{
    private Player _player;
    private Rigidbody2D _rigidbody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponentInParent<Player>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*float radius = 2f;
        Vector3 randomPos = Random.insideUnitSphere * radius;
        randomPos += _player.transform.position;
        randomPos.y = 0f;
    
        Vector3 direction = randomPos - _player.transform.position;
        direction.Normalize();
    
        float dotProduct = Vector3.Dot(_player.transform.forward, direction);
        float dotProductAngle = Mathf.Acos(dotProduct / _player.transform.forward.magnitude * direction.magnitude);
    
        randomPos.x = Mathf.Cos(dotProductAngle) * radius + _player.transform.position.x;
        randomPos.y = Mathf.Sin(dotProductAngle * (Random.value > 0.5f ? 1f : -1f)) * radius + _player.transform.position.y;
        randomPos.z = _player.transform.position.z;
        transform.position = randomPos;*/
    }
}
