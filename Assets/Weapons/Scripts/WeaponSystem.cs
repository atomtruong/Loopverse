﻿/// <summary>
/// WeaponSystem.cs
/// Author: MutantGopher
/// This script manages weapon switching.  It's recommended that you attach this to a parent GameObject of all your weapons, but this is not necessary.
/// This script allows the player to switch weapons in two ways, by pressing the numbers corresponding to each weapon, or by scrolling with the mouse.
/// </summary>

using UnityEngine;
using System.Collections;

public class WeaponSystem : MonoBehaviour
{
	public GameObject[] weapons;				// The array that holds all the weapons that the player has
	public int startingWeaponIndex = 0;			// The weapon index that the player will start with
	private int weaponIndex;                    // The current index of the active weapon

	public bool unlockedShotgun = false;
	public bool unlockedM4 = false;
	public bool unlockedKatana = false;
	public bool unlockedBeam = false;


	// Use this for initialization
	void Start()
	{
		// Make sure the starting active weapon is the one selected by the user in startingWeaponIndex
		weaponIndex = startingWeaponIndex;
		SetActiveWeapon(weaponIndex);
	}
	
	// Update is called once per frame
	void Update()
	{
		// Allow the user to instantly switch to any weapon
		if (Input.GetButtonDown("Weapon 1"))
			SetActiveWeapon(0);
		if (Input.GetButtonDown("Weapon 2"))
			if (unlockedM4 == true)
            {
				SetActiveWeapon(1);
			}
		if (Input.GetButtonDown("Weapon 3"))
			if (unlockedShotgun == true)
			{
				SetActiveWeapon(2);
			}
		if (Input.GetButtonDown("Weapon 4"))
			if (unlockedKatana == true)
			{
				SetActiveWeapon(3);
			}
		if (Input.GetButtonDown("Weapon 5"))
			if (unlockedBeam == true)
			{
				SetActiveWeapon(4);
			}
		if (Input.GetButtonDown("Weapon 6"))
			SetActiveWeapon(5);
		if (Input.GetButtonDown("Weapon 7"))
			SetActiveWeapon(6);
		if (Input.GetButtonDown("Weapon 8"))
			SetActiveWeapon(7);
		if (Input.GetButtonDown("Weapon 9"))
			SetActiveWeapon(8);

		// Allow the user to scroll through the weapons
		if (Input.GetAxis("Mouse ScrollWheel") > 0)
			NextWeapon();
		if (Input.GetAxis("Mouse ScrollWheel") < 0)
			PreviousWeapon();
	}

	void OnGUI()
	{


	}

	public void SetActiveWeapon(int index)
	{
		// Make sure this weapon exists before trying to switch to it
		if (index >= weapons.Length || index < 0)
		{
			Debug.LogWarning("Tried to switch to a weapon that does not exist.  Make sure you have all the correct weapons in your weapons array.");
			return;
		}

		// Send a messsage so that users can do other actions whenever this happens
		SendMessageUpwards("OnEasyWeaponsSwitch", SendMessageOptions.DontRequireReceiver);

		// Make sure the weaponIndex references the correct weapon
		weaponIndex = index;

		// Make sure beam game objects aren't left over after weapon switching
		weapons[index].GetComponent<Weapon>().StopBeam();

		// Start be deactivating all weapons
		for (int i = 0; i < weapons.Length; i++)
		{
			weapons[i].SetActive(false);
		}

		// Activate the one weapon that we want
		if ((index == 1 && unlockedM4 == true) || (index == 2 && unlockedShotgun == true) || (index == 3 && unlockedKatana == true) || (index == 4 && unlockedBeam == true))
		{
			weapons[index].SetActive(true);
		} else
        {
			index = 0;
			weapons[index].SetActive(true);
        }
	}

	public void NextWeapon()
	{
		weaponIndex++;
		if (weaponIndex > weapons.Length - 1)
			weaponIndex = 0;
		SetActiveWeapon(weaponIndex);
	}

	public void PreviousWeapon()
	{
		weaponIndex--;
		if (weaponIndex < 0)
			weaponIndex = weapons.Length - 1;
		SetActiveWeapon(weaponIndex);
	}
}
