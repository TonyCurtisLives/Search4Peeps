using Search4Peeps.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;

namespace Search4Peeps.DAL
{
    public class PeepsInitializer : DropCreateDatabaseAlways<MontyPeepsContext>
    {
        protected override void Seed(MontyPeepsContext context)
        {
            var addressList = new List<Address>() { new Address
            {
                Line1 = "A very filthy field",
                Line2 = "Near an abandoned castle",
                City = "St. Giles in the Fields",
                StateOrProvince = "Middlesex",
                Country = "England",
                PostalCode = "37"
            },
            new Address
            {
                Line1 = "A very filthy field",
                Line2 = "Near an abandoned castle",
                City = "St. Giles in the Fields",
                StateOrProvince = "Middlesex",
                Country = "England",
                PostalCode = "37"
            },
            new Address
            {
                Line1 = "The Castle Anthrax With a Grail Shaped Beacon",
                Line2 = "- Tower near the Beacon",
                City = "Stirlingshire",
                StateOrProvince = "Stirling",
                Country = "Scotland",
                PostalCode = "16-19.5"
            },
            new Address
            {
                Line1 = "The Castle Anthrax With a Grail Shaped Beacon",
                Line2 = "- Torture Chamber",
                City = "Stirlingshire",
                StateOrProvince = "Stirling",
                Country = "Scotland",
                PostalCode = "16-19.5"
            },
            new Address
            {
                Line1 = "The Castle Anthrax With a Grail Shaped Beacon",
                Line2 = "- Examination Room 1",
                City = "Stirlingshire",
                StateOrProvince = "Stirling",
                Country = "Scotland",
                PostalCode = "16-19.5"
            },
            new Address
            {
                Line1 = "The Castle Anthrax With a Grail Shaped Beacon",
                Line2 = "- East Wing Clinic",
                City = "Stirlingshire",
                StateOrProvince = "Stirling",
                Country = "Scotland",
                PostalCode = "16-19.5"
            },
            new Address
            {
                Line1 = "Camelot",
                Line2 = "(only the model), Twickenham Film Studios",
                City = "Twickenham",
                StateOrProvince = "Middlesex",
                Country = "England",
                PostalCode = "35353-53"
            },
            new Address
            {
                Line1 = "The Bridge of Death",
                Line2 = "",
                City = "Stirlingshire",
                StateOrProvince = "Stirling",
                Country = "Scotland",
                PostalCode = "35353-53"
            },
            new Address
            {
                Line1 = "The Impressive Bridge",
                Line2 = "",
                City = "Twickenham",
                StateOrProvince = "Middlesex",
                Country = "England",
                PostalCode = "35353-53"
            },
            new Address
            {
                Line1 = "Camelot",
                Line2 = "(only the model), Twickenham Film Studios",
                City = "Twickenham",
                StateOrProvince = "Middlesex",
                Country = "England",
                PostalCode = "35353-53"
            },
            new Address
            {
                Line1 = "Camelot",
                Line2 = "(only the model), Twickenham Film Studios",
                City = "Twickenham",
                StateOrProvince = "Middlesex",
                Country = "England",
                PostalCode = "35353-53"
            },
            new Address
            {
                Line1 = "Camelot",
                Line2 = "(only the model), Twickenham Film Studios",
                City = "Twickenham",
                StateOrProvince = "Middlesex",
                Country = "England",
                PostalCode = "35353-53"
            },
            new Address
            {
                Line1 = "Cambridge",
                Line2 = "",
                City = "Twickenham",
                StateOrProvince = "Middlesex",
                Country = "England",
                PostalCode = "35353-53"
            },
            new Address
            {
                Line1 = "Doune Castle",
                Line2 = "",
                City = "Doune",
                StateOrProvince = "Stirling",
                Country = "Scotland",
                PostalCode = "35353-53"
            },
            new Address
            {
                Line1 = "The Cave of Caerbannog",
                Line2 = "",
                City = "",
                StateOrProvince = "Stirling",
                Country = "Scotland",
                PostalCode = "35353-53"
            },
            new Address
            {
                Line1 = "134 E street",
                Line2 = "",
                City = "Twickenham",
                StateOrProvince = "Middlesex",
                Country = "England",
                PostalCode = "35353-53"
            },
            new Address
            {
                Line1 = "Camelot",
                Line2 = "(only the model), Twickenham Film Studios",
                City = "Twickenham",
                StateOrProvince = "Middlesex",
                Country = "England",
                PostalCode = "35353-53"
            },
            };

            var photoNames = new List<string>
            {
                "Dennis.jpg",
                "WifeOfDennis.jpg",
                "Zoot.jpg",
                "Dingo.jpg",
                "DrPiglet.jpg",
                "DrWinston.jpg",
                "Arthur.jpg",
                "BridgeKeeper.jpg",
                "BlackKnight.jpg",
                "Galahad.jpg",
                "Lancelot.jpg",
                "bedevere.jpg",
                "FamousHistorian.jpg",
                "Frenchman.jpg",
                "rabbit.jpg",
                "SirNotAppearing.jpg",
                "Robin.jpg"
            };

            var photoList = new List<Photo>();
            foreach (var photoName in photoNames)
            {
                byte[] rawImage = null;
                // todo: for production use, need to ensure the contents of Assets folder
                // are not embedded, they are currently set to Build = Embedded in properties 
                var resourceName = string.Format("Search4Peeps.Assets.{0}", photoName);
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                using (var resourceStream = assembly.GetManifestResourceStream(resourceName))
                {
                    using (var memStream = new MemoryStream())
                    {
                        System.Drawing.Image image = System.Drawing.Image.FromStream(resourceStream);
                        image.Save(memStream, image.RawFormat);
                        rawImage = memStream.ToArray();
                    }
                }
                photoList.Add(new Photo { Image = rawImage });
            }

            var peepsList = new List<Peep>
            {
                new Peep
                {
                    Age = 37,
                    FirstName = "Dennis",
                    MiddleName = "The Politically Astute",
                    LastName = "Peasant",
                    Interests = "Communal living, gathering filth(not so much), ensurning everyone personally witnesses the violence inherent in the system",
                    FavoriteColor = "Brown",
                    HasShrubbery = false,
                    Nationality = "Brittan",
                    SwallowIQ = 10
                },
                new Peep
                {
                    Age = 36,
                    FirstName = "Wife",
                    MiddleName = "Who Doesn't Get Kings",
                    LastName = "Peasant",
                    Interests = "Communal living, gathering lovely filth, like to avoid discussing class differences",
                    FavoriteColor = "Gray",
                    HasShrubbery = false,
                    Nationality = "Brittan?",
                    SwallowIQ = 10
                },
                new Peep
                {
                    Age = 36,
                    FirstName = "Zoot",
                    MiddleName = "Just",
                    LastName = "Zoot",
                    Interests = "Communal living, Lighting Grail Shaped Beacons, Various knitting hobbies",
                    FavoriteColor = "Grail Gold",
                    HasShrubbery = false,
                    Nationality = "Brittan",
                    SwallowIQ = 10
                },
                new Peep
                {
                    Age = 36,
                    FirstName = "Dingo",
                    MiddleName = "",
                    LastName = "",
                    Interests = "Communal living, Enforcing rules with corporal punishment, Various knitting hobbies",
                    FavoriteColor = "White",
                    HasShrubbery = false,
                    Nationality = "Brittan",
                    SwallowIQ = 10
                },
                new Peep
                {
                    Age = 36,
                    FirstName = "Dr.",
                    MiddleName = "",
                    LastName = "Winston",
                    Interests = "Communal living, Helping wounded knights, Receiving corporal punishment, Various knitting hobbies",
                    FavoriteColor = "White",
                    HasShrubbery = false,
                    Nationality = "Brittan",
                    SwallowIQ = 10
                },
                new Peep
                {
                    Age = 36,
                    FirstName = "Dr.",
                    MiddleName = "",
                    LastName = "Piglet",
                    Interests = "Communal living, Helping wounded knights, Receiving corporal punishment, Various knitting hobbies",
                    FavoriteColor = "White",
                    HasShrubbery = false,
                    Nationality = "Brittan",
                    SwallowIQ = 10
                },
                new Peep
                {
                    Age = 42,
                    FirstName = "Arthur",
                    MiddleName = "King of the",
                    LastName = "Britons",
                    Interests = "Avoiding Camelot, Gathering knights, Finding a grail, Studying new science, Taking the short route to 5, Gaining knowledge of swallows for future reference",
                    FavoriteColor = "Gold",
                    HasShrubbery = false,
                    Nationality = "Brittan",
                    SwallowIQ = 150
                },
                new Peep
                {
                    Age = 62,
                    FirstName = "Bridge",
                    MiddleName = "(Old Man from Scene 23)",
                    LastName = "Keeper",
                    Interests = "Old legends, Laughing hysterically, Beating cats, Asking questions",
                    FavoriteColor = "None",
                    HasShrubbery = false,
                    Nationality = "Brittan",
                    SwallowIQ = 140
                },
                new Peep
                {
                    Age = 30,
                    FirstName = "Black",
                    MiddleName = "",
                    LastName = "Knight",
                    Interests = "Defending bridges, Bighting legs off, Prosthetics",
                    FavoriteColor = "Red",
                    HasShrubbery = false,
                    Nationality = "Brittian",
                    SwallowIQ = 10
                },
                new Peep
                {
                    Age = 22,
                    FirstName = "Sir",
                    MiddleName = "Galahad The",
                    LastName = "Chaste",
                    Interests = "Seeking the holy grail, Getting stitched up, Taking on just a little bit of peril",
                    FavoriteColor = "Blue, no Yell..",
                    HasShrubbery = false,
                    Nationality = "Brittan",
                    SwallowIQ = 10
                },
                new Peep
                {
                    Age = 42,
                    FirstName = "Sir",
                    MiddleName = "Lancelot The",
                    LastName = "Brave",
                    Interests = "Rescuing those in distress, Killing random wedding guests, Saving Galahad from almost certain peril",
                    FavoriteColor = "Blue",
                    HasShrubbery = false,
                    Nationality = "Brittan",
                    SwallowIQ = 10
                },
                new Peep
                {
                    Age = 42,
                    FirstName = "Sir",
                    MiddleName = "Bedevere The",
                    LastName = "Wise",
                    Interests = "Science, Weighing things, Building large wooden animals, Seeking shrubberies",
                    FavoriteColor = "Green",
                    HasShrubbery = false,
                    Nationality = "Brittan",
                    SwallowIQ = 130
                },
                new Peep
                {
                    Age = 42,
                    FirstName = "Famous",
                    MiddleName = "",
                    LastName = "Historian",
                    Interests = "Studying King Arthur and the Knights of the Round Table",
                    FavoriteColor = "Green",
                    HasShrubbery = false,
                    Nationality = "Brittan",
                    SwallowIQ = 100
                },
                new Peep
                {
                    Age = 42,
                    FirstName = "The",
                    MiddleName = "Taunting",
                    LastName = "Frenchman",
                    Interests = "Taunting British types, Hiding grails from the British, Launching cows at the Brittish",
                    FavoriteColor = "Green",
                    HasShrubbery = true,
                    Nationality = "French",
                    SwallowIQ = 80
                },
                new Peep
                {
                    Age = 42,
                    FirstName = "The",
                    MiddleName = "Decapitating",
                    LastName = "Bunny",
                    Interests = "Decapitating, Eating carrots",
                    FavoriteColor = "Orange",
                    HasShrubbery = true,
                    Nationality = "Brittan",
                    SwallowIQ = 180
                },
                new Peep
                {
                    Age = 42,
                    FirstName = "Sir",
                    MiddleName = "Not Appearing in this",
                    LastName = "Film",
                    Interests = "Not appearing in silly films, Finding some armor that fits",
                    FavoriteColor = "Blue",
                    HasShrubbery = true,
                    Nationality = "Brittan",
                    SwallowIQ = 200
                },
                new Peep
                {
                    Age = 42,
                    FirstName = "Brave",
                    MiddleName = "Sir",
                    LastName = "Robin",
                    Interests = "Listening to minstrels (sometimes), Running away, Changing his armor",
                    FavoriteColor = "Yellow",
                    HasShrubbery = false,
                    Nationality = "Brittan",
                    SwallowIQ = 10
                },
            };

            for (int x = 0; x < peepsList.Count; x++)
            {
                peepsList[x].Address = addressList[x];
                peepsList[x].Photo = photoList[x];
                context.Peeps.Add(peepsList[x]);
            }

            base.Seed(context);
        }
    }
}