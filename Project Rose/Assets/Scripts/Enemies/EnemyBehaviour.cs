using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private int _xpAmount;
    [SerializeField] private DropsSystem _dropsSystem; 
    [SerializeField] private bool _hasSoulFragment = false;
    GameObject player;
    private CounterManager _counterManager;
    
    Rigidbody2D enemyRb;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            enemyRb = GetComponent<Rigidbody2D>();
            player = FindObjectOfType<Player>().gameObject;
            _counterManager = FindObjectOfType<CounterManager>();
            _dropsSystem = FindObjectOfType<DropsSystem>();
        }
        catch
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            enemyRb.velocity = (player.transform.position - transform.position) * _movementSpeed;
            FlipSprite();
        }

        if (_health <= 0)
        {
            Died();
        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Player>().DecreaseHealth(_damage);
            col.gameObject.GetComponent<Player>().InitDamageAnimation();
        }    
    }

    public void DecreaseHealth(int damage)
    {
        _health -= damage;
    }
    
    private void Died()
    {
        if (_hasSoulFragment)
        {
            _counterManager.AddFragment();
            _dropsSystem.DropSoulFragments(transform);
            Destroy(this.gameObject);
        }
        else
        {
            _counterManager.AddEnemies();
            _dropsSystem.DropExperiencePoints(transform, _xpAmount);
            Destroy(this.gameObject);
        }
    }

    private void FlipSprite()
    {
        transform.localScale = new Vector2(Mathf.Sign(enemyRb.velocity.x)*4, 4);
    }
}
