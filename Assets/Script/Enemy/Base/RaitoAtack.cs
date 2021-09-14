using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaitoAtack : MonoBehaviour
{ 
    public float attackRadius;
    public float speed;


    
    [Tooltip("Prefab de la roca que se disparará")]
    public GameObject rockPrefab;
    [Tooltip("Velocidad de ataque (segundos entre ataques)")]
    public float attackSpeed = 2f;
    bool attacking;
    
    GameObject player;
    
    Vector3 initialPosition, target;

    

    void Start()
    {        
        player = GameObject.FindGameObjectWithTag("Player");
        
        initialPosition = transform.position;        
    }

    void Update()
    {
        // Por defecto nuestro target siempre será nuestra posición inicial
        target = initialPosition;

        // Comprobamos un Raycast del enemigo hasta el jugador
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            player.transform.position - transform.position,
            attackRadius,
            1 << LayerMask.NameToLayer("Default")
        // Poner el propio Enemy en una layer distinta a Default para evitar el raycast
        // También poner al objeto Attack y al Prefab Slash una Layer Attack 
        // Sino los detectará como entorno y se mueve atrás al hacer ataques
        );

        // Aquí podemos debugear el Raycast
        Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);
        Debug.DrawRay(transform.position, forward, Color.red);

        // Si el Raycast encuentra al jugador lo ponemos de target
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player")
            {
                target = player.transform.position;
            }
        }
        target = initialPosition;

        float distance = Vector3.Distance(target, transform.position);
        if (distance < attackRadius)
        {
            if (!attacking) StartCoroutine(Attack(attackSpeed));
        }

    }

    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRadius);

    }


    IEnumerator Attack(float seconds)
    {
        attacking = true;  
       
        if (target != initialPosition && rockPrefab != null)
        {
            Instantiate(rockPrefab, transform.position, transform.rotation);           
            yield return new WaitForSeconds(seconds);    
        }
        attacking = false; 
    }

}