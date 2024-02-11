using System.Collections.Generic;

public interface IStateDelegate
{
    Dictionary<int, IState> InitStates();

}
