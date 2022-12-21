using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] float playerVelocidade;
    [SerializeField] private float _health = 100f;
    [SerializeField] private float _defense = 10f;
    [SerializeField] public float damage = 20f;
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _dashDuration;
    [SerializeField] private float _dashCooldown;
    [SerializeField] private float _fireRate = 0.5f;
    public int _bulletSpeed = 300;

    [SerializeField] private bool _canDash = true;
    [SerializeField] private bool _isDashing = false;

    [SerializeField] private ElixirsModifiers _elixirsModifiers;

    [SerializeField] GameObject bulletPrefab;

    private HealthBar _healthBar;

    Rigidbody2D playerRb;

    private TrailRenderer _trailRenderer;

    Vector2 playerMovDir;
    
    private GameManager _gameManager;
    private Animator _animator;
    

    // Start is called before the first frame update
    void Start()
    {
        if (_elixirsModifiers.health > 0)
        {
            _health = (_elixirsModifiers.health * _health) + _health;
        }

        if (_elixirsModifiers.defense > 0)
        {
            _defense = (_elixirsModifiers.defense * _defense) + _defense;
        }

        if (_elixirsModifiers.damage > 0)
        {
            damage = (_elixirsModifiers.damage * damage) + damage;
        }
        playerRb = GetComponent<Rigidbody2D>();
        _healthBar = GetComponentInChildren(typeof(HealthBar)) as HealthBar;
        _gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;
        _animator = GetComponent<Animator>();
        _trailRenderer = GetComponent<TrailRenderer>();
        InvokeRepeating("Atirar", _fireRate, _fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isDashing)
        {
            Movimento();
        }
        
        FlipSprite();
        if (_health <= 0)
        {
            Die();
        }
    }

    void Movimento()
    {
        playerRb.velocity = playerMovDir * playerVelocidade;
        bool isRunnig = Mathf.Abs(playerRb.velocity.x) > Mathf.Epsilon || Mathf.Abs(playerRb.velocity.y) > Mathf.Epsilon;
        _animator.SetBool("isRunning", isRunnig);
    }

    void OnMove(InputValue inputValue)
    {
        playerMovDir = inputValue.Get<Vector2>();
    }

    private IEnumerator Dashing()
    {
        _canDash = false;
        _isDashing = true;
        playerRb.velocity = playerMovDir * _dashSpeed;
        _trailRenderer.emitting = _isDashing;
        _animator.SetBool("tookDamage", true);
        yield return new WaitForSecondsRealtime(_dashDuration);
        _animator.SetBool("tookDamage", false);
        _isDashing = false;
        _trailRenderer.emitting = _isDashing;
        yield return new WaitForSecondsRealtime(_dashCooldown);
        _canDash = true;
    }
    
    void OnDash(InputValue inputValue)
    {
        if (inputValue.isPressed && _canDash)
            StartCoroutine(Dashing());
    }

    void Atirar()
    {
        Transform target = UpdateTarget();
        if (target != null)
        {
            foreach (Transform spawnBullet in transform)
            {
                Instantiate(bulletPrefab, spawnBullet);
            }
        }
    }

    public Transform UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null)
            return nearestEnemy.transform;
        else
            return null;
    }

    private void Die()
    {
        _gameManager.ShowGameOverScreen();
        Destroy(this.gameObject);
    }

    public void DecreaseHealth(float damage)
    {
        float actualDamage = _defense - damage;
        if (actualDamage < 0)
        {
            _healthBar.DecreaseSlider(Mathf.Abs(actualDamage));
            _health -= Mathf.Abs(actualDamage);
        }
    }

    public void InitDamageAnimation()
    {
        StartCoroutine(InvincibilityCoolDown());
    }
    
    private IEnumerator InvincibilityCoolDown()
    {
        _animator.SetBool("tookDamage", true);
        yield return new WaitForSecondsRealtime(1.5f);
        _animator.SetBool("tookDamage", false);
    }
    
    public float GetHealth()
    {
        return _health;
    }
    
    private void FlipSprite()
    {
        transform.localScale = new Vector2(Mathf.Sign(playerRb.velocity.x), 1);
    }
    
    public void IncreaseMovementSpeed(float modifier)
    {
        playerVelocidade *= modifier;
    }

    public void ResumeAttack()
    {
        InvokeRepeating("Atirar", _fireRate, _fireRate);
    }
    
    public void IncreaseAttackSpeed(float modifier)
    {
        _fireRate /= modifier;
    }
}
