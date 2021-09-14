using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRatio : MonoBehaviour {

    public float visionRadius;
    public float attackRadius;
    public float speed;

    [Tooltip("Prefab de la roca que se disparará")]
    public GameObject rockPrefab;
    [Tooltip("Velocidad de ataque (segundos entre ataques)")]
    public float attackSpeed = 2f;
    bool attacking;
    
    GameObject player;

    Vector3 initialPosition, target;

    void Start () {

        player = GameObject.FindGameObjectWithTag("Player");

        initialPosition = transform.position;
        
    }

    void Update () {

        
        target = initialPosition;

        
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position, 
            player.transform.position - transform.position, 
            visionRadius, 
            1 << LayerMask.NameToLayer("Default"));
        
        Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);
        Debug.DrawRay(transform.position, forward, Color.red);

        if (hit.collider != null) {
            if (hit.collider.tag == "Player"){
                target = player.transform.position;
            }
        }

        float distance = Vector3.Distance(target, transform.position);
        Vector3 dir = (target - transform.position).normalized;
        if (target.x < transform.position.x)
        {
            if (target != initialPosition && distance < attackRadius)
            {

                if (!attacking) StartCoroutine(Attack(attackSpeed));
            }
        }
        
        if (target == initialPosition && distance < 0.05f){
            transform.position = initialPosition;            
        }

       
        Debug.DrawLine(transform.position, target, Color.green);
    }

   
    void OnDrawGizmosSelected() {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
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