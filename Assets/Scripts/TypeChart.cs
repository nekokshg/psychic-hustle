//Contains the effectiveness matrix and logic to retrive multipliers

public static class TypeChart //static = no need to create an object to use it
{
    //[moveType, characterType]
    private static readonly float[,] chart = new float[,]
    {
        //                    Psychic Skeptic Trickster Possessed Spirit Eldritch Beast
        /* Brawl    */     { 1.5f,   1.0f,   1.0f,     1.0f,     0.5f,   0.5f,    1.5f },
        /* Loud     */     { 1.0f,   0.5f,   1.0f,     1.0f,     1.5f,   1.5f,    1.0f },
        /* Gesture  */     { 1.0f,   1.5f,   0.5f,     1.0f,     1.5f,   1.0f,    1.0f },
        /* Throw    */     { 1.0f,   1.0f,   1.0f,     1.5f,     0.5f,   1.0f,    1.5f },
        /* Psychic  */     { 1.0f,   0.5f,   1.0f,     2.0f,     2.0f,   1.5f,    1.0f },
        /* Wit      */     { 2.0f,   1.0f,   0.5f,     1.0f,     0.5f,   1.0f,    0.5f },
        /* Cursed   */     { 1.0f,   2.0f,   2.0f,     1.0f,     0.5f,   1.0f,    1.0f },
        /* Weird    */     { 1.0f,   1.0f,   1.5f,     0.5f,     1.0f,   2.0f,    1.0f },
    };

    public static float GetEffectiveness(MoveType movetype, CharacterType characterType)
    {
        return chart[(int)movetype, (int)characterType];
    }
}