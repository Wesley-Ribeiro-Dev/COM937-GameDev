using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropsSystem : MonoBehaviour
{
    [SerializeField] private GameObject _experiencePointPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropExperiencePoints(Transform position, int value)
    {
        GameObject newXPPoint = Instantiate(_experiencePointPrefab, position.position, position.rotation);
        newXPPoint.GetComponent<Experience>().SetValue(value);
    }
}
