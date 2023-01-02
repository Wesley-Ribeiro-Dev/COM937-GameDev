using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    private Player _player;
    [SerializeField] private Canvas _upgradeCanvas1;
    [SerializeField] private Canvas _upgradeCanvas2;
    private XPBar _xpBar;
    private CounterManager _counterManager;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();
        _xpBar = FindObjectOfType<XPBar>();
        _counterManager = FindObjectOfType<CounterManager>();
    }

    public void IncreaseMovementSpeed()
    {
        _player.IncreaseMovementSpeed(1.12f);
        _upgradeCanvas1.gameObject.SetActive(false);
        Time.timeScale = 1;
        _player.ResumeAttack();
    }

    public void IncreaseAttackSpeed()
    {
        _player.IncreaseAttackSpeed(1.12f);
        _upgradeCanvas1.gameObject.SetActive(false);
        Time.timeScale = 1;
        _player.ResumeAttack();
    }

    public void IncreaseXpAmount()
    {
        _xpBar.IncreaseXPAmount(1.25f);
        _upgradeCanvas1.gameObject.SetActive(false);
        Time.timeScale = 1;
        _player.ResumeAttack();
    }

    public void DecreaseDashCooldown()
    {
        _player.DecreaseDashCooldown();
        _upgradeCanvas2.gameObject.SetActive(false);
        Time.timeScale = 1;
        _player.ResumeAttack();
    }

    public void IncreaseProjectileSpeed()
    {
        _player.IncreaseProjectileSpeed();
        _upgradeCanvas2.gameObject.SetActive(false);
        Time.timeScale = 1;
        _player.ResumeAttack();
    }

    public void IncreaseSoulsFragmentModifier()
    {
        _counterManager.IncreaseModifier();
        _upgradeCanvas2.gameObject.SetActive(false);
        Time.timeScale = 1;
        _player.ResumeAttack();
    }
}
