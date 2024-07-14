using System.Linq.Expressions;

namespace resumr;

public static class ExpressionExercise
{
    public static void Test()
    {
        var pc = new PropertyConsumer();
        pc.Visit((Test g) => new
        {
            a = g.A,
            b = g.B,
            sost = new
            {
                g.C
            }
        });
    }
}

public class PropertyConsumer : ExpressionVisitor
{
    private readonly ParameterExpression _parameter;
    private readonly HashSet<string> _properties = new();


    protected override Expression VisitMember(MemberExpression node)
    {
        if (node.Expression.NodeType == ExpressionType.Parameter)
            _properties.Add(node.Member.Name);
        return base.VisitMember(node);
    }
}

public class Test
{
    public string A { get; set; }
    public string B { get; set; }
    public object C { get; set; }
}