﻿using Model;

namespace Repository;

public class UserRepository(DelivereaseDbContext context)
{
    public async Task<User> Add(User user)
    {
        var result = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return result.Entity;
    }
    
    public async Task<User?> Get(Guid id) =>
        await context.Users.FindAsync(id);
    
    public async Task<User> Update(User user)
    {
        var result = context.Users.Update(user);
        await context.SaveChangesAsync();
        return result.Entity;
    }
    
    public async Task Delete(Guid id)
    {
        var user = await Get(id);
        
        if (user == null)
            throw new Exception("User not found");
        
        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }
}