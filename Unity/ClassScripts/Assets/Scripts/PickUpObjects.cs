﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    private Vector3 newposition;
    public bool Equiped;
    public KeyCodeData Key;
    private GameObject OBJ;
    private bool run;
    public Player player;

    private void Start()
    {
        Equiped = false;
        player.EquippedItem = null;
        player.EquippedItemName = "None";
    }

    private void OnTriggerStay(Collider obj)
    {
        if (obj.CompareTag("PickupObject"))
        {
            if (!Equiped)
            {
                if (Input.GetKeyDown(Key.key))
                {
                    OBJ = obj.gameObject;
                    OBJ.GetComponent<Rigidbody>().useGravity = false;
                    OBJ.transform.SetParent(transform);
                    newposition.x = -.4f;
                    newposition.y = 0;
                    newposition.z = 0;
                    OBJ.transform.localPosition = newposition;
                    player.EquippedItem = OBJ;
                    player.EquippedItemName = OBJ.name;
                    StartCoroutine(Equip());
                    //Equiped = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(Key.key))
                {
                    OBJ.GetComponent<Rigidbody>().useGravity = true;
                    OBJ.transform.SetParent(null);
                    player.EquippedItem = null;
                    player.EquippedItemName = "None";
                    StartCoroutine(Equip());
                    //Equiped = false;
                }
            }
        }
    }

   private IEnumerator Equip()
   {
      yield return new WaitForFixedUpdate();
      Equiped = !Equiped;
   }

    /*private void Update()
    {
        if (Equiped)
        {
            if (Input.GetKey(Key.key))
            {
                OBJ.GetComponent<Rigidbody>().useGravity = true;
                OBJ.transform.SetParent(null);
                Equiped = false;
            }
        }
    }*/
}
