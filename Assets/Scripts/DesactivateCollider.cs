using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivateCollider : MonoBehaviour
{
    public Collider2D[] colliders;

    private void Awake()
    {
          colliders = gameObject.GetComponentsInChildren<Collider2D>();        
          for(int i = 1; i < colliders.Length; i++)
          {
              colliders[i].gameObject.SetActive(false);
          }

    }

    void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {
            for (int i = 1; i < colliders.Length; i++)
            {
                colliders[i].gameObject.SetActive(true);
            }
        }
    }
}
