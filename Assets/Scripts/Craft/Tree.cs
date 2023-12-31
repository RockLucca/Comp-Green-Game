using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private int totalWood;

    public void OnHit(){
        treeHealth--;

        anim.SetTrigger("isHit");

        //Considerando q sempre dara 1 de dano
        if(treeHealth == 0){
            for(int i = 0; i < totalWood; i++){
                Instantiate(woodPrefab, transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0f), transform.rotation);
            }
            anim.SetTrigger("cut");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Axe")){
            OnHit();
        }
    }
}
