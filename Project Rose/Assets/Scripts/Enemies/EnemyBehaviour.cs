using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private int _xpAmount;
    [SerializeField] private DropsSystem _dropsSystem; 
    [SerializeField] private bool _hasSoulFragment = false;
    [SerializeField] private bool _tookDamage = false;
    GameObject player;
    private CounterManager _counterManager;
    
    Rigidbody2D enemyRb;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>().gameObject;
        _counterManager = FindObjectOfType<CounterManager>();
        _dropsSystem = FindObjectOfType<DropsSystem>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && !_tookDamage)
        {
            Move();
            FlipSprite();
        }

        if (_health <= 0)
        {
            Died();
        }
    }

    private void Move()
    {
        enemyRb.velocity = (player.transform.position - transform.position) * _movementSpeed;        
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Player>().DecreaseHealth(_damage);
            col.gameObject.GetComponent<Player>().InitDamageAnimation();
        }    
    }

    public void InitDamageAnimation(float damage)
    {
        _tookDamage = true;
        StartCoroutine(DamageAnimation(damage));
    }

    private IEnumerator DamageAnimation(float damage)
    {
        enemyRb.bodyType = RigidbodyType2D.Static;
        _animator.SetBool("tookDamage", true);
        yield return new WaitForSecondsRealtime(0.1f);
        _animator.SetBool("tookDamage", false);
        DecreaseHealth(damage);
        enemyRb.bodyType = RigidbodyType2D.Dynamic;
        _tookDamage = false;
    }
    
    public void DecreaseHealth(float damage)
    {
        _health -= damage;
    }
    
    private void Died()
    {
        if (_hasSoulFragment)
        {
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
