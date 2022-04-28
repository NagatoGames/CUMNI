public class Combination
{
    public static Combination POKER = new Combination("POKER", 50, "œŒ ≈–!");
    public static Combination FOUR_OF_A_KIND = new Combination("FOUR_OF_A_KIND", 35, " ¿–≈!");
    public static Combination FULL_HOUSE = new Combination("FULL_HOUSE", 30, "‘”À ’¿”—!");
    public static Combination BIG_STREET = new Combination("BIG_STREET", 25, "—“¿–ÿ»… —“–»“!");
    public static Combination SMALL_STREET = new Combination("SMALL_STREET", 20, "Ã¿À€… —“–»“!");
    public static Combination SET = new Combination("SET", 15, "“–Œ… ¿!");
    public static Combination TWO_PAIR = new Combination("TWO_PAIR", 10, "ƒ¬≈ œ¿–€!");
    public static Combination PAIR = new Combination("PAIR", 5, "œ¿–¿!");
    public static Combination NONE = new Combination("NONE", 0, "Õ»◊≈√Œ!");

    Combination(string Title, int Score, string Description)
    {
        title = Title;
        score = Score;
        description = Description;
    }

    public string title;
    public int score;
    public string description;

    public override string ToString()
    {
        return description + "( +" + score + " œŒ)";
    }
}
