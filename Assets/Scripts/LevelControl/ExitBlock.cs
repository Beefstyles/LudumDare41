using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBlock : MonoBehaviour {

    private ParticleSystem _enemyExitEffectParticle;
    private AudioSource _enemyExitedSound;
    private GameController _gameController;

    void Start()
    {
        _gameController = FindObjectOfType<GameController>();
        _enemyExitEffectParticle = GetComponent<ParticleSystem>();
        _enemyExitedSound = GetComponent<AudioSource>();
    }
	void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            _gameController.DecreaseLivesByOne();
            if (!_enemyExitEffectParticle.isPlaying)
            {
                _enemyExitEffectParticle.Play();
            }
            if (!_enemyExitedSound.isPlaying)
            {
                _enemyExitedSound.Play();
            }
        }
    }


}
