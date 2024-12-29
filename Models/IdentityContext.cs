using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Advanced.Models;

public class IdentityContext(DbContextOptions<IdentityContext> options) : IdentityDbContext<IdentityUser>(options);