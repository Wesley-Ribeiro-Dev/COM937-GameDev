using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Elixir Modifiers", menuName = "Perennial Elixirs Modifiers")]
public class ElixirsModifiers : ScriptableObject
{
    public float health;
    public float defense;
    public float damage;
    public int cost;
}
