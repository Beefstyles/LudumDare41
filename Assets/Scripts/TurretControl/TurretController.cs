using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject Projectile;
    private bool _canFire = false;
    private Transform _targetTransform;
    public float StrengthOfShot;
    public float ReloadSpeed;
    private ProjectileTypes _projectileType;
    GameController _gameController;


    void Start()
    {
        _gameController = FindObjectOfType<GameController>();
        _projectileType = Projectile.GetComponentInChildren<Projectile>().projectileType;
    }
    void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            _targetTransform = coll.gameObject.transform;
            transform.LookAt(_targetTransform);
            if (_canFire)
            {
                FireAtTarget();
               _canFire = false;
               // StartCoroutine("DelayFire");
            }
        }
    }

    private void FireAtTarget()
    {
        GameObject projectile = Instantiate(Projectile, transform.position, transform.rotation);
        projectile.GetComponent<Rigidbody>().AddForce((_targetTransform.position - transform.position)* StrengthOfShot);
    }

    public void SetIfCanFire(NoteNumbers note)
    {
        switch (note)
        {
            case (NoteNumbers.Note1):
                if(_projectileType == ProjectileTypes.Fire)
                {
                    _canFire = true;
                }
                else
                {
                    _canFire = false;
                }
                break;
            case (NoteNumbers.Note2):
                if (_projectileType == ProjectileTypes.Ice)
                {
                    _canFire = true;
                }
                else
                {
                    _canFire = false;
                }
                break;
            case (NoteNumbers.Note3):
                if (_projectileType == ProjectileTypes.Poison)
                {
                    _canFire = true;
                }
                else
                {
                    _canFire = false;
                }
                break;
            case (NoteNumbers.Note4):
                if (_projectileType == ProjectileTypes.Earth)
                {
                    _canFire = true;
                }
                else
                {
                    _canFire = false;
                }
                break;
        }
    }
    IEnumerator DelayFire()
    {
        yield return new WaitForSeconds(ReloadSpeed);
        _canFire = true;
    }

}
