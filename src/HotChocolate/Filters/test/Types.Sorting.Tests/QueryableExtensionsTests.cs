using System;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace HotChocolate.Types.Sorting;

[Obsolete]
public class QueryableExtensionsTests
{
    [Fact]
    public void CompileInitialSortOperation_AscOnIQueryable_ShouldAddOrderBy()
    {
        // arrange
        var source = new Foo[0].AsQueryable();
        var closure = new SortQueryableClosure(typeof(Foo), "p");
        closure.EnqueueProperty(typeof(Foo).GetProperty(nameof(Foo.Bar)));
        var operation =
            closure.CreateSortOperation(SortOperationKind.Asc);

        // act
        var sortExpression = source.Expression.CompileInitialSortOperation(
            operation
        );
        var sorted =
            source.Provider.CreateQuery<Foo>(sortExpression);

        // assert
        Assert.Equal(source.OrderBy(s => s.Bar), sorted);
    }

    [Fact]
    public void CompileInitialSortOperation_DescOnIQueryable_ShouldAddOrderBy()
    {
        // arrange
        var source = new Foo[0].AsQueryable();
        var closure = new SortQueryableClosure(typeof(Foo), "p");
        closure.EnqueueProperty(typeof(Foo).GetProperty(nameof(Foo.Bar)));
        var operation =
            closure.CreateSortOperation(SortOperationKind.Desc);

        // act
        var sortExpression = source.Expression.CompileInitialSortOperation(
            operation
        );

        var sorted =
            source.Provider.CreateQuery<Foo>(sortExpression);


        // assert
        Assert.Equal(source.OrderByDescending(s => s.Bar), sorted);
    }

    [Fact]
    public void AddSortOperation_AscOnIOrderedQueryable_ShouldAddThenBy()
    {
        // arrange
        var source = new Foo[0].AsQueryable().OrderBy(f => f.Bar);
        var closure = new SortQueryableClosure(typeof(Foo), "p");
        closure.EnqueueProperty(typeof(Foo).GetProperty(nameof(Foo.Bar)));
        var operation =
            closure.CreateSortOperation(SortOperationKind.Asc);

        // act
        var sortExpression = source.Expression.CompileInitialSortOperation(
            operation
        );
        var sorted =
            source.Provider.CreateQuery<Foo>(sortExpression);


        // assert
        Assert.Equal(source.ThenBy(s => s.Bar), sorted);
    }

    [Fact]
    public void AddSortOperation_DescOnIOrderedQueryable_ShouldAddThenByDescending()
    {
        // arrange
        var source = new Foo[0].AsQueryable().OrderBy(f => f.Bar);
        var closure = new SortQueryableClosure(typeof(Foo), "p");
        closure.EnqueueProperty(typeof(Foo).GetProperty(nameof(Foo.Bar)));
        var operation =
            closure.CreateSortOperation(SortOperationKind.Desc);

        // act
        var sortExpression = source.Expression.CompileInitialSortOperation(
            operation
        );
        var sorted =
            source.Provider.CreateQuery<Foo>(sortExpression);


        // assert
        Assert.Equal(source.ThenByDescending(s => s.Bar), sorted);
    }

    private sealed class Foo
    {
        public string Bar { get; set; }
    }
}