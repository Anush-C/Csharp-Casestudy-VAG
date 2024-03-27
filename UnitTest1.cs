using NUnit.Framework;
using CaseStudy.Repositories;
using CaseStudy.Models;
using System.Text.RegularExpressions;
using System;

namespace ArtGallery.Tests
{
    public class Tests
    {
        [Test]
        public void addArtwork()
        {
            ArtworkRepository artworkRepository = new ArtworkRepository();
            Artwork artwork = new Artwork()
            {
                Title = "Las Meninas",
                Description = "Las Meninas is also a treatise on the nature of seeing, as well as a riddle confounding viewers about what exactly they're looking at",
                Medium = "Oil on canvas",
                ImageURL = "https://www.artmajeur.com/",
                ArtistID = 1
            };
            bool added = artworkRepository.addArtwork(artwork);
            Assert.That(added, Is.True);
        }

        [Test]
        public void UpdateArtwork()
        {
            ArtworkRepository artworkRepository = new ArtworkRepository();
            Artwork artwork = new Artwork()
            {
                ArtworkID = 4,
                Title = "Las Meninas",
                Description = "Las Meninas is also a treatise on the nature of seeing, as well as a riddle confounding viewers about what exactly they're looking at",
                CreationDate = DateTime.Parse("1885-06-25"),
                Medium = "Oil on canvas",
                ImageURL = "https://www.artmajeur.com/",
                ArtistID = 1
            };
            bool updated = artworkRepository.updateArtwork(artwork);
            Assert.That(updated, Is.True);
        }

        [TestCase(13)]
        public void removeArtwork(int artworkID)
        {
            ArtworkRepository artworkRepository = new ArtworkRepository();
            bool removed = artworkRepository.removeArtwork(artworkID);
            Assert.That(removed, Is.True);
        }

        [TestCase("mon")]

        public void SearchArtwork(string keyword)
        {
            ArtworkRepository artworkRepository = new ArtworkRepository();

            List<Artwork> artworklist = artworkRepository.searchArtworks(keyword);
            Assert.IsNotNull(artworklist, "Artwork list should not be null.");
            Assert.IsTrue(artworklist.Count > 0, "Artwork list should contain at least one item.");
        }

        [Test]
        public void AddGallery()
        {
            GalleryRepository repository = new GalleryRepository();
            Gallery gallery = new Gallery()
            {
                Name = "Guass Museum",
                Description = "Museum contains stuffed dead animals- which look real life. Giant eggs of ostritch and huge skeletons of elephant are kept for display.",
                Location = "Coimbatore",
                Curator = "Gass",
                Opening_hours = "11.00am-12.00pm",
                ArtistID = 1
            };
            bool result = repository.addGallery(gallery);
            Assert.That(result, Is.True);
        }

        [Test]
        public void UpdateGallery()
        {
            GalleryRepository repository = new GalleryRepository();
            Gallery gallery = new Gallery()
            {
                GalleryID = 3,
                Name = "Guass Museum",
                Description = "Museum contains stuffed dead animals- which look real life. Giant eggs of ostritch and huge skeletons of elephant are kept for display.",

                Location = "Coimbatore",
                Curator = "Gass",
                Opening_hours = "11.00pm - 12.45pm"
            };
            bool result = repository.UpdateGallery(gallery);
            Assert.That(result, Is.True);
        }

        [TestCase(1008)]

        public void RemoveGallery(int galleryID)
        {
            GalleryRepository repository = new GalleryRepository();
            bool result = repository.removeGallery(galleryID);
            Assert.That(result, Is.True);
        }

        [TestCase("museum")]

        public void SearchGallery(string gallkeyword)
        {
           
            GalleryRepository repository = new GalleryRepository();
            List<Gallery> gallerylist = repository.searchGallery(gallkeyword);
            Assert.IsNotNull(gallerylist, "Gallery list should not be null.");
            Assert.IsTrue(gallerylist.Count > 0, "Gallery list should contain at least one item.");
        }

    }
}