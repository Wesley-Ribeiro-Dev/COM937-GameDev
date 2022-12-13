using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    float playerVelocidade;

    private int _health = 100;

    [SerializeField]
    GameObject bulletPrefab;

    private HealthBar _healthBar;

    Rigidbody2D playerRb;
    
    Vector2 playerMovDir;

    public float bulletSpeed;
    private GameManager _gameManager;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        _healthBar = GetComponentInChildren(typeof(HealthBar)) as HealthBar;
        _gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;
        _animator = GetComponent<Animator>();
        InvokeRepeating("Atirar", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
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

    public void DecreaseHealth(int damage)
    {
        _healthBar.DecreaseSlider(damage);
        _health -= damage;
    }

    public void InitDamageAnimation()
    {
        StartCoroutine(InvencibilityCoolDown());
    }
    
    IEnumerator InvencibilityCoolDown()
    {
        _animator.SetBool("tookDamage", true);
        yield return new WaitForSecondsRealtime(1.5f);
        _animator.SetBool("tookDamage", false);
    }
    
    public int GetHealth()
    {
        return _health;
    }
    
    private void FlipSprite()
    {
        transform.localScale = new Vector2(Mathf.Sign(playerRb.velocity.x), 1);
    }
}
