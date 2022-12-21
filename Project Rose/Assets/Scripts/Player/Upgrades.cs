using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    private Player _player;
    [SerializeField] private Canvas _upgradeCanvas;
    private XPBar _xpBar;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();
        _xpBar = FindObjectOfType<XPBar>();
    }

    public void IncreaseMovementSpeed()
    {
        _player.IncreaseMovementSpeed(1.1f);
        _upgradeCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        _player.ResumeAttack();
    }

    public void IncreaseAttackSpeed()
    {
        _player.IncreaseAttackSpeed(1.1f);
        _upgradeCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        _player.ResumeAttack();
    }

    public void IncreaseXpAmount()
    {
        _xpBar.IncreaseXPAmount(1.1f);
        _upgradeCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        _player.ResumeAttack();
    }
}
