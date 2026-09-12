namespace Ourogen.Templates
{
    internal interface IValueDefinition
    {
        ValueType Type { get; }
        bool IsArray { get; }
    }
}