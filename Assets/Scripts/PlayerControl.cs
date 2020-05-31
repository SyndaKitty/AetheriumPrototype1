﻿using UnityEngine;

[RequireComponent(typeof(Ship))]
public class PlayerControl : MonoBehaviour
{
    Ship ship;
    WeaponMount assignedWeapon;
    int assignedIndex;

    void Start()
    {
        ship = GetComponent<Ship>();
        SwapWeapon(assignedIndex);
    }

    void SwapWeapon(int index)
    {
        assignedWeapon = ship.weapons[index];
    }

    void Update()
    {
        ship.Control(Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
        
        
        if (Input.GetKey(KeyCode.Space))
        {
            assignedWeapon.TryShoot();
        }

        assignedWeapon.ManualTargetSet = true;
        assignedWeapon.Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // TODO: Assign targets for manual weapons, even if not assigned?
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (assignedWeapon)
            {
                assignedWeapon.ManualTargetSet = false;
            }

            assignedIndex++;
            assignedIndex %= ship.weapons.Length;
            SwapWeapon(assignedIndex);
        }
    }
    
}