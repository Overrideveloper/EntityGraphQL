using System.Collections.Generic;
using System.Linq.Expressions;

namespace EntityQueryLanguage.DataApi.Parsing
{
  internal class DataApiNode
  {
    public string Name { get; private set; }
    public string Error { get; private set; }
    public Expression Expression { get; private set; }
    public List<DataApiNode> Fields { get; private set; }
    
    private ParameterExpression _parameter;

    internal DataApiNode(string name, Expression query, ParameterExpression parameter) {
      Name = name;
      Expression = query;
      Fields = new List<DataApiNode>();
      _parameter = parameter;
    }
    
    internal LambdaExpression AsLambda() {
      return Expression.Lambda(Expression, _parameter);
    }
    
    internal static DataApiNode MakeError(string name, string message) {
      return new DataApiNode(name, null, null) { Error = message };
    }
    
    public override string ToString() {
      return $"Node - Name={Name}, Expression={Expression}";
    }
  }
}