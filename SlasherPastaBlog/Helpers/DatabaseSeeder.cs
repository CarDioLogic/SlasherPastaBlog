using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SlasherPastaBlog.Data;
using SlasherPastaBlog.Models;
using static System.Formats.Asn1.AsnWriter;

namespace SlasherPastaBlog.Helpers
{
    public static class DatabaseSeeder
    {
        public static void SeedDatabase(ApplicationDbContext context, ApplicationUser user)
        {
            if (!context.Set<Artigos>().Any())
            {
                var random = new Random();
                var roles = new[] { "RatingM", "RatingT", "RatingE" };
   

                var artigo1 = new Artigos
                {
                    Titulo = "The Haunting of Blackwood Manor",
                    Conteudo = "The old manor had stood abandoned for years, its crumbling facade barely visible through the thick overgrowth of ivy and tangled bushes that surrounded it like a fortress. For decades, it had been whispered about in the nearby village—a place of dark secrets and tragic histories.\r\n\r\nOne stormy autumn night, when the wind howled through the trees and rain beat against the ancient slate roof, a solitary figure dared to approach the manor. Emily, a young photographer with a penchant for the macabre, had heard the legends and couldn't resist the lure of capturing the manor's eerie beauty through her lens.\r\n\r\nAs she neared the imposing front entrance, her flashlight flickered uncertainly, casting eerie shadows that danced across the moss-covered walls. The air felt unnaturally cold, and each step seemed to echo through the stillness of the night. Just as Emily raised her camera to take the first shot, she noticed something peculiar—a faint glow emanating from one of the upper windows.\r\n\r\nHer heart skipped a beat as she stared at the flickering light. Who could possibly be inside this forsaken place? Legends spoke of the ghostly inhabitants who were said to roam its halls, restless and vengeful. But curiosity mingled with fear, driving Emily forward as she cautiously ascended the creaking steps to the front door.\r\n\r\nThe door, surprisingly, swung open with a groan as if beckoning her inside. Emily hesitated, her mind racing with warnings and curiosity warring within her. With a deep breath, she stepped over the threshold into darkness, her flashlight casting a feeble beam that revealed a grand but dilapidated foyer choked with dust and cobwebs.\r\n\r\nThe flickering light drew her gaze upward again, and she began to ascend the staircase, each step protesting loudly beneath her weight. The air grew thicker with each floor she climbed, carrying a scent of damp decay that made her stomach churn. Finally, she reached the door of the room from which the light emanated.\r\n\r\nSummoning her courage, Emily pushed the door open, revealing a scene that froze her blood. The room was frozen in time, furnished with antique pieces draped in dusty sheets. But what caught her eye was the source of the light—a candle burning on an ornate wooden table in the center of the room.\r\n\r\nThere, seated at the table, was an elderly woman in a faded blue dress, her hair a tangle of silver strands that framed a face etched with deep lines of sorrow. She stared at Emily with eyes that seemed to hold a lifetime of loneliness and regret.\r\n\r\nEmily's voice caught in her throat as she struggled to speak. \"Who are you? What are you doing here?\"\r\n\r\nThe woman's voice was a whisper, frail and haunting. \"I am Margaret. I have waited for someone to come.\"\r\n\r\nWith trembling hands, Emily raised her camera, her fingers instinctively clicking the shutter to capture the surreal tableau before her. But as the flash illuminated the room, Margaret's form seemed to waver like a mirage, fading into the darkness until only the flickering candle remained.\r\n\r\nEmily stood frozen, her mind reeling with disbelief. Had she imagined it all? Or had she truly encountered a ghost from the manor's haunted past? As she turned to leave, a chill swept through her, accompanied by a soft whisper in the wind—a voice from beyond, thanking her for finally bringing light to the forgotten shadows of the old manor.\r\n\r\nAnd as Emily hurried back down the staircase and out into the stormy night, she couldn't shake the feeling that the manor's secrets had only just begun to reveal themselves, and that her encounter with Margaret was just the beginning of a haunting tale yet to be fully told.",
                    DataPublicacao = new DateTime(2024, 5, 31, 0, 0, 0),
                    Role = roles[random.Next(roles.Length)],
                    ApplicationUserId = user.Id,
                    Ratings = new List<ArtigoRatings>()
                };

                var artigo2 = new Artigos
                {
                    Titulo = "The Haunting of Willow Lake",
                    Conteudo = "In the quiet town of Willow Lake, nestled deep in the Appalachian Mountains, there stood a mansion with a dark reputation. The old Willowcrest Manor had been abandoned for decades, its grandeur faded into a haunting silhouette against the backdrop of the mist-shrouded lake.\r\n\r\nOne fateful summer, a group of college friends—Sarah, David, and Emma—decided to spend their vacation exploring the mysteries of Willowcrest Manor. Drawn by tales of ghostly apparitions and eerie happenings, they packed their bags with cameras and camping gear, determined to uncover the truth behind the rumors.\r\n\r\nAs they approached the mansion, Sarah felt a chill run down her spine despite the warm breeze that swept through the overgrown gardens. Ivy clung to the cracked walls like skeletal fingers, and broken windows gaped like hollow eyes, watching their approach with silent menace.\r\n\r\nThe front door creaked open with a reluctant groan, revealing a foyer filled with dust and decay. Sarah led the way, her footsteps echoing in the silence as they ventured deeper into the mansion's shadowy interior. The air hung heavy with the scent of damp wood and old secrets.\r\n\r\nThey explored room after room, each one a testament to a bygone era of opulence now lost to time. Faded portraits stared down from the walls, their eyes following the intruders with a haunting intensity. Yet, despite the eerie atmosphere, the friends found no signs of the supernatural.\r\n\r\nAs dusk fell, they decided to camp by the edge of Willow Lake, hoping to catch a glimpse of the mansion's rumored specters. Emma built a small fire while Sarah and David set up their cameras, aiming to capture any paranormal activity that might manifest in the moonlit hours.\r\n\r\nHours passed in tense anticipation, the crackle of the fire the only sound breaking the silence of the night. Just as Sarah began to doubt the tales they had heard, a mist rose from the lake, swirling like ethereal tendrils around the mansion's silhouette.\r\n\r\nA figure appeared on the lakeshore—a woman in a flowing white gown, her hair streaming like liquid silver in the moonlight. Sarah's breath caught in her throat as she raised her camera, capturing the apparition in a series of mesmerizing shots.\r\n\r\nThe woman drifted closer, her eyes fixed on Sarah with a mix of longing and sorrow. She whispered words lost to the wind, a lament for a lost love that echoed across the still waters of Willow Lake. Sarah's hands shook as she continued to photograph the ghostly figure, her heart torn between fear and empathy.\r\n\r\nAnd then, as suddenly as she had appeared, the woman faded back into the mist, leaving the friends standing in awe and disbelief. They exchanged wide-eyed glances, their minds racing to comprehend the encounter they had just witnessed.\r\n\r\nAs dawn broke over Willow Lake, Sarah reviewed the photos on her camera, each image a haunting reminder of their night at Willowcrest Manor. The apparition's presence lingered in the frames, a testament to the enduring mystery of the mansion and the restless spirits that called it home.\r\n\r\nAs they packed up their campsite and made their way back to town, Sarah couldn't shake the feeling that they had stumbled upon something far beyond their understanding—that Willowcrest Manor held secrets that transcended time and space, waiting to be discovered by those brave enough to seek the truth.",
                    DataPublicacao = new DateTime(2024, 5, 14, 0, 0, 0),
                    Role = roles[random.Next(roles.Length)],
                    ApplicationUserId = user.Id,
                    Ratings = new List<ArtigoRatings>()
                };
                var artigo3 = new Artigos
                {
                    Titulo = "The Whispering Woods",
                    Conteudo = "Deep in the heart of Blackwood Forest, where ancient trees stood sentinel and tangled roots snaked across the forest floor, there lay a clearing untouched by sunlight. Folklore whispered of the Whispering Woods—a place where shadows danced to unheard melodies and whispers echoed among the gnarled branches.\r\n\r\nOne moonless night, a group of friends dared each other to venture into the heart of Blackwood Forest, seeking the fabled clearing where the trees whispered secrets of the past. Among them was Mia, a skeptic who scoffed at the tales but couldn't resist the thrill of the unknown.\r\n\r\nAs they delved deeper into the forest, the air grew heavy with a palpable sense of foreboding. The towering trees loomed closer, their branches intertwining like skeletal fingers that reached out to ensnare unwary travelers. Despite her bravado, Mia felt a shiver run down her spine, sensing eyes watching from the shadows.\r\n\r\nHours passed as they stumbled through the undergrowth, guided only by the dim glow of their flashlights. At last, they stumbled upon the clearing—a small oasis of moonlight that bathed the forest floor in an eerie silver glow. The air grew still, as if the very forest held its breath in anticipation.\r\n\r\nBut as Mia stepped into the clearing, a cold breeze whispered through the trees, carrying with it a haunting melody that seemed to emerge from the very earth itself. She froze, her heart racing as the whispers grew louder, weaving a tale of lost souls and forbidden desires.\r\n\r\nIn the center of the clearing stood a solitary oak tree, its ancient roots coiling like serpents into the ground. Mia approached cautiously, drawn inexplicably to the tree as if it held the key to the forest's secrets. With trembling hands, she touched the rough bark, feeling a surge of energy that sent shivers down her spine.\r\n\r\nSuddenly, the ground trembled beneath their feet, and a thick mist enveloped the clearing, swirling around them like a specter. Shadows danced in the periphery of their vision, whispering secrets of love and betrayal, of vows broken and promises unkept.\r\n\r\nMia's friends huddled together, their faces pale with fear as the whispers grew louder, threatening to engulf them in a cacophony of despair. But Mia stood transfixed, her gaze locked on the oak tree as if in a trance.\r\n\r\nAnd then, as suddenly as it had begun, the mist dissipated, leaving them standing alone in the silent clearing. The whispers faded into the night, leaving only the rustling of leaves and the distant hoot of an owl.\r\n\r\nAs they stumbled back through the forest, Mia couldn't shake the feeling that they had witnessed something ancient and otherworldly—that the Whispering Woods held secrets far older than time itself. And as they emerged into the moonlit glade beyond the forest's edge, Mia glanced back at the clearing one last time, wondering if they had truly escaped the grasp of the whispers, or if they had merely begun to unravel the mysteries hidden within the heart of Blackwood Forest.",
                    DataPublicacao = new DateTime(2024, 2, 8, 0, 0, 0),
                    Role = roles[random.Next(roles.Length)],
                    ApplicationUserId = user.Id,
                    Ratings = new List<ArtigoRatings>()
                };
                var artigo4 = new Artigos
                {
                    Titulo = "The Forgotten Dollhouse",
                    Conteudo = "In the quiet village of Ravenswood, nestled among rolling hills and ancient oak trees, there stood a quaint cottage with a peculiar history. The cottage had once belonged to the eccentric widow, Mrs. Abigail Hawthorne, who was known for her obsession with collecting antique dolls.\r\n\r\nLegend had it that Mrs. Hawthorne's prized possession was a dollhouse—a perfect replica of her own cottage, complete with miniature furniture and delicate porcelain dolls that eerily resembled villagers who had long since passed away.\r\n\r\nYears after Mrs. Hawthorne's death, the cottage remained untouched, its windows boarded up and garden overgrown with wildflowers. Children dared each other to peek through the cracks in the fence, whispering tales of the haunted dollhouse and the spirits that supposedly roamed its tiny halls.\r\n\r\nOne autumn afternoon, a curious girl named Lily stumbled upon the overgrown cottage while exploring the outskirts of Ravenswood. With her heart pounding, she pushed open the creaking gate and ventured into the garden, her eyes fixed on the weathered cottage nestled among the trees.\r\n\r\nThe air was heavy with the scent of moss and fallen leaves as Lily approached the front door, which swung open with a rusty groan as if inviting her inside. She hesitated, her gaze drawn to the faint glow emanating from a window—a soft, warm light that seemed to beckon her closer.\r\n\r\nWith trembling hands, Lily stepped over the threshold into darkness, her flashlight casting long shadows across the dusty floorboards. Cobwebs clung to the walls like gossamer threads, and the air was thick with the musty scent of neglect.\r\n\r\nAs she ventured deeper into the cottage, Lily discovered a hidden staircase leading down into the cellar—a place rumored to hold Mrs. Hawthorne's most prized possessions, including the infamous dollhouse. With each step, her pulse quickened, anticipation mingling with apprehension.\r\n\r\nAt the bottom of the staircase, Lily found herself standing before a heavy oak door, its surface adorned with intricate carvings of swirling vines and delicate flowers. She reached out a trembling hand and pushed the door open, revealing a room bathed in soft candlelight.\r\n\r\nThere, in the center of the room, stood the dollhouse—a perfect replica of the cottage above, its tiny windows glowing with an otherworldly radiance. Lily approached cautiously, her breath catching in her throat as she peered through the miniature windows at the meticulously crafted rooms inside.\r\n\r\nBut as she reached out to touch the dollhouse, a chill swept through the air, and Lily felt a presence watching her—a presence that seemed to emanate from the very walls of the cellar. Whispers echoed in her ears, faint and indistinct, like the murmur of voices from a bygone era.\r\n\r\nSuddenly, the dolls inside the miniature rooms stirred to life, their porcelain eyes glinting in the candlelight as they turned to face Lily with silent curiosity. She stumbled back in shock, her heart racing as she realized that the spirits of Mrs. Hawthorne's beloved dolls had awakened, trapped in the dollhouse for eternity.\r\n\r\nWith a trembling voice, Lily whispered a heartfelt apology to the spirits, her words filled with compassion and understanding. And as she backed away from the dollhouse, leaving the cellar and the cottage behind, she knew that she had stumbled upon a secret that would forever haunt her dreams—a testament to the power of love and obsession, bound together in the forgotten dollhouse of Ravenswood.",
                    DataPublicacao = new DateTime(2023, 12, 12, 0, 0, 0),
                    Role = roles[random.Next(roles.Length)],
                    ApplicationUserId = user.Id,
                    Ratings = new List<ArtigoRatings>()
                };
                var artigo5 = new Artigos
                {
                    Titulo = "The Mirror's Reflection",
                    Conteudo = "In the heart of an old Victorian mansion, tucked away in the remote countryside, there hung a mirror with a dark and mysterious history. The mansion itself had been abandoned for years, its once-grand halls echoing with whispers of tragedy and loss.\r\n\r\nLegend had it that the mirror, an ornate gilded frame that stretched nearly to the ceiling, held a strange power. It was said that those who gazed into its depths would see not their own reflection, but glimpses of another realm—a place where shadows moved of their own accord and whispers echoed through the mist.\r\n\r\nOne stormy night, during the peak of a tempest that shook the ancient oaks surrounding the mansion, a young historian named James ventured inside. Drawn by tales of the mirror's enigmatic allure, he braved the eerie silence and the howling wind that rattled the mansion's windows.\r\n\r\nThe foyer greeted him with a musty scent of neglect and the faint glow of moonlight filtering through stained glass. With cautious steps, James made his way deeper into the mansion, his flashlight casting flickering shadows on the peeling wallpaper and dusty furniture.\r\n\r\nAt last, he found himself standing before the mirror—a towering presence that seemed to hold the very essence of the mansion's haunted history. James hesitated, his reflection wavering uncertainly in the silvered glass, before he summoned the courage to gaze into its depths.\r\n\r\nAs he stared into the mirror, the storm outside intensified, sending a cascade of rain against the windowpanes. For a moment, James saw only his own reflection staring back at him with hollow eyes. But then, as if a veil had been lifted, the mirror shimmered with an ethereal light.\r\n\r\nVisions flickered before his eyes—a woman in a flowing gown wandering through a mist-shrouded garden, her laughter mingling with the distant tolling of a bell. Shadows danced at the edge of his vision, whispering secrets that James strained to comprehend.\r\n\r\nA chill swept through the room, and James felt a presence behind him—a fleeting touch of cold fingers brushing against his neck. He turned sharply, but there was no one there, only the echo of footsteps fading into the silence.\r\n\r\nWith a pounding heart, James tore himself away from the mirror, his mind reeling with the visions he had witnessed. As he stumbled back through the mansion's darkened corridors, the storm raged outside, a symphony of wind and rain that matched the turmoil in his soul.\r\n\r\nDays passed, but James could not shake the memory of the mirror's reflection. He returned to the mansion again and again, drawn inexorably to the mystery that lay within its walls. Each time he gazed into the mirror, the visions grew clearer, revealing fragments of a forgotten past and the souls trapped within its haunted embrace.\r\n\r\nAnd as James delved deeper into the mansion's secrets, he uncovered a tragic tale of love and betrayal—a story that had been lost to time but preserved in the mirror's unforgiving gaze. With each revelation, James felt a strange kinship with the spirits that lingered within, their voices echoing through the corridors like a lament for the past.\r\n\r\nIn the end, James realized that the mirror was not merely a window to another realm but a portal to the souls who had once called the mansion home. And as he stood before it one last time, he whispered a silent farewell to the spirits, hoping to bring them peace as he left the mansion and its haunted mirror behind.",
                    DataPublicacao = new DateTime(2023, 11, 18, 0, 0, 0),
                    Role = roles[random.Next(roles.Length)],
                    ApplicationUserId = user.Id,
                    Ratings = new List<ArtigoRatings>()
                };

                //adding ratings to each artigo
                for (int i = 0; i < 10; i++)
                {
                    var rating = new ArtigoRatings
                    {
                        RaterId = "nonExistantRaterID",
                        Rating = random.Next(1, 6),
                        Artigo = artigo1
                    };
                    artigo1.Ratings.Add(rating);

                    var rating2 = new ArtigoRatings
                    {
                        RaterId = "nonExistantRaterID",
                        Rating = random.Next(1, 6),
                        Artigo = artigo2
                    };
                    artigo2.Ratings.Add(rating2);

                    var rating3 = new ArtigoRatings
                    {
                        RaterId = "nonExistantRaterID",
                        Rating = random.Next(1, 6),
                        Artigo = artigo3
                    };
                    artigo3.Ratings.Add(rating3);

                    var rating4 = new ArtigoRatings
                    {
                        RaterId = "nonExistantRaterID",
                        Rating = random.Next(1, 6),
                        Artigo = artigo4
                    };
                    artigo4.Ratings.Add(rating4);

                    var rating5 = new ArtigoRatings
                    {
                        RaterId = "nonExistantRaterID",
                        Rating = random.Next(1, 6),
                        Artigo = artigo5
                    };
                    artigo5.Ratings.Add(rating5);
                }

                context.Set<Artigos>().AddRange(artigo1, artigo2, artigo3, artigo4, artigo5);
                context.SaveChanges();
            }
        }
    }
}
