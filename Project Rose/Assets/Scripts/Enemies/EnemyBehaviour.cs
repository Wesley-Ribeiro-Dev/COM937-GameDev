using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private int _xpAmount;
    [SerializeField] private DropsSystem _dropsSystem;
    GameObject player;
    ScoreUI scoreUI;
    
    Rigidbody2D enemyRb;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            enemyRb = GetComponent<Rigidbody2D>();
            player = FindObjectOfType<Player>().gameObject;
            scoreUI = FindObjectOfType<ScoreUI>();
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
        }    
    }

    public void DecreaseHealth(int damage)
    {
        _health -= damage;
    }
    
    private void Died()
    {
        scoreUI.AddScore();
        _dropsSystem.DropExperiencePoints(transform, _xpAmount);
        Destroy(this.gameObject);
    }

    private void FlipSprite()
    {
        transform.localScale = new Vector2(Mathf.Sign(enemyRb.velocity.x)*4, 4);
    }
}
