﻿using TrialByFire;

public static class MoveFactory
{
	public static Move generateMove (MoveList move)
	{
		Move response = new Move ();
		switch (move) {
		case MoveList.OPEN_FIRE:
			response.Name = "Open Fire";
			response.Duration = 0;
			response.Shape = AoE.SINGLE;
			response.BaseHitChance = 60;
			response.HitIncreaseModifier = CharacterStats.ACCURACY;
			response.HitDecreaseModifier = CharacterStats.SPEED;
			response.EffectStat = CharacterStats.HEALTH;
			response.BaseEffectValue = -100;
			response.EffectIncreaseModifier = CharacterStats.ACCURACY;
			response.EffectDecreaseModifier = CharacterStats.ARMOUR;
			response.Target = MoveTarget.ENEMY;
			break;
		case MoveList.DASH:
			response.Name = "Dash";
			response.Duration = 1;
			response.Shape = AoE.SINGLE;
			response.BaseHitChance = 100;
			response.HitIncreaseModifier = CharacterStats.NONE;
			response.HitDecreaseModifier = CharacterStats.NONE;
			response.EffectStat = CharacterStats.SPEED;
			response.BaseEffectValue = 10;
			response.EffectIncreaseModifier = CharacterStats.NONE;
			response.EffectDecreaseModifier = CharacterStats.NONE;
			response.Target = MoveTarget.SELF;
			break;
		case MoveList.FIRST_AID:
			response.Name = "First Aid";
			response.Duration = 0;
			response.Shape = AoE.SINGLE;
			response.BaseHitChance = 100;
			response.HitIncreaseModifier = CharacterStats.NONE;
			response.HitDecreaseModifier = CharacterStats.NONE;
			response.EffectStat = CharacterStats.HEALTH;
			response.BaseEffectValue = 10;
			response.EffectIncreaseModifier = CharacterStats.NONE;
			response.EffectDecreaseModifier = CharacterStats.NONE;
			response.Target = MoveTarget.FRIENDLY;
			break;
		case MoveList.GRENADE:
			response.Name = "Grenade";
			response.Duration = 0;
			response.Shape = AoE.DOUBLE_PENETRATING;
			response.BaseHitChance = 55;
			response.HitIncreaseModifier = CharacterStats.ACCURACY;
			response.HitDecreaseModifier = CharacterStats.SPEED;
			response.EffectStat = CharacterStats.HEALTH;
			response.BaseEffectValue = -10;
			response.EffectIncreaseModifier = CharacterStats.NONE;
			response.EffectDecreaseModifier = CharacterStats.NONE;
			response.Target = MoveTarget.ENEMY;
			break;
		case MoveList.TAKE_COVER:
			response.Name = "Take Cover";
			response.Duration = 1;
			response.Shape = AoE.SINGLE;
			response.BaseHitChance = 100;
			response.HitIncreaseModifier = CharacterStats.NONE;
			response.HitDecreaseModifier = CharacterStats.NONE;
			response.EffectStat = CharacterStats.SHIELD;
			response.BaseEffectValue = 10;
			response.EffectIncreaseModifier = CharacterStats.NONE;
			response.EffectDecreaseModifier = CharacterStats.NONE;
			response.Target = MoveTarget.SELF;
			break;
		case MoveList.SUPPRESSIVE_FIRE:
			response.Name = "Suppressive Fire";
			response.Duration = 1;
			response.Shape = AoE.DOUBLE;
			response.BaseHitChance = 50;
			response.HitIncreaseModifier = CharacterStats.ACCURACY;
			response.HitDecreaseModifier = CharacterStats.SPEED;
			response.EffectStat = CharacterStats.ACCURACY;
			response.BaseEffectValue = -10;
			response.EffectIncreaseModifier = CharacterStats.NONE;
			response.EffectDecreaseModifier = CharacterStats.NONE;
			response.Target = MoveTarget.ENEMY;
			break;
		case MoveList.FERAL_SWIPE:
			response.Name = "Stab";
			response.Duration = 0;
			response.Shape = AoE.SINGLE;
			response.BaseHitChance = 70;
			response.HitIncreaseModifier = CharacterStats.SPEED;
			response.HitDecreaseModifier = CharacterStats.SPEED;
			response.EffectStat = CharacterStats.HEALTH;
			response.BaseEffectValue = -20;
			response.EffectIncreaseModifier = CharacterStats.STRENGTH;
			response.EffectDecreaseModifier = CharacterStats.ARMOUR;
			response.Target = MoveTarget.ENEMY;
			break;
		case MoveList.PROJECT_FEAR:
			response.Name = "Project Fear";
			response.Duration = 1;
			response.Shape = AoE.SINGLE_PENETRATING;
			response.BaseHitChance = 60;
			response.HitIncreaseModifier = CharacterStats.SYNC;
			response.HitDecreaseModifier = CharacterStats.SYNC;
			response.EffectStat = CharacterStats.STRENGTH;
			response.BaseEffectValue = -10;
			response.EffectIncreaseModifier = CharacterStats.NONE;
			response.EffectDecreaseModifier = CharacterStats.NONE;
			response.Target = MoveTarget.ENEMY;
			break;
		case MoveList.HUNT:
			response.Name = "Hunt";
			response.Duration = 1;
			response.Shape = AoE.SINGLE;
			response.BaseHitChance = 55;
			response.HitIncreaseModifier = CharacterStats.SYNC;
			response.HitDecreaseModifier = CharacterStats.SYNC;
			response.EffectStat = CharacterStats.SPEED;
			response.BaseEffectValue = +20;
			response.EffectIncreaseModifier = CharacterStats.NONE;
			response.EffectDecreaseModifier = CharacterStats.NONE;
			response.Target = MoveTarget.ENEMY;
			break;
		default:
			response.Name = "";
			response.Duration = 0;
			response.Shape = AoE.SINGLE;
			response.BaseHitChance = 0;
			response.HitIncreaseModifier = CharacterStats.NONE;
			response.HitDecreaseModifier = CharacterStats.NONE;
			response.EffectStat = CharacterStats.NONE;
			response.BaseEffectValue = 0;
			response.EffectIncreaseModifier = CharacterStats.NONE;
			response.EffectDecreaseModifier = CharacterStats.NONE;
			response.Target = MoveTarget.NONE;
			break;
		}
		return response;
	}
}
