namespace GestForm.DivisibilityRules;

public interface IDivisibilityRule
{
    bool IsDivisible(int number);
    string MessageForDivisibleNumbers { get; }
}