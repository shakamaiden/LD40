﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPoint : MonoBehaviour {

    public int dropType;

    ItemManager pItemManager;
    bool canDrop;
    public GameObject woodCart, metalCart;
    Material materialWood, materialMetal;

    private void Awake()
    {
        pItemManager = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemManager>();
        materialWood = woodCart.GetComponent<Renderer>().material;
        materialMetal = metalCart.GetComponent<Renderer>().material;

    }

    private void Start()
    {
        canDrop = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            canDrop = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            canDrop = false;
        }
    }

    void OnMouseEnter() {
        materialWood.color = Color.yellow;
        materialMetal.color = Color.yellow ;
    }

    void OnMouseExit() {
        materialWood.color = Color.white;
        materialMetal.color = Color.white;
    }

    private void OnMouseDown()
    {
        if(canDrop)
        {
            materialWood.color = Color.green;
            materialMetal.color = Color.green;
            pItemManager.DropPoint(dropType);
        }
        else
        {
            materialWood.color = Color.red;
            materialMetal.color = Color.red;
        }
    }    

    void OnMouseUp() {
        materialWood.color = Color.yellow;
        materialMetal.color = Color.yellow;
    }
}
