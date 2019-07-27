using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mbDamageTestController : MonoBehaviour
{
    private mbEnemy[] enemies;

    private void Start()
    {
        enemies = FindObjectsOfType<mbEnemy>();
    }
    public void OnButtonDoDamage()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].OnButtonDoDamage();
        }

    }
}

