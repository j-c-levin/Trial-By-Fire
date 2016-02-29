using UnityEngine;
using UnityEngine.UI;

public class Battle1Squads : MonoBehaviour {

    public Image[] PlayerSquadTiles;
    public Image[] MobSquadTiles;

    public Squad PlayerSquad;
    public Squad MobSquad;

    public void UpdateSquadTiles()
    {
        for (int i = 0; i < 6; i++)
        {
            PlayerSquadTiles[i].GetComponentInChildren<Text>().text = PlayerSquad.getCharacterAtPosition((TrialByFire.SquadPosition)i).Name;

            MobSquadTiles[i].GetComponentInChildren<Text>().text = MobSquad.getCharacterAtPosition((TrialByFire.SquadPosition)i).Name;
        }
    }
}
