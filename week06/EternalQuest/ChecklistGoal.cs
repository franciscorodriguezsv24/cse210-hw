class ChecklistGoal : Goal
{
    public int TargetCount { get; private set; }
    public int CurrentCount { get; private set; }
    public int BonusPoints { get; private set; }

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints)
        : base(name, points)
    {
        TargetCount = targetCount;
        BonusPoints = bonusPoints;
        CurrentCount = 0;
    }

    public override int RecordEvent()
    {
        CurrentCount++;
        if (CurrentCount >= TargetCount && !IsComplete)
        {
            IsComplete = true;
            return Points + BonusPoints;
        }
        return Points;
    }

    public override string GetStatus()
    {
        return IsComplete ? $"[X] {Name} -- Completed {CurrentCount}/{TargetCount}" : $"[ ] {Name} -- Completed {CurrentCount}/{TargetCount}";
    }
}