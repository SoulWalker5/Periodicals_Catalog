using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PeriodicalsInitializer : DropCreateDatabaseAlways<PeriodicalsContext>
    {

        string errorTxt = "";
        protected override void Seed(PeriodicalsContext context)
        {
            try
            {
                context.Topics.Add(new Topic() { Name = "Sport", ImageName = "sport.jpg" });
                context.Topics.Add(new Topic() { Name = "Music", ImageName = "music.jpg" });
                context.Topics.Add(new Topic() { Name = "Comics", ImageName = "comics.jpg" });
                context.Topics.Add(new Topic() { Name = "Women", ImageName = "women.jpg" });
                context.Topics.Add(new Topic() { Name = "Men", ImageName = "men.jpg" });
                context.Topics.Add(new Topic() { Name = "Fashion", ImageName = "fashion.jpg" });
                context.Topics.Add(new Topic() { Name = "Business", ImageName = "business.jpg" });
                context.Topics.Add(new Topic() { Name = "XXX", ImageName = "XXX.jpg" });

                context.SaveChanges();

                context.Periodicals.Add(new Periodical
                {
                    Name = "BILLBOARD",
                    Topic = context.Topics.Where(t => t.Name == "Fashion").FirstOrDefault(),
                    Period = "1 per Month",
                    NumberOfPublications = 130,
                    ImageName = "Billboard.jpg",
                    Annotation = "Billboard, stylized as billboard, is an American entertainment" +
                    "media brand owned by the Billboard-Hollywood Reporter Media Group, a division " +
                    "of Eldridge Industries. It publishes pieces involving news, video, opinion, reviews," +
                    " events, and style, and is also known for its music charts, including the Hot 100 " +
                    "and Billboard 200, tracking the most popular songs and albums in different genres. " +
                    "It also hosts events, owns a publishing firm, and operates several TV shows."
                });

                context.Periodicals.Add(new Periodical
                {
                    Name = "Bon Appétit",
                    Topic = context.Topics.Where(t => t.Name == "Women").FirstOrDefault(),
                    Period = "1 per Month",
                    NumberOfPublications = 100,
                    ImageName = "BonAppetit.jpg",
                    Annotation = "Bon Appétit is a monthly American food and entertaining magazine, " +
                    "that typically contains recipes, entertaining ideas, and wine reviews. " +
                    "Owned by Condé Nast, it is headquartered at the One World Trade Center in Manhattan, " +
                    "New York City and has been in publication since 1956. Bon Appétit has been recognized " +
                    "for increasing its online presence in recent years through the use of social media, publishing" +
                    " recipes on their website, and maintaining an increasingly popular YouTube channel."
                });

                context.Periodicals.Add(new Periodical
                {
                    Name = "Platinum Business",
                    Topic = context.Topics.Where(t => t.Name == "Business").FirstOrDefault(),
                    Period = "1 per Month",
                    NumberOfPublications = 150,
                    ImageName = "Business.jpg",
                    Annotation = "The Platinum Publishing Group was formed seven years ago to serve the " +
                    "business community of the South East. The region is the economic powerhouse of the UK" +
                    " but was very poorly served by any publication that connected businesses and kept them abreast" +
                    " of all the news, views and opinion."
                });

                context.Periodicals.Add(new Periodical
                {
                    Name = "Cosmopolitan",
                    Topic = context.Topics.Where(t => t.Name == "Fashion").FirstOrDefault(),
                    Period = "1 per Month",
                    NumberOfPublications = 150,
                    ImageName = "Cosmopolitan.jpg",
                    Annotation = "Cosmopolitan is an American monthly women fashion and entertainment magazine," +
                    " first published based in New York City on March 1886; it was formerly titled The Cosmopolitan." +
                    " Cosmopolitan magazine is one of the best-selling magazines and is directed mainly towards a female audience." +
                    " The magazine was first published based in New York City on March 1886 in the United States" +
                    " as a family magazine; it was later transformed into a literary magazine and since 1965 has become" +
                    " a women's magazine."
                });

                context.Periodicals.Add(new Periodical
                {
                    Name = "Batman",
                    Topic = context.Topics.Where(t => t.Name == "Comics").FirstOrDefault(),
                    Period = "1 per Month",
                    NumberOfPublications = 150,
                    ImageName = "DC.jpg",
                    Annotation = "Batman is a fictional character, a comic book superhero appearing in comic books published by DC Comics. " +
                        "Batman was created by artist Bob Kane and writer Bill Finger, and first appeared in Detective Comics #27 (May 1939). " +
                        "Originally referred to as \"the Bat-Man\" and still referred to at times as \"the Batman\", " +
                        "the character is additionally known as \"the Caped Crusader\", \"the Dark Knight\", and \"the World's Greatest Detective\",among other titles"
                });

                context.Periodicals.Add(new Periodical
                {
                    Name = "Fine Cooking",
                    Topic = context.Topics.Where(t => t.Name == "Women").FirstOrDefault(),
                    Period = "1 per Month",
                    NumberOfPublications = 150,
                    ImageName = "FineCooking.jpg",
                    Annotation = "Taunton Press is a publisher of periodicals, books, and websites for the hobbyist" +
                    " and building trades based in Newtown, Connecticut. It was established in 1975 by Paul Roman" +
                    " and his wife Jan. aunton Press also publishes books on topics covered in their magazines: woodworking," +
                    " home building, home design, cooking, gardening and crafts. Popular publications have included Sarah" +
                    " Susanka's Not So Big home design series, New York Times Bestseller The Food You Crave by Ellie Krieger, " +
                    "The Crocheted Prayer Shawl Companion by Janet Bristow and Victoria A. Cole-Galo, Graphic Guide to Frame" +
                    " Construction by Robert Thallon, and Turning Wood with Richard Raffan and Cooking Allergy-Free by Jenna Short."
                });

                context.Periodicals.Add(new Periodical
                {
                    Name = "Forbes",
                    Topic = context.Topics.Where(t => t.Name == "Business").FirstOrDefault(),
                    Period = "1 per Month",
                    NumberOfPublications = 150,
                    ImageName = "Forbes.jpg",
                    Annotation = "Business news and financial news by Forbes.com. Core topics include business, " +
                        "technology, stock markets, personal finance, and lifestyle. Personal finance advice, tools, " +
                        "and investing tips provided by Forbes and affiliated publications."
                });

                context.Periodicals.Add(new Periodical
                {
                    Name = "Glamour",
                    Topic = context.Topics.Where(t => t.Name == "Fashion").FirstOrDefault(),
                    Period = "1 per Month",
                    NumberOfPublications = 150,
                    ImageName = "Glamour.jpg",
                    Annotation = "Glamour is an online women's magazine published by Condé Nast Publications." +
                    " Founded in 1939 and first published in April 1939 in the United States, it was originally" +
                    " called Glamour of Hollywood."
                });

                context.Periodicals.Add(new Periodical
                {
                    Name = "Global Finance",
                    Topic = context.Topics.Where(t => t.Name == "Business").FirstOrDefault(),
                    Period = "1 per Month",
                    NumberOfPublications = 150,
                    ImageName = "GlobalFinance.jpg",
                    Annotation = "Global Finance is an English-language monthly financial magazine." +
                    " Joseph D. Giarraputo, the founder and former publisher of Venture, the magazine" +
                    " for entrepreneurs, in 1987 joined forces with Carl G. Burgen, Stephan Spahn, H. Allen Fernald," +
                    " and Paolo Panerai to start a magazine on financial globalization." +
                    " The magazine's primary target audience consists of Chairmen, Presidents, CEOs, CFOs, " +
                    "Treasurers and other financial officers. The magazine is distributed in 158 countries, " +
                    "with 50,050 global subscribers and recipients, certified by BPA Worldwide."
                });

                context.Periodicals.Add(new Periodical
                {
                    Name = "Spider-Man",
                    Topic = context.Topics.Where(t => t.Name == "Comics").FirstOrDefault(),
                    Period = "1 per Month",
                    NumberOfPublications = 150,
                    ImageName = "Marvel.jpg",
                    Annotation = "Spider-Man is a fictional superhero created by writer-editor" +
                    " Stan Lee and writer-artist Steve Ditko. He first appeared in the anthology" +
                    " comic book Amazing Fantasy #15 (August 1962) in the Silver Age of Comic Books." +
                    " He appears in American comic books published by Marvel Comics, as well as in " +
                    "a number of movies, television shows, and video game adaptations set in the " +
                    "Marvel Universe. In the stories, Spider-Man is the alias of Peter Parker, an " +
                    "orphan raised by his Aunt May and Uncle Ben in New York City after his parents " +
                    "Richard and Mary Parker were killed in a plane crash."
                });

                context.Periodicals.Add(new Periodical
                {
                    Name = "Maxim",
                    Topic = context.Topics.Where(t => t.Name == "XXX").FirstOrDefault(),
                    Period = "1 per Month",
                    NumberOfPublications = 120,
                    ImageName = "Maxim.jpg",
                    Annotation = "Maxim is an international men's magazine, devised and launched " +
                    "in the UK in 1995, but based in New York City since 1997,[3] and prominent for its " +
                    "photography of actresses, singers, and female models whose careers are at a current peak. " +
                    "Maxim has a circulation of about 9 million readers each month. " +
                    "Maxim Digital reaches more than 4 million unique viewers each month. " +
                    "Maxim magazine publishes 16 editions, sold in 75 countries worldwide."
                });

                context.Periodicals.Add(new Periodical
                {
                    Name = "Mens Health",
                    Topic = context.Topics.Where(t => t.Name == "Men").FirstOrDefault(),
                    Period = "1 per Month",
                    NumberOfPublications = 150,
                    ImageName = "MensHealth.jpg",
                    Annotation = "Mens Health (MH) is the world’s largest men’s magazine brand, with 38 editions around the world," +
                       "a monthly circulation of 1.85 million, and 12 million monthly readers.It covers fitness, nutrition, sexuality," +
                       "lifestyle and other aspects of mens life and health.Launched in 1987 as a health-oriented service magazine " +
                       "by founding editor Mark Bricklin, Men’s Health has evolved into more of a lifestyle magazine for men, " +
                       "covering all aspects of a guy’s life: health, fitness, fashion, nutrition, relationships,travel, technology, " +
                       "fashion and finance. Stephen Perrine, the magazine’s former editorial creative director, once summed up the " +
                       "breadth of the magazine’s coverage as follows: “I don’t have problems. I have story ideas."
                });

                context.Periodicals.Add(new Periodical
                {
                    Name = "Money",
                    Topic = context.Topics.Where(t => t.Name == "Business").FirstOrDefault(),
                    Period = "1 per Month",
                    NumberOfPublications = 150,
                    ImageName = "Money.jpg",
                    Annotation = "Money is a personal finance brand and website owned by Ad Practitioners " +
                    "LLC and formerly also a monthly magazine, first published by Time Inc. (1972–2018) " +
                    "and later by Meredith Corporation (2018–2019). Its articles cover the gamut of personal " +
                    "finance topics ranging from credit cards, mortgages, insurance, banking and investing to " +
                    "family finance issues like paying for college, credit, career and home improvement. " +
                    "It is well known for its annual list of \"America's Best Places to Live\""
                });

                context.Periodicals.Add(new Periodical
                {
                    Name = "Music Connection",
                    Topic = context.Topics.Where(t => t.Name == "Music").FirstOrDefault(),
                    Period = "1 per Month",
                    NumberOfPublications = 150,
                    ImageName = "MusicConnection.jpg",
                    Annotation = "Music Connection is a United States-based monthly music-trade magazine," +
                    " which began publication in 1977. It caters to career-minded musicians, songwriters, " +
                    "recording artists and assorted music-industry support personnel. The magazine began by " +
                    "focusing on the Southern California music scene, but now has a national focus and national distribution." +
                    " Music Connection also publishes reviews of unsigned and independent live performers and recording artists." +
                    " A number of acclaimed artists achieved their first music-magazine-cover status from Music Connection. " +
                    "Those artists and groups include Guns N' Roses, Madonna, Jane's Addiction, Alanis Morissette," +
                    " White Stripes and Adele."
                });

                context.Periodicals.Add(new Periodical
                {
                    Name = "PLAYBOY",
                    Topic = context.Topics.Where(t => t.Name == "XXX").FirstOrDefault(),
                    Period = "1 per Month",
                    NumberOfPublications = 150,
                    ImageName = "Playboy.jpg",
                    Annotation = "Playboy is an American men's lifestyle and entertainment magazine," +
                    " formerly in print and currently online. It was founded in Chicago in 1953, by Hugh Hefner" +
                    " and his associates, and funded in part by a $1,000 loan from Hefner's mother. " +
                    "Notable for its centerfolds of nude and semi-nude[4] models (Playmates), " +
                    "Playboy played an important role in the sexual revolution[5] and remains one of the" +
                    " world's best-known brands, having grown into Playboy Enterprises, Inc. (PEI), " +
                    "with a presence in nearly every medium. In addition to the flagship magazine in the United States" +
                    ", special nation-specific versions of Playboy are published worldwide."
                });

                context.Periodicals.Add(new Periodical
                {
                    Name = "Sport",
                    Topic = context.Topics.Where(t => t.Name == "Sport").FirstOrDefault(),
                    Period = "2 per Month",
                    NumberOfPublications = 150,
                    ImageName = "Sport.jpg",
                    Annotation = "SPORT predated the launch of Sports Illustrated by eight years," +
                    " and is remembered for bringing several editorial innovations to the genre, " +
                    "as well as creating, in 1955, the SPORT Magazine Award. The SPORT Award, " +
                    "given initially to the outstanding player in baseball's World Series (Johnny Podres " +
                    "of the Brooklyn Dodgers was the inaugural winner), was later expanded to include the " +
                    "pre-eminent post-season performers in the other three major North American team sports. " +
                    "What made SPORT the most distinctive from Sports Illustrated, however, was that it " +
                    "was a monthly magazine as opposed to SI's weekly distribution."
                });

                context.Periodicals.Add(new Periodical
                {
                    Name = "TIME",
                    Topic = context.Topics.Where(t => t.Name == "Business").FirstOrDefault(),
                    Period = "1 per Month",
                    NumberOfPublications = 150,
                    ImageName = "Time.jpg",
                    Annotation = "Time is the indefinite continued progress of existence and events that" +
                    " occur in an apparently irreversible succession from the past, through the present," +
                    " into the future. Time is a component quantity of various measurements used to sequence" +
                    " events, to compare the duration of events or the intervals between them, and to quantify" +
                    " rates of change of quantities in material reality or in the conscious experience. " +
                    "Time is often referred to as a fourth dimension, along with three spatial dimensions."
                });

                context.Periodicals.Add(new Periodical
                {
                    Name = "VOGUE",
                    Topic = context.Topics.Where(t => t.Name == "Fashion").FirstOrDefault(),
                    Period = "1 per Month",
                    NumberOfPublications = 150,
                    ImageName = "Vogue.jpg",
                    Annotation = "As Wintour came to personify the magazine's image, both she and Vogue drew critics. " +
                        "Wintour's one-time assistant at the magazine, Lauren Weisberger, wrote a roman a clef entitled The Devil Wears Prada. " +
                        "Published in 2003, the novel became a bestseller and was adapted as a highly successful, " +
                        "Academy Award-nominated film in 2006. The central character resembled Weisberger, and her boss was a powerful " +
                        "editor-in-chief of a fictionalized version of Vogue. The novel portrays a magazine ruled by \"the Antichrist " +
                        "and her coterie of fashionistas, who exist on cigarettes, Diet Dr. Pepper, and mixed green salads\", " +
                        "according to a review in The New York Times. The editor is described by Weisberger as being \"an empty, " +
                        "shallow, bitter woman who has tons and tons of gorgeous clothes and not much else"
                });

                context.SaveChanges();

                context.Comments.Add(new Comment
                {
                    UserName = "Denys",
                    CreateTime = new DateTime(2008, 5, 1, 8, 30, 52),
                    Text = "Cool journal",
                    Periodical = context.Periodicals.Where(t => t.Name == "Sport").FirstOrDefault()

                });

                context.Comments.Add(new Comment
                {
                    UserName = "Anna",
                    CreateTime = new DateTime(2020, 9, 8, 18, 00, 35),
                    Text = "This should be a comment",
                    Periodical = context.Periodicals.Where(t => t.Name == "Sport").FirstOrDefault()

                });
                context.Comments.Add(new Comment
                {
                    UserName = "Anna",
                    CreateTime = new DateTime(2015, 7, 9, 15, 30, 41),
                    Text = "This should be a comment",
                    Periodical = context.Periodicals.Where(t => t.Name == "VOGUE").FirstOrDefault()
                });

                base.Seed(context);
            }
            catch (Exception ex)
            {
                errorTxt = DateTime.Now.Date.ToString() + " " + ex.Message + "\n";
            }
        }
    }
}
