//Contains the effectiveness matrix and logic to retrive multipliers

public static class TypeChart //static = no need to create an object to use it
{
    //[moveType, characterType]
    private static float[,] chart = new float[,]
    {
        {1f, 1f, 2f, 1f, 0.5f, 0.5f, 2f },
        {1f, 0.5f, 0.5f, 2f, 2f, 1.5f, 1.5f },
        {2f, 1f, 0.5f, 1f, 0.5f, 1f, 0.5f },
        {1.5f, 2f, 0.5f, 1f, 1f, 1f, 1f },
        {1f, 1.5f, 2f, 1.5f, 1f, 2f, 1f },
    };

    public static float GetEffectiveness(MoveType movetype, CharacterType characterType)
    {
        return chart[(int)movetype, (int)characterType];
    }
}