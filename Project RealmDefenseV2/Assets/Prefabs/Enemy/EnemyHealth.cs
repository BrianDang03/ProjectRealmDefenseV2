using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHp = 5;

    [Tooltip("Adds amount to maxHp when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;
    int currentHp = 0;

    Enemy enemy;

    void OnEnable()
    {
        currentHp = maxHp;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHp--;

        if (currentHp < 1)
        {
            gameObject.SetActive(false);
            maxHp += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
