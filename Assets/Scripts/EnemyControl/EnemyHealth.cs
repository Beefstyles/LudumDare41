using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    private Projectile _projectile;
    public float Health;
    public int MoneyFromKill;
    private GameController _gameController;
    private StreakCounter _streakCounter;
    private LevelController _levelController;

    private void Start()
    {
        _gameController = FindObjectOfType<GameController>();
        _streakCounter = FindObjectOfType<StreakCounter>();
        _levelController = FindObjectOfType<LevelController>();

        Health += _levelController.HealthOfEnemiesMultiplication;
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Projectile")
        {
            _projectile = coll.GetComponent<Projectile>();
            /*switch (_projectile.projectileType)
            {
                case (ProjectileTypes.Fire):
                    break;
                case (ProjectileTypes.Ice):
                    break;
                case (ProjectileTypes.Poison):
                    break;
                case (ProjectileTypes.Earth):
                    break;
            }
            */
            if(_projectile != null)
            {
                Health -= _projectile.Damage * (float)_streakCounter.DamageMultiplierVal;
                Destroy(_projectile);
            }
            if (Health <= 0)
            {
                HandleDeath();
            }
        }
    }

    void HandleDeath()
    {
        _gameController.MoneyLeft += MoneyFromKill;
        _gameController.NumberOfEnemiesLeft--;
        Debug.Log("Killed Enemy");
        Destroy(gameObject);
    }
}
