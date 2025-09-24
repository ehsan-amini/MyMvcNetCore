namespace MyMvcNetCore.Commen.Constants; 

public static class AttributesErrorMessages
{
    public const string RequiredMessage = "Please enter {0}";
    public const string MinLengthMessage = "{0} must not be less than {1} characters";
    public const string MaxLengthMessage = "{0} must not be more than {1} characters";
    public const string RegularExpressionMessage = "Please enter {0} correctly";
    public const string StringLengthMessage = "{0} must be between {2} and {1} characters";
    public const string RemoteMessage = "This {0} has already been registered in the system";
    public const string CompareMessage = "{0} does not match {1}";
    public const string RangeMessage = "{0} must be between {1} and {2}";
}
