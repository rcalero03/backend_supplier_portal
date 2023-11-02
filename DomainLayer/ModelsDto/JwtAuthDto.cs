using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ModelsDto
{
    public class JwtAuthDto
    {
        public string? AccessToken;
        public string? RefreshToken;
    }
}
