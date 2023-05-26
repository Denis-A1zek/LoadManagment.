using AutoMapper;
using Sigida.LoadManagment.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Unit;

public abstract class BaseFixtureTest
{
    protected IMapper Mapper;
    protected ApplicationDbContext Context;

    [SetUp]
    public void Setup()
    {
        Mapper = FictitiosFactory.CreateMapper();
        Context = FictitiosFactory.CreateContext();
    }

    [TearDown]
    public void OnTestCompleted()
    {
        FictitiosFactory.Dispose();
    }
}
