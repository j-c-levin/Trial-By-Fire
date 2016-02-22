using TrialByFire;

public class MoveFactory
{
    public Move getMove(MoveList move)
    {
        Move response = new Move();
        switch (move)
        {
            case MoveList.STAB:
                response.Name = "Stab";
                response.Duration = 0;
                response.Shape = AoE.SINGLE;
                response.BaseHitChance = 70;
                response.HitIncreaseModifier = CharacterStats.SPEED;
                response.HitDecreaseModifier = CharacterStats.SPEED;
                response.EffectStat = CharacterStats.HEALTH;
                response.BaseEffectValue = -10;
                response.EffectIncreaseModifier = CharacterStats.STRENGTH;
                response.EffectDecreaseModifier = CharacterStats.ARMOUR;
                break;
            case MoveList.OPEN_FIRE:
                response.Name = "Open Fire";
                response.Duration = 0;
                response.Shape = AoE.SINGLE;
                response.BaseHitChance = 60;
                response.HitIncreaseModifier = CharacterStats.ACCURACY;
                response.HitDecreaseModifier = CharacterStats.SPEED;
                response.EffectStat = CharacterStats.HEALTH;
                response.BaseEffectValue = -20;
                response.EffectIncreaseModifier = CharacterStats.ACCURACY;
                response.EffectDecreaseModifier = CharacterStats.ARMOUR;
                break;
            case MoveList.TAKE_COVER:
                response.Name = "Take Cover";
                response.Duration = 1;
                response.Shape = AoE.SINGLE;
                response.BaseHitChance = 100;
                response.HitIncreaseModifier = CharacterStats.NONE;
                response.HitDecreaseModifier = CharacterStats.NONE;
                response.EffectStat = CharacterStats.SHIELD;
                response.BaseEffectValue = 5;
                response.EffectIncreaseModifier = CharacterStats.NONE;
                response.EffectDecreaseModifier = CharacterStats.NONE;
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
                break;
        }
        return response;
    }
}
