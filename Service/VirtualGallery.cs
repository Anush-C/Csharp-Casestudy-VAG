using CaseStudy.Repositories;
using CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseStudy.Exceptions;

namespace CaseStudy.Service
{
    internal class VirtualGallery
    {
        private readonly ArtworkRepository _repository;
        private readonly UserFavouriteRepository _userFavouriteRepository;
        private readonly GalleryRepository _galleryRepository;


        public VirtualGallery()
        {
            _repository = new ArtworkRepository();
            _userFavouriteRepository = new UserFavouriteRepository();
            _galleryRepository = new GalleryRepository();

        }

        public void addRecords(Artwork artwork)
        {
            if(_repository.addArtwork(artwork))
            {
                Console.WriteLine("Added successfully");
            }
            else
            {
                Console.WriteLine("Not Added successfully");
            }
        }

        public void UpdateArtworks(Artwork artwork)
        {
            try
            {
                ArtworkNotFoundException.ArtworkNotFound(artwork.ArtworkID);
                if (_repository.updateArtwork(artwork))
                    Console.WriteLine("Updated successfully");
                else
                    Console.WriteLine("Not updated successfully. Try again!!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RemoveArtworks(int artworkId)
        {
            try
            {
                ArtworkNotFoundException.ArtworkNotFound(artworkId);
                if (_repository.removeArtwork(artworkId))
                    Console.WriteLine("Removed successfully");
                else
                    Console.WriteLine("Not removed successfully.Try again!!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void getArtworks(int artworkID)
        {
            try
            {
                ArtworkNotFoundException.ArtworkNotFound(artworkID);
                _repository.getArtworkById(artworkID);
                Console.WriteLine("Artwork received successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void searchArtwork(string keyword)
        {
            foreach (Artwork item in _repository.searchArtworks(keyword))
                Console.WriteLine(item);
        }

        public void addFavorite(int u_id, int a_id)
        {
            try
            {
                UserNotFoundException.UserNotFound(u_id);
                ArtworkNotFoundException.ArtworkNotFound(a_id);
                if (_userFavouriteRepository.addArtworkToFavorite(u_id, a_id))
                    Console.WriteLine("Favorite artwork added successfully");
                else
                    Console.WriteLine("Operation unsuccessful");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void removeFavorite(int u_id, int a_id)
        {
            try
            {
                UserNotFoundException.UserNotFound(u_id);
                ArtworkNotFoundException.ArtworkNotFound(a_id);
                if (_userFavouriteRepository.removeArtworkFromFavorite(u_id, a_id))
                    Console.WriteLine("Favorite artwork removed unsuccessfully");
                else
                    Console.WriteLine("Operation unsuccessful");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void getUserFavourite(int userId)
        {
            try
            {
                UserNotFoundException.UserNotFound(userId);
                Console.WriteLine(_userFavouriteRepository.getUserFavouriteArtworks(userId));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void searchGallery(string keyword)
        {
            foreach (Gallery item in _galleryRepository.searchGallery(keyword))
                Console.WriteLine(item);
        }

        public void MainMenu()
        {

            int choice = 0, choice1 = 0, choice2 = 0, choice3 = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Your Main Menu");
                Console.WriteLine("---------------\n");
                Console.WriteLine("1: Artwork Management\n2: User Favorite Management\n3: Gallery Management\n4: Exit");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Artwork Management");
                            Console.WriteLine("---------------------");
                            Console.WriteLine("1. Add Artwork\n2. Update Artwork\n3. Remove Artwork\n4.Get Artwork\n5.Search Artwork\n6. Exit\n");
                            Console.WriteLine("Enter your choice: ");
                            choice1 = int.Parse(Console.ReadLine());
                            Artwork artwork;
                            switch (choice1)
                            {
                                case 1:
                                    Console.WriteLine("Enter title: ");
                                    string title = Console.ReadLine();
                                    Console.WriteLine("Enter description: ");
                                    string des = Console.ReadLine();
                                    Console.WriteLine("Enter creation date: ");
                                    string cdate = Console.ReadLine();
                                    Console.WriteLine("Enter medium: ");
                                    string medium = Console.ReadLine();
                                    Console.WriteLine("Enter image url: ");
                                    string imurl = Console.ReadLine();
                                    Console.WriteLine("Enter artist id: ");
                                    int artistID = int.Parse(Console.ReadLine());
                                    artwork = new Artwork() { Title = title, Description = des, CreationDate = DateTime.Parse(cdate), Medium = medium, ImageURL = imurl, ArtistID = artistID };
                                    addRecords(artwork);
                                    Console.WriteLine("Artwork added succesfully");
                                    Console.WriteLine("Press any key to return to the main menu...");
                                    Console.ReadKey();
                                    break;

                                case 2:
                                    Console.WriteLine("Enter artwork id: ");
                                    int artID = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter title: ");
                                    string upd_title = Console.ReadLine();
                                    Console.WriteLine("Enter description: ");
                                    string upd_desc = Console.ReadLine();
                                    Console.WriteLine("Enter creation date: ");
                                    DateTime upd_date = DateTime.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter medium: ");
                                    string upd_medium = Console.ReadLine();
                                    Console.WriteLine("Enter image url: ");
                                    string upd_url = Console.ReadLine();
                                    Console.WriteLine("Enter artist id: ");
                                    int upd_artistId = int.Parse(Console.ReadLine());
                                    artwork = new Artwork(artID, upd_title, upd_desc, upd_date, upd_medium, upd_url, upd_artistId);
                                    UpdateArtworks(artwork);
                                    Console.WriteLine("Artwork Updated Successfully");
                                    Console.WriteLine("Press any key to return to the main menu...");
                                    Console.ReadKey();
                                    break;

                                case 3:
                                    Console.WriteLine("Enter artwork id: ");
                                    int art_id = int.Parse(Console.ReadLine());
                                    RemoveArtworks(art_id);
                                    Console.WriteLine("Artwork Removed Successfully");
                                    Console.WriteLine("Press any key to return to the main menu...");
                                    Console.ReadKey();
                                    break;

                                case 4:
                                    Console.WriteLine("Enter artwork id: ");
                                    int art1_id = int.Parse(Console.ReadLine());
                                    getArtworks(art1_id);
                                    Console.WriteLine("Press any key to return to the main menu...");
                                    Console.ReadKey();
                                    break;

                                case 5:
                                    Console.WriteLine("Enter a keyword to search for:");
                                    string keyword = Console.ReadLine();
                                    searchArtwork(keyword);
                                    Console.WriteLine("Press any key to return to the main menu...");
                                    Console.ReadKey();
                                    break;


                                case 6:
                                    Console.WriteLine("Redirecting to Main menu....Please Wait!!!");
                                    break;

                                default:
                                    Console.WriteLine("Please Try again!!!");
                                    break;
                            }
                        } while (choice1 != 6);
                        break;

                    case 2:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("User Favorite Management");
                            Console.WriteLine("------------------------");
                            Console.WriteLine("1. Add Favorites\n2. Remove Favorites\n3. Get Favorites\n4. Exit\n");
                            Console.WriteLine("Enter your choice: ");
                            choice2 = int.Parse(Console.ReadLine());
                            switch (choice2)
                            {
                                case 1:
                                    Console.WriteLine("Enter user id: ");
                                    int userID = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter Artwork id: ");
                                    int artworkID = int.Parse(Console.ReadLine());
                                    addFavorite(userID, artworkID);
                                    Console.WriteLine("Added successfully");
                                    Console.WriteLine("Press any key to return to the main menu...");
                                    Console.ReadKey();
                                    break;

                                case 2:
                                    Console.WriteLine("Enter user id: ");
                                    int user_id = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter Artwork id: ");
                                    int artwork_id = int.Parse(Console.ReadLine());
                                    removeFavorite(user_id, artwork_id);
                                    Console.WriteLine("Removed successfully");
                                    Console.WriteLine("Press any key to return to the main menu...");
                                    Console.ReadKey();
                                    break;

                                case 3:
                                    Console.WriteLine("Enter user id: ");
                                    int upd_id = int.Parse(Console.ReadLine());
                                    getUserFavourite(upd_id);
                                    Console.WriteLine("Press any key to return to the main menu...");
                                    Console.ReadKey();
                                    break;

                                case 4:
                                    Console.WriteLine("Redirecting to Main menu. Plese Wait...");
                                    break;

                                default:
                                    Console.WriteLine("Try again!!!");
                                    break;
                            }
                        } while (choice2 != 4);
                        break;

                    case 3:
                        GalleryService galleryService = new GalleryService();
                        do
                        {
                            Console.WriteLine("Gallery Management");
                            Console.WriteLine("-------------------");
                            Console.WriteLine("1.Add Gallery\n2.Update Gallery\n3.Remove Gallery\n4.Search Gallery\n5.Exit");
                            Console.WriteLine("Enter your choice:");
                            choice3 = int.Parse(Console.ReadLine());
                            Gallery gallery;
                            switch (choice3)
                            {
                                case 1:
                                    Console.WriteLine("Enter Name: ");
                                    string name = Console.ReadLine();
                                    Console.WriteLine("Enter description: ");
                                    string des = Console.ReadLine();
                                    Console.WriteLine("Enter Location: ");
                                    string loc = Console.ReadLine();
                                    Console.WriteLine("Enter Openiong hours: ");
                                    string opnh = Console.ReadLine();
                                    Console.WriteLine("Enter Curator: ");
                                    string cur = Console.ReadLine();
                                    Console.WriteLine("Enter artist id: ");
                                    int artistID = int.Parse(Console.ReadLine());
                                    gallery = new Gallery() { Name = name, Description = des, Location = loc, Opening_hours = opnh, Curator = cur, ArtistID = artistID };
                                    galleryService.InsertRecordstoGallery(gallery);
                                    Console.WriteLine("Gallery added succesfully");
                                    Console.WriteLine("Press any key to return to the main menu...");
                                    Console.ReadKey();
                                    break;

                                case 2:

                                    Console.WriteLine("Enter Name: ");
                                    string u_name = Console.ReadLine();
                                    Console.WriteLine("Enter description: ");
                                    string u_des = Console.ReadLine();
                                    Console.WriteLine("Enter Location: ");
                                    string u_loc = Console.ReadLine();
                                    Console.WriteLine("Enter Openiong hours: ");
                                    string u_opnh = Console.ReadLine();
                                    Console.WriteLine("Enter Curator: ");
                                    string u_cur = Console.ReadLine();
                                    Console.WriteLine("Enter artist id: ");
                                    int u_artistID = int.Parse(Console.ReadLine());
                                    gallery = new Gallery() { Name = u_name, Description = u_des, Location = u_loc, Opening_hours = u_opnh, Curator = u_cur, ArtistID = u_artistID };
                                    galleryService.UpdateRecordsInGallery(gallery);
                                    Console.WriteLine("Gallery udpated succesfully");
                                    Console.WriteLine("Press any key to return to the main menu...");
                                    Console.ReadKey();
                                    break;

                                case 3:
                                    Console.WriteLine("Enter gallery id: ");
                                    int gall_id = int.Parse(Console.ReadLine());
                                    galleryService.RemovefromGallery(gall_id);
                                    Console.WriteLine("Gallery Removed Successfully");
                                    Console.WriteLine("Press any key to return to the main menu...");
                                    Console.ReadKey();
                                    break;



                                case 4:
                                    Console.WriteLine("Enter a keyword to search for:");
                                    string galleryKeyword = Console.ReadLine();
                                    searchGallery(galleryKeyword);
                                    Console.WriteLine("Press any key to return to the main menu...");
                                    Console.ReadKey();
                                    break;


                                case 5:
                                    Console.WriteLine("Exiting...");
                                    break;

                                default:
                                    Console.WriteLine("Try Again!!!!");
                                    break;
                            }
                        } while (choice3 != 5);
                        break;
                    case 4:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Try again:");
                        break;
                }

            } while (choice != 4);
        }
    }
}
