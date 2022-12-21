using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResources : MonoBehaviour
{
    public static GameResources GameResourcesInstance { get; private set; }
    [SerializeField] private SoulFragmentsInventory _inventory;
    [SerializeField] private ElixirsModifiers _elixirsModifiers;

    private void Awake()
    {
        if (GameResourcesInstance == null)
        {
            GameResourcesInstance = FindObjectOfType<GameResources>();
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    
    public SoulFragmentsInventory GetInventory()
    {
        return _inventory;
    }

    public ElixirsModifiers GetModifiers()
    {
        return _elixirsModifiers;
    }
}
