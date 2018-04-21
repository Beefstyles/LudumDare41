using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    private Projectile _projectile;

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Projectile")
        {
            _projectile = GetComponent<Projectile>();
            switch (_projectile.projectileType)
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
        }
    }
}
