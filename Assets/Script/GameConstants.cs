using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConstants
{
    public static GameState gameState = GameConstants.GameState.MENU;

    public enum GameState
    {
        MENU,
        STARTED,
        PAUSED,
        STOPFRUITS,
        GAMEOVER,
    };


}
