using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using UMS.Domain.Models;
using UMS.Persistence;

namespace UMS.Controllers;

public class UsersController:ODataController
{
    private readonly umsContext _context;
    
    public UsersController(umsContext  context)
    {
        _context = context;
    }
    
    [EnableQuery]
    public IQueryable<User> Get()
    {
        return _context.Users;
    }
    
    
}