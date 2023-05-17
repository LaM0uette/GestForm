namespace GestForm.DivisibilityRules;

public class DivisibleByThreeRule : IDivisibilityRule
{
    public bool IsDivisible(int number) => (number % 3).Equals(0);
    public string MessageForDivisibleNumbers => "Geste";
}