using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public abstract class GetComponentAttribute : PropertyAttribute
{
}
/// <summary>
/// Gets a component from self
/// </summary>
public class SelfComponentAttribute : GetComponentAttribute
{
}
/// <summary>
/// Gets a component from parent
/// </summary>
public class ParentComponentAttribute : GetComponentAttribute
{
}
/// <summary>
/// Gets a component from children
/// </summary>
public class ChildrenComponentAttribute : GetComponentAttribute
{
}
/// <summary>
/// Gets a component from anywhere
/// </summary>
public class AnyComponentAttribute : GetComponentAttribute
{
}
/// <summary>
/// Gets components from self
/// </summary>
public class SelfComponentsAttribute : GetComponentAttribute
{
}
/// <summary>
/// Gets components from parents
/// </summary>
public class ParentComponentsAttribute : GetComponentAttribute
{
}
/// <summary>
/// Gets components from children
/// </summary>
public class ChildrenComponentsAttribute : GetComponentAttribute
{
}
/// <summary>
/// Gets components from anywhere
/// </summary>
public class AnyComponentsAttribute : GetComponentAttribute
{
}
