using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartAssessment.Application.Interfaces
{
    public interface ITokenGenerator
    {
        string GenerateToken(int userId);
        bool ValidateToken(string token);
        string GetClaim(string claimType, string token);
    }
}
