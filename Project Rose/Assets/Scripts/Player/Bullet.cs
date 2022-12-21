using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D _bulletRb;
    
    [SerializeField]
    private float _bulletSpeed;

    private float _bulletDamage;

    private Player _playerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        _bulletRb = GetComponent<Rigidbody2D>();
        _playerScript = FindObjectOfType<Player>();
        _bulletDamage = _playerScript.damage;
        Transform enemyTransform = _playerScript.UpdateTarget();
        if (enemyTransform != null)
        {
            Vector2 relativePos = (enemyTransform.position - transform.position).normalized;
            _bulletRb.AddForce(relativePos * _playerScript._bulletSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<EnemyBehaviour>().DecreaseHealth(_bulletDamage);
            Destroy(this.gameObject);
        }    
    }
}
