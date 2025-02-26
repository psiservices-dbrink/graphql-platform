namespace HotChocolate.Types;

/// <summary>
/// This interface aggregates the most important attributes of an output-field.
/// </summary>
public interface IOutputFieldInfo : IHasName, IHasFieldCoordinate, IHasRuntimeType
{
    /// <summary>
    /// Gets the return type of this field.
    /// </summary>
    IOutputType Type { get; }

    /// <summary>
    /// Gets the field arguments.
    /// </summary>
    IFieldCollection<IInputField> Arguments { get; }
}
