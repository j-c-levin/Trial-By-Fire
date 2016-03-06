using TrialByFire;
using System.Collections.Generic;

public class Character
{
	private string name;
	private string className;
	private int currentExperience;
	private int currentLevel;
	private SquadSide side;
	private CharacterState currentState;
	private int maxHealth;
	private int baseEnergy;
	private int baseSpeed;
	private float turnSpeed;
	private float actionDelay;
	private int baseStrength;
	private int baseArmour;
	private int baseAccuracy;
	private int baseSync;
	private int baseToughness;
	private int energyRegen;
	private int currentHealth;
	private int currentEnergy;
	private int currentSpeed;
	private int currentStrength;
	private int currentArmour;
	private int currentAccuracy;
	private int currentSync;
	private int currentToughness;
	private int currentShield = 0;
	private Move[] moves;
	private List<Modifier> modifiers;
	private int turnCount = 1;

	public Character ()
	{
		Initialize ();
	}

	public void Initialize ()
	{
		modifiers = new List<Modifier> ();
		moves = new Move[6];
	}

	public string Name {
		get {
			return name;
		}

		set {
			name = value;
		}
	}

	public string ClassName {
		get {
			return className;
		}

		set {
			className = value;
		}
	}

	public int CurrentExperience {
		get {
			return currentExperience;
		}

		set {
			currentExperience = value;
		}
	}

	public int CurrentLevel {
		get {
			return currentLevel;
		}

		set {
			currentLevel = value;
		}
	}

	public SquadSide Side {
		get {
			return side;
		}
		set {
			side = value;
		}
	}

	public int getStat (CharacterStats stat)
	{
		switch (stat) {
		case CharacterStats.NONE:
			return 0;
		case CharacterStats.SPEED:
			return CurrentSpeed;
		case CharacterStats.STRENGTH:
			return CurrentStrength;
		case CharacterStats.ARMOUR:
			return CurrentArmour;
		case CharacterStats.ACCURACY:
			return CurrentAccuracy;
		case CharacterStats.SYNC:
			return CurrentSync;
		case CharacterStats.ENERGY:
			return CurrentChannelling;
		case CharacterStats.HEALTH:
			return CurrentHealth;
		case CharacterStats.SHIELD:
			return CurrentShield;
		default:
			return -1;
		}
	}

	public void setStat (CharacterStats stat, int value)
	{
		switch (stat) {
		case CharacterStats.NONE:
			break;
		case CharacterStats.SPEED:
			CurrentSpeed += value;
			break;
		case CharacterStats.STRENGTH:
			CurrentStrength += value;
			break;
		case CharacterStats.ARMOUR:
			CurrentArmour += value;
			break;
		case CharacterStats.ACCURACY:
			CurrentAccuracy += value;
			break;
		case CharacterStats.SYNC:
			CurrentSync += value;
			break;
		case CharacterStats.ENERGY:
			CurrentChannelling += value;
			break;
		case CharacterStats.HEALTH:
			CurrentHealth += value;
			break;
		case CharacterStats.SHIELD:
			CurrentShield += value;
			break;
		default:
			break;
		}
	}

	public void setBaseStat (CharacterStats stat, int value)
	{
		switch (stat) {
		case CharacterStats.NONE:
			break;
		case CharacterStats.SPEED:
			BaseSpeed = value;
			CurrentSpeed = BaseSpeed;
			break;
		case CharacterStats.STRENGTH:
			BaseStrength = value;
			CurrentStrength = value;
			break;
		case CharacterStats.ARMOUR:
			BaseArmour = value;
			CurrentArmour = BaseArmour;
			break;
		case CharacterStats.ACCURACY:
			BaseAccuracy = value;
			CurrentAccuracy = BaseAccuracy;
			break;
		case CharacterStats.SYNC:
			BaseSync = value;
			CurrentSync = BaseSync;
			break;
		case CharacterStats.ENERGY:
			MaxChannelling = value;
			CurrentChannelling = MaxChannelling;
			break;
		case CharacterStats.HEALTH:
			MaxHealth = value;
			CurrentHealth = MaxHealth;
			break;
		case CharacterStats.SHIELD:
			break;
		case CharacterStats.TOUGHNESS:
			baseToughness = value;
			currentToughness = baseToughness;
		default:
			break;
		}
	}

	public void setMove (Move move, int index)
	{
		moves [index] = move;
	}

	public Move getMove (int index)
	{
		return moves [index];
	}

	public List<Modifier> getModifiers ()
	{
		return modifiers;
	}

	public void removeModifier (int index)
	{
		modifiers.RemoveAt (index);
	}

	public void addModifier (Modifier newModifier)
	{
		modifiers.Add (newModifier);
	}

	public int MaxHealth {
		get {
			return maxHealth;
		}

		set {
			maxHealth = value;
		}
	}

	public int MaxChannelling {
		get {
			return baseEnergy;
		}

		set {
			baseEnergy = value;
		}
	}

	public int BaseSpeed {
		get {
			return baseSpeed;
		}

		set {
			baseSpeed = value;
		}
	}

	public int BaseStrength {
		get {
			return baseStrength;
		}

		set {
			baseStrength = value;
		}
	}

	public int BaseArmour {
		get {
			return baseArmour;
		}

		set {
			baseArmour = value;
		}
	}

	public int BaseAccuracy {
		get {
			return baseAccuracy;
		}

		set {
			baseAccuracy = value;
		}
	}

	public int BaseSync {
		get {
			return baseSync;
		}

		set {
			baseSync = value;
		}
	}

	public int BaseToughness {
		get {
			return baseToughness;
		}
		set {
			baseToughness = value;
		}
	}

	public int CurrentSpeed {
		get {
			return currentSpeed;
		}

		set {
			currentSpeed = value;
			turnSpeed = (100 / currentSpeed) * turnCount;
			if (turnCount == 1) {
				//Start of the game, store as action delay
				actionDelay = turnSpeed;
			}
		}
	}

	public int CurrentStrength {
		get {
			return currentStrength;
		}

		set {
			currentStrength = value;
		}
	}

	public int CurrentArmour {
		get {
			return currentArmour;
		}

		set {
			currentArmour = value;
		}
	}

	public int CurrentAccuracy {
		get {
			return currentAccuracy;
		}

		set {
			currentAccuracy = value;
		}
	}

	public int CurrentSync {
		get {
			return currentSync;
		}

		set {
			currentSync = value;
		}
	}

	public int CurrentHealth {
		get {
			return currentHealth;
		}

		set {
			currentHealth = value;
		}
	}

	public int CurrentChannelling {
		get {
			return currentEnergy;
		}

		set {
			currentEnergy = value;
		}
	}

	public CharacterState CurrentState {
		get {
			return currentState;
		}

		set {
			currentState = value;
		}
	}

	public float TurnSpeed {
		get {
			return turnSpeed;
		}
	}

	public int CurrentShield {
		get {
			return currentShield;
		}

		set {
			currentShield = value;
		}
	}

	public int EnergyRegen {
		get {
			return energyRegen;
		}

		set {
			energyRegen = value;
		}
	}

	public int Toughness {
		get {
			return currentToughness;
		}
		set {
			currentToughness = value;
		}
	}


	public void activeTurn ()
	{
		turnCount += 1;
		turnSpeed += actionDelay;

		CurrentSpeed = BaseSpeed;
		CurrentStrength = BaseStrength;
		CurrentArmour = BaseArmour;
		currentAccuracy = BaseAccuracy;
		CurrentSync = BaseSync;
		CurrentChannelling += energyRegen;

		activateModifiers ();
	}

	private void activateModifiers ()
	{
		for (int i = 0; i < modifiers.Count; i++) {
			modifiers [i].Move.Duration -= 1;
			if (modifiers [i].Move.Duration > 0) {
				//Resolve effect
				ActionController a = new ActionController ();
				a.calculateEffect (this, modifiers [i]);
				a = null;
			} else {
				modifiers.RemoveAt (i);
			}
		}
	}
}