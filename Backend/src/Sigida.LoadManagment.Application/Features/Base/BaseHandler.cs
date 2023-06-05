using AutoMapper;
using Sigida.LoadManagment.Application.Common.Exceptions;
using Sigida.LoadManagment.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features.Base;

public abstract class BaseHandler
{
    private readonly IMapper _mapper;    
    private readonly ApplicationDbContext _context;

    public BaseHandler(ApplicationDbContext context)
        => _context = context;

    public BaseHandler(ApplicationDbContext context,IMapper mapper) : this(context)
        => (_mapper) = (mapper);
        
    protected ApplicationDbContext Context
    {
        get { return _context ?? throw new BaseHandlerDependencyException(nameof(Context), Context.GetType()); }
        init { _context = value; }
    }

    protected IMapper Mapper
    {
        get { return _mapper ?? throw new BaseHandlerDependencyException(nameof(Mapper), Mapper.GetType()); }
        init { _mapper = value; }
    }
}
