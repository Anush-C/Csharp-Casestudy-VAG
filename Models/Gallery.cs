using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Models
{
    public class Gallery
    {
        int galleryID;
        public int GalleryID { get {  return galleryID; } set {  galleryID = value; } }

        String name;
        public String Name { get { return name; } set { name = value; } }
        String description;
        public String Description { get { return description; } set { description = value; } }

        String location;
        public String Location { get { return location; } set { location = value; } }

        String curator;
        public String Curator { get {  return curator; } set {  curator = value; } }

        String opening_Hours;
        public String Opening_hours { get {  return opening_Hours; } set {  opening_Hours = value; } }

        int? artistID;
        public int? ArtistID { get { return artistID; } set { artistID = value; } }

        public Gallery() { }

        public Gallery(int galleryID, String name, String description, String location, String curator, String openingHours, int artistID)
        {
            this.galleryID = galleryID;
            this.name = name;
            this.description = description;
            this.location = location;
            this.curator = curator;
            this.opening_Hours = openingHours;
            this.artistID = artistID;


        }

        public override string ToString()
        {
            return $" {galleryID} {name} {description} {location} {curator} {opening_Hours} {artistID}";
        }
    }
}
