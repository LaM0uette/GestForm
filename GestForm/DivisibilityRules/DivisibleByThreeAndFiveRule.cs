namespace GestForm.DivisibilityRules;

public class DivisibleByThreeAndFiveRule : IDivisibilityRule
{
    public bool IsDivisible(int number) => (number % 3).Equals(0) && (number % 5).Equals(0);
    public string MessageForDivisibleNumbers => "GestForm";
}