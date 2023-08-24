using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApp.Models
{
    public class Author
    {
        [Required]
        public string AuthorId { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        
        public ICollection<Playlist> playlists { get; set; }
    }
}
