using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour
{
		//TINKER
	public static int playerHealth;				//FULL = 100	INCAP < 10
	public static bool playerInjured;			//MOVEMENT / 2 WHEN playerHealth < 50

		//WEAPONS
	public static bool meleeOneHand;			//1-HANDED MELEE EQUIPPED
	public static bool meleeTwoHand;			//2-HANDED MELEE EQUIPPED
	public static bool gunOneHand;				//1-HANDED FIREARM EQUIPPED
	public static bool gunTwoHand;				//2-HANDED FIREARM EQUIPPED
	public static bool throwWeapon;				//THROWABLE WEAPON EQUIPPED

		//PASSIVE UPGRADES
	public static bool hasGhillieSuit;			//ADDED COVER RATING
	public static bool hasGreaves;				//PROTECTION AGAINST DAMAGE AND TRAPS
	public static bool hasChestplate;			//PROTECTION AGAINST DAMAGE
	public static bool hasHelmet;				//PROTECTION AGAINST DAMAGE
	
	public static bool hasBandolierOne;			//BANDOLIERS FOR AMMO
	public static bool hasBandolierTwo;

	public static bool hasHolsterOne;			//HOLSTERS FOR 1-HANDED WEAPONS
	public static bool hasHolsterTwo;

	public static bool hasSling;				//SLINGS FOR 2-HANDED WEAPONS

	public static bool hasBackpack;				//BACKPACK ADDS FIVE ITEM SLOTS

	public static bool hasPouchOne;				//POUCHES ADD 3 ITEM SLOTS EACH
	public static bool hasPouchTwo;
	public static bool hasPouchThree;

		//BOOLS
	public static bool headshotCapable;			//FALSE IF WEARING HELMET
	public static bool bodyshotCapable;			//FALSE IF WEARING ARMOUR
	public static bool stateIncap;				//IF ENEMY HEALTH < 10
	
		//ENEMY HEALTH
	public static int zombieHealth = 100;		//INCAP < 10
	public static int banditHealth = 70;		//INCAP < 10
	public static int fellowshipHealth = 100;	//INCAP < 10
	public static int sniperHealth = 100;		//INCAP < 10
	public static int ubcHealth = 100;			//INCAP < 10
	public static int survivorHealth = 50;		//INCAP < 10
	public static int dogHealth = 30;			//INCAP < 10
	public static int greyHealth = 50;			//INCAP < 10
	
		//ENEMY MOVE SPEED						  P - S    - A		(PASSIVE - SUSPICIOUS - ALERT)
	public static float zombieSpeed = 1f;		//1 - 2    - 3
	public static float banditSpeed = 5f;		//5 - 7.5  - 10
	public static float ascendedSpeed = 2f;		//2 - 4    - 6
	public static float sniperSpeed = 0f;		//0 - 0    - 0
	public static float fellowshipSpeed = 5f;	//5 - 7.5  - 11
	public static float ubcSpeed = 5f;			//5 - 7.5  - 10
	public static float survivorSpeed = 5f;		//5 - 7.5  - 10
	public static float dogSpeed = 5;			//5 - 10   - 12.5
	public static float greySpeed = 5f;			//5 - 7.5  - 10
	
		//ENEMY DISCIPLINE
	public static bool disciplineWeak;			//50% BANDITS	-	80% SURVIVORS
	public static bool disciplineAverage;		//50% BANDITS	-	20% SURVIVORS
	public static bool disciplineStrong;		//UBC GUARDSMEN	-	DOGS
	public static bool disciplineFuckYou;		//FELLOWSHIP	-	ASCENDANTS	-	ZOMBIES

		//ANIMATOR BOOLS
	public static int incapState;				//WHEN A CHARACTER IS DOWN TO < 10HP
	public static int deadBool;					//WHEN THE PLAYER IS DEAD
	public static int locomotionState;			//WHEN THE PLAYER IS MOVING
	public static int sneakBool;				//WHEN THE PLAYER IS SNEAKING
	public static int walkBool;					//WHEN THE PLAYER IS WALKING 
	public static int sprintBool;				//WHEN THE PLAYER IS SPRINTING
	
	public static int enemyIncapState;			//WHEN ENEMY IS DOWN TO < 10HP
	public static int enemyDeadBool;			//WHEN ENEMY IS DEAD.
	public static int enemyPassiveState;		//WANDERING, PATROLLING, UNSUSPICIOUS			SPEED IS NORMAL
	public static int enemySuspiciousState;		//WHEN SOMETHING HAS CAUGHT THEIR ATTENTION		SPEED IS INCREASED
	public static int enemyAlertState;			//WHEN ENEMY HAS SPOTTED THE PLAYER				SPEED IS FURTHER INCREASED


	void Awake()
	{
		//REFERENCE TO ANIMATIONS
	}

		//QUEST ITEMS
	public static bool hasWillNecklace;
	public static bool hasBloodTestKit;
	public static bool hasArdenKnife;
	public static bool hasFriendshipBracelet;
	public static bool hasFellowshipSpade;
	public static bool hasNightVisionGoggles;

		//SIDE QUEST BOOLS
	public bool hasEvidence;					//HANNAH
}
