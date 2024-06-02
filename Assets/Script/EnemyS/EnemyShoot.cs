using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemmyBullet; //prefab de la bala
    public Transform spawnBulletPoint; //Punto desde donde se dispara la bala  
    private Transform playerPosition; 
    public float bulletVelocity = 100; 
    private Animator enemyAnimator; 
    void Start()
    {
        playerPosition = FindObjectOfType<PlayerConPruebas>().transform; // encontrar la posicion del player
        enemyAnimator = GetComponent<Animator>();        
    }

    void ShootPlayer()
    {
        Vector3 playerDirection = playerPosition.position - transform.position; //direcion que sale la bala 
        GameObject newBullet = Instantiate(enemmyBullet, spawnBulletPoint.position, spawnBulletPoint.rotation);// se instancia la bala
        newBullet.GetComponent<Rigidbody>().AddForce(playerDirection.normalized * bulletVelocity, ForceMode.Impulse);
    }
}
