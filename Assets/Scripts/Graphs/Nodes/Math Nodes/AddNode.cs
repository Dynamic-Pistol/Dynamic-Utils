using BlueGraph;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Node(Name = "Add",Path = "Math")]
[Tags("Math")]
public class AddNode : Node
{
    [Input(Name = "Value 1")] public int itemOne;
    [Input(Name = "Value 2")] public int itemTwo;
    [Output(Name = "Sum")] public int sum;

    public override object OnRequestValue(Port port)
	{
		sum = itemOne + itemTwo;
		port.Type = sum.GetType();
        return sum;
    }
}
