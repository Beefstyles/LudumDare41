using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject Projectile;
    private bool _canFire = false;
    public Transform TargetTransform;
    public float StrengthOfShot;
    public float ReloadSpeed;
    private ProjectileTypes _projectileType;
    GameController _gameController;
    public bool HaveTarget = false;


    void Start()
    {
        _gameController = FindObjectOfType<GameController>();
        _projectileType = Projectile.GetComponentInChildren<Projectile>().projectileType;
    }

    void Update()
    {
        if (HaveTarget)
        {
            transform.LookAt(TargetTransform);
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
        if(projectile != null && TargetTransform.position != null)
        {
            projectile.GetComponent<Rigidbody>().AddForce((TargetTransform.position - transform.position) * StrengthOfShot);
        }

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
