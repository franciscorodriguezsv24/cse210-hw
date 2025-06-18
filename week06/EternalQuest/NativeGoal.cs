class NegativeGoal : Goal
{
    public NegativeGoal(string name, int points) : base(name, points) { }

    public override int RecordEvent()
    {
        return -Points;
    }

    public override string GetStatus()
    {
        return $"[-] {Name}";
    }
}