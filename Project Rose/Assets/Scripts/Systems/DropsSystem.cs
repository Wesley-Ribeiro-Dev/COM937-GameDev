using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropsSystem : MonoBehaviour
{
    [SerializeField] private GameObject _experiencePointPrefab;

    [SerializeField] private GameObject _soulFragmentPrefab;

    private SoulFragmentsInventory _inventory;

    public void DropSoulFragments(Transform position)
    {
        Instantiate(_soulFragmentPrefab, position.position, position.rotation);
    }
    
    public void DropExperiencePoints(Transform position, int value)
    {
        GameObject newXPPoint = Instantiate(_experiencePointPrefab, position.position, position.rotation);
        newXPPoint.GetComponent<Experience>().SetValue(value);
    }
}
