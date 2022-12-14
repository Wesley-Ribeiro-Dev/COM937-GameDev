using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] private SoulFragmentsInventory _inventory;
    [SerializeField] private TextMeshProUGUI _fragmentsDisplay;
    void Start()
    {
        _fragmentsDisplay.text = _inventory._soulsFragments.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
