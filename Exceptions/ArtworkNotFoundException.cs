using CaseStudy.Models;
using CaseStudy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Exceptions
{
    internal class ArtworkNotFoundException : Exception
    {
        public ArtworkNotFoundException(string message): base(message) { }


        public static void ArtworkNotFound(int artworkID)
        {
            ArtworkRepository artworkRepository = new ArtworkRepository();
            if (!artworkRepository.ArtworkExists(artworkID))
            {

                throw new ArtworkNotFoundException("Artwork ID does not found. Try Again!!!");
            }
            
        }
    }
}
