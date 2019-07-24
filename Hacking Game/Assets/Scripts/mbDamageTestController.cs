using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mbDamageTestController : MonoBehaviour
{
    private mbEnemy enemyScript;


    private void Start()
    {
        enemyScript = FindObjectOfType(typeof(mbEnemy)) as mbEnemy;
    }
    public void OnButtonDoDamage()
    {
        
        enemyScript.OnButtonDoDamage();
    }
}

