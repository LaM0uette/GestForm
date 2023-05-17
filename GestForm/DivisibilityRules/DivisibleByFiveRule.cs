namespace GestForm.DivisibilityRules;

public class DivisibleByFiveRule : IDivisibilityRule
{
    public bool IsDivisible(int number) => (number % 5).Equals(0);
    public string MessageForDivisibleNumbers => "Forme";
}