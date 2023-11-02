using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ModelsDto
{
    public class JwtClaimsDto
    {
        public string Email { get; set; }
        public string AppId { get; set; }
        public string AppDisplayName { get; set; }
        public string Name { get; set; }
        public DateTime Expiration { get; set; }
        public string UserId { get; set; }

    }
}
